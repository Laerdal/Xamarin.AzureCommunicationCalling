using System;
using System.Threading.Tasks;
using Com.Azure.Android.Communication.Common;
using Xamarin.Forms;
using Com.Azure.Android.Communication.Calling;
using Application = Android.App.Application;
using Java.Util;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Platform.Android;
using CameraFacing = Com.Azure.Android.Communication.Calling.CameraFacing;
using Com.Laerdal.Azurecommunicationhelper;
using TestSample.Interfaces;
using TestSample.Model;
using TestSample.Droid.Implementations;
using TestSample.Enums;
using Android.Media;
using Android.Content;
using TestSample.Droid.Services;
using Android.OS;
using Android.Hardware;
using Android.Runtime;
using Xamarin.Essentials;

[assembly: Dependency(typeof(ConferenceManagerSpecificPlatformAndroid))]

namespace TestSample.Droid.Implementations
{
    public class ConferenceManagerSpecificPlatformAndroid : Java.Lang.Object, IConferenceManagerSpecificPlatform, ISensorEventListener
    {
        private CallAgent _callAgent;
        private CallClient _callClient;
        private DeviceManager _deviceManager;
        private LocalVideoStream _localVideoStream;
        private VideoStreamRenderer _localRenderer;
        private VideoDeviceInfo _videoDeviceInfo = null;
        IncomingCall _incomingCall;
        private Call _call;
        public event EventHandler<View> LocalVideoAdded;
        public event EventHandler<ParticipantVideoStatusChangedArgs> RemoteVideoAdded;
        public event EventHandler<ParticipantVideoStatusChangedArgs> RemoteVideoRemoved;
        public event EventHandler<ParticipantJoinArgs> ParticipantJoined;
        public event EventHandler<ParticipantLeftArgs> ParticipantLeft;
        public event EventHandler<ParticipantMicrophoneStatusChangedArgs> ParticipantMicrophoneStatusChanged;
        public event EventHandler<ConferenceStateChangedEnventArgs> StateChanged;
        public event EventHandler<ParticipantSpeakingStatusChangedArgs> SpeakingChanged = delegate { };

        public string DisplayName { get; set; }
        public SelectedCamera CurrentCamera { get; set; } = SelectedCamera.Front;

        public bool MicrophoneMute => _call.IsMuted;

        public ConferenceState State => _call != null && _call.State == CallState.Connected ? ConferenceState.Connected : ConferenceState.Disconnected;

        public DateTime? ConnectingStart { get; private set; }
        public bool Initialized { get; private set; } = false;
        public bool SpeakerOn
        {
            get
            {
                return _audioManager.SpeakerphoneOn;
            }

            set
            {
                this._audioManager.SpeakerphoneOn = value;
            }
        }

        public DateTime? ConnectionStart { get; set; }
        public AudioManager _audioManager;
        private PowerManager.WakeLock wakeLock;
        private SensorManager sensorManager;
        private Sensor sensor;
        private PowerManager powerManager;
        public ConferenceManagerSpecificPlatformAndroid()
        {
            _audioManager = (AudioManager)Xamarin.Essentials.Platform.AppContext.GetSystemService(Context.AudioService);
            sensorManager = (SensorManager)Xamarin.Essentials.Platform.AppContext.GetSystemService(Context.SensorService);
            powerManager = (PowerManager)Xamarin.Essentials.Platform.AppContext.GetSystemService(Context.PowerService);
            sensor = sensorManager.GetDefaultSensor(SensorType.Proximity);
            sensorManager.RegisterListener(this, sensor, SensorDelay.Fastest);
        }
        #region Sensor Audio Android
        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
        }
        async void ISensorEventListener.OnSensorChanged(SensorEvent e)
        {

            if (await InCall())
            {
                if (_audioManager.BluetoothA2dpOn)
                    return;
                if (!_audioManager.SpeakerphoneOn && e.Values[0] < sensor.MaximumRange)
                    DisablePhoneScreen();
                else
                    EnablePhoneScreen();
            }

        }
        private void EnablePhoneScreen()
        {
            if (wakeLock != null)
            {
                wakeLock.SetReferenceCounted(false);
                wakeLock.Release();
                wakeLock = null;
            }
        }
        private void DisablePhoneScreen()
        {
            if (wakeLock == null)
            {
                wakeLock = powerManager.NewWakeLock(WakeLockFlags.ProximityScreenOff, "ScreenWakeLock");
            }
            wakeLock.Acquire();
        }
        #endregion
        public Task<bool> Init(string token, string name)
        {
            try
            {
                var credentials = new CommunicationTokenCredential(token);
                var callOptions = new CallAgentOptions();
                _callClient = new CallClient();
                callOptions.SetDisplayName(DisplayName = name);
                _callAgent = CallClientHelper.GetCallAgent(_callClient, Xamarin.Essentials.Platform.AppContext, credentials, callOptions);
                _deviceManager = CallClientHelper.GetDeviceManager(_callClient, Xamarin.Essentials.Platform.AppContext);
                _callAgent.IncomingCall += CallAgent_IncomingCall;
                return Task.FromResult(Initialized = true);
            }
            catch (System.Exception ex)
            {
                new ConferenceExceptions(ex);
                return Task.FromResult(Initialized = false);
            }
        }
        public void AddParticipants(string[] participantIds)
        {
            foreach (var item in participantIds)
            {
                _call.AddParticipant(new CommunicationUserIdentifier(item));
            }
        }
        private void CallAgent_IncomingCall(object sender, IncomingCallEventArgs e)
        {
            _incomingCall = e.P0;
            if (_incomingCall != null)
            {
                Intent callIntent = new Intent(Xamarin.Essentials.Platform.AppContext, typeof(IncommingNotificationService));
                callIntent.PutExtra("key", "voipcall");
                Xamarin.Essentials.Platform.AppContext.StartForegroundService(callIntent);
            }
        }

        public Task InitializeConference(AzureSetupRoom azureSetupRoom)
        {
            var appContext = Xamarin.Essentials.Platform.AppContext;
            var callOptions = new StartCallOptions();
            var joinCallOptions = new JoinCallOptions();
            var AudioOptions = new AudioOptions();
            AudioOptions.SetMuted(azureSetupRoom.MicrophoneEnabled);
            joinCallOptions.SetAudioOptions(AudioOptions);
            callOptions.SetAudioOptions(new AudioOptions());
            var callees = new List<CommunicationIdentifier>();
            var acsNumber = new PhoneNumberIdentifier[] { new PhoneNumberIdentifier(azureSetupRoom.CodeMeeting) };

            if (_deviceManager.Cameras.Count > 0)
            {
                switch (CurrentCamera = azureSetupRoom.SelectedCamera)
                {
                    case SelectedCamera.Front:
                        _videoDeviceInfo = _deviceManager.Cameras.First(c => c.CameraFacing == CameraFacing.Front);
                        break;
                    case SelectedCamera.Back:
                        _videoDeviceInfo = _deviceManager.Cameras.First(c => c.CameraFacing == CameraFacing.Back);
                        break;
                }
                _localVideoStream = new LocalVideoStream(_videoDeviceInfo, appContext);
                _localRenderer = new VideoStreamRenderer(_localVideoStream, appContext);
                var videoOptions = new VideoOptions(new LocalVideoStream[] { _localVideoStream });
                if (azureSetupRoom.VideoEnabled)
                {
                    callOptions.SetVideoOptions(videoOptions);
                    joinCallOptions.SetVideoOptions(videoOptions);
                }

            }
            switch (azureSetupRoom.TypeCall)
            {
                case TypeCall.Teams:
                    TeamsMeetingLinkLocator teamsMeetingLinkLocator = new TeamsMeetingLinkLocator(azureSetupRoom.CodeMeeting);
                    _call = _callAgent.Join(appContext, teamsMeetingLinkLocator, joinCallOptions);
                    break;
                case TypeCall.Group:
                    GroupCallLocator groupCallLocator = new GroupCallLocator(UUID.FromString(azureSetupRoom.CodeMeeting));
                    _call = _callAgent.Join(appContext, groupCallLocator, joinCallOptions);
                    break;
                case TypeCall.Direct:
                    callees.Add(new CommunicationUserIdentifier(azureSetupRoom.CodeMeeting));
                    _call = CallClientHelper.Call(_callAgent, appContext, callees, callOptions);
                    break;
                case TypeCall.Bot:
                    callees.Add(new CommunicationUserIdentifier("8:echo123"));
                    _call = CallClientHelper.Call(_callAgent, appContext, callees, callOptions);
                    break;
                case TypeCall.PSTN:
                    _call = CallClientHelper.Call(_callAgent, appContext, acsNumber, callOptions);
                    break;
            }
            _call.RemoteParticipantsUpdated += Call_RemoteParticipantsUpdated;
            _call.StateChanged += Call_StateChanged;
            _call.IsMutedChanged += Call_IsMutedChanged;
            return Task.CompletedTask;
        }
        public async void Screensharing()
        {
            //ScreenShareRawOutgoingVideoStream screenShareRawOutgoingVideoStream;
            //var videoFormats = new Java.Util.ArrayList();
            //var format = new VideoFormat();
            //format.SetWidth(1280);
            //format.SetHeight(720);
            //format.SetPixelFormat(PixelFormat.Rgba);
            //format.SetVideoFrameKind(VideoFrameKind.VideoSoftware);
            //format.SetFramesPerSecond(30);
            //format.SetStride1(1280 * 4);
            //videoFormats.Add(format);
            //RawOutgoingVideoStreamOptions rawOutgoingVideoStreamOptions = new RawOutgoingVideoStreamOptions();
            //rawOutgoingVideoStreamOptions.SetVideoFormats(videoFormats);
            //screenShareRawOutgoingVideoStream = new ScreenShareRawOutgoingVideoStream(rawOutgoingVideoStreamOptions);

        }
        public void StartForegroundService()
        {
            ConnectionStart = DateTime.UtcNow;
            Intent callIntent = new Intent(Android.App.Application.Context, typeof(AzureConferenceSpecificPlatformService))
.SetAction(AzureConferenceSpecificPlatformService.NewConference);
            Xamarin.Essentials.Platform.AppContext.StartForegroundService(callIntent);
        }
        public void StopService()
        {
            var intent = new Intent(Android.App.Application.Context, typeof(AzureConferenceSpecificPlatformService))
                .SetAction(AzureConferenceSpecificPlatformService.HangUpConference);
            Xamarin.Essentials.Platform.AppContext.StopService(intent);
        }
        public void Muted()
        {
            if (_call != null)
            {
                CallClientHelper.Mute(_call, Xamarin.Essentials.Platform.AppContext);
            }
        }
        public void UnMuted()
        {
            if (_call != null)
            {
                CallClientHelper.UnMute(_call, Xamarin.Essentials.Platform.AppContext);
            }
        }
        public Task<bool> MuteUnMuted()
        {
            if (_call != null)
            {
                if (_call.IsMuted)
                    CallClientHelper.UnMute(_call, Xamarin.Essentials.Platform.AppContext);
                else
                    CallClientHelper.Mute(_call, Xamarin.Essentials.Platform.AppContext);
                return Task.FromResult(_call.IsMuted);
            }
            return Task.FromResult(false);
        }
        public string CodeConference()
        {
            return _call.Id;
        }



        private void Call_IsMutedChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                {
                    var stateConference = ((Call)sender);
                    if (stateConference != null)
                        ParticipantMicrophoneStatusChanged?.Invoke(this, new ParticipantMicrophoneStatusChangedArgs(DisplayName, stateConference.IsMuted));
                }
            }
            catch (System.Exception ex)
            {
                new ConferenceExceptions(ex);
            }
        }
        public CallState AfterState { get; set; } = CallState.Disconnected;
        private void Call_StateChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender != null)
            {
                try
                {
                    var stateConference = ((Call)sender).State;
                    if (stateConference == CallState.Disconnected)
                    {
                        if (AfterState == CallState.Disconnected)
                            return;
                        //StopService();
                        AfterState = stateConference;
                        StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.Disconnected));
                    }
                    if (stateConference == CallState.Connected)
                    {
                        //In some scenario the event fires twice, this solution ended up preventing this so that
                        //the background service is not invoked again, needed more investigations about this.
                        if (AfterState == CallState.Connected)
                            return;
                        AfterState = stateConference;
                        //StartForegroundService();
                        StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.Connected));
                    }
                    if (stateConference == CallState.InLobby)
                        StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.InLobby));
                    if (stateConference == CallState.Connecting)
                        StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.Connecting));
                    if (stateConference == CallState.Disconnecting)
                        StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.Disconnecting));
                    if (stateConference == CallState.None)
                        StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.Unset));
                }
                catch (System.Exception ex)
                {
                    new ConferenceExceptions(ex);
                }
            }
        }
        private void Call_RemoteParticipantsUpdated(object sender, ParticipantsUpdatedEventArgs e)
        {
            foreach (var participantAdded in e.P0.AddedParticipants)
            {
                ParticipantJoined?.Invoke(this, new ParticipantJoinArgs(CommunicationIdentifierExtension.IdentifierExtension(participantAdded), participantAdded.DisplayName));
                ParticipantMicrophoneStatusChanged?.Invoke(this, new ParticipantMicrophoneStatusChangedArgs(participantAdded.DisplayName, participantAdded.IsMuted));
                participantAdded.VideoStreamsUpdated += RemoteVideoStreamsUpdated;
                participantAdded.IsSpeakingChanged += ParticipantAdded_IsSpeakingChanged;
                participantAdded.StateChanged += ParticipantAdded_StateChanged;
                participantAdded.IsMutedChanged += ParticipantAdded_IsMutedChanged;

                foreach (var videoStream in participantAdded.VideoStreams)
                {
                    if (videoStream.IsAvailable) PublishRemoteVideoStream(participantAdded, videoStream);
                }
            }
            foreach (var participantRemoved in e.P0.RemovedParticipants)
            {
                ParticipantLeft?.Invoke(this, new ParticipantLeftArgs(CommunicationIdentifierExtension.IdentifierExtension(participantRemoved), participantRemoved.DisplayName));
            }

        }
        private void ParticipantAdded_IsMutedChanged(object sender, PropertyChangedEventArgs e)
        {
            var stateConference = ((RemoteParticipant)sender);
            ParticipantMicrophoneStatusChanged?.Invoke(this, new ParticipantMicrophoneStatusChangedArgs(CommunicationIdentifierExtension.IdentifierExtension(stateConference), stateConference.IsMuted));
        }

        private void ParticipantAdded_StateChanged(object sender, PropertyChangedEventArgs e)
        {
        }

        private void ParticipantAdded_IsSpeakingChanged(object sender, PropertyChangedEventArgs e)
        {
            var participantAdded = ((RemoteParticipant)sender);
            SpeakingChanged?.Invoke(this, new ParticipantSpeakingStatusChangedArgs(CommunicationIdentifierExtension.IdentifierExtension(participantAdded), participantAdded.IsMuted, participantAdded.IsSpeaking));

        }
        private void RemoteVideoStreamsUpdated(object sender, RemoteVideoStreamsUpdatedEventArgs e)
        {
            if (sender != null)
            {
                if (sender is RemoteParticipant remoteParticipant)
                {
                    foreach (var v in e.P0.AddedRemoteVideoStreams)
                    {
                        if (v.IsAvailable) PublishRemoteVideoStream(remoteParticipant, v);
                    }
                    foreach (var v in e.P0.RemovedRemoteVideoStreams)
                    {
                        RemoveRemoteVideoStream(remoteParticipant, v);
                    }
                }
            }
        }
        private void RemoveRemoteVideoStream(RemoteParticipant remoteParticipant, RemoteVideoStream v)
        {
            RemoteVideoRemoved?.Invoke(this, new ParticipantVideoStatusChangedArgs(CommunicationIdentifierExtension.IdentifierExtension(remoteParticipant), remoteParticipant.IsMuted, null));
        }
        private void PublishRemoteVideoStream(RemoteParticipant remoteParticipant, RemoteVideoStream v)
        {
            var renderer = new VideoStreamRenderer(v, Xamarin.Essentials.Platform.AppContext);
            var renderingOptions = new CreateViewOptions(ScalingMode.Crop);
            var nativeView = renderer.CreateView(renderingOptions);
            var formsView = nativeView.ToView();
            RemoteVideoAdded?.Invoke(this, new ParticipantVideoStatusChangedArgs(CommunicationIdentifierExtension.IdentifierExtension(remoteParticipant), remoteParticipant.IsMuted, formsView));
        }
        public void Hangup()
        {
            if (_call != null)
            {
                CallClientHelper.HangUp(_call, new HangUpOptions());
                AfterState = CallState.Disconnected;
                _localRenderer = null;
                _localVideoStream = null;
                _call = null;
            }
        }


        public IReadOnlyCollection<ConferenceParticipant> Participants()
        {
            List<ConferenceParticipant> result = new List<ConferenceParticipant>();
            if (_call == null)
                return result;
            foreach (var item in _call.RemoteParticipants.ToList())
            {
                var conferenceParticipant = new ConferenceParticipant(CommunicationIdentifierExtension.IdentifierExtension(item), item.DisplayName);
                result.Add(conferenceParticipant);
            }
            return result;
        }
        public void StartScreensharing() { }

        public void StopScreensharing() { }
        public Task<string> GetServerCallId()
        {
            return Task.FromResult(CallClientHelper.GetServerCallId(_call.Info));
        }
        public void SwitchCamera()
        {
            switch (CurrentCamera)
            {
                case SelectedCamera.Front:
                    CurrentCamera = SelectedCamera.Back;
                    _videoDeviceInfo = _deviceManager.Cameras.First(c => c.CameraFacing == CameraFacing.Back);
                    break;
                case SelectedCamera.Back:
                    CurrentCamera = SelectedCamera.Front;
                    _videoDeviceInfo = _deviceManager.Cameras.First(c => c.CameraFacing == CameraFacing.Front);
                    break;
            }
            CallClientHelper.SwitchCameraSource(_localVideoStream, _videoDeviceInfo);
        }
        public void StartCamera()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    try
                    {
                        LocalVideoAdded?.Invoke(this, GetCameraView());

                    }
                    catch (System.Exception ex)
                    {
                        new ConferenceExceptions(ex);
                    }
                    CallClientHelper.StartVideo(_call, _localVideoStream, Xamarin.Essentials.Platform.AppContext);
                }
                catch (CallingCommunicationException ex)
                {
                    new ConferenceExceptions(ex);
                }
                catch (System.Exception ex)
                {
                    new ConferenceExceptions(ex);
                }
            });
        }
        public View GetCameraView()
        {
            if (_localRenderer != null)
            {
                var renderingOptions = new CreateViewOptions(ScalingMode.Crop);
                var nativeView = _localRenderer.CreateView(renderingOptions);
                return nativeView.ToView();
            }
            else return null;

        }
        public void StopCamera()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    LocalVideoAdded?.Invoke(this, null);
                    CallClientHelper.StopVideo(_call, _localVideoStream, Xamarin.Essentials.Platform.AppContext);
                }
                catch (CallingCommunicationException acsException)
                {
                    new ConferenceExceptions(acsException);

                }
                catch (Exception acsException)
                {
                    new ConferenceExceptions(acsException);

                }


            });
        }
        public Task<bool> InCall()
        {
            return Task.FromResult(_call != null ? true : false);
        }

        public async Task AcceptAsync()
        {
            var acceptCallOptions = new AcceptCallOptions();
            await Task.Delay(2000);
            _call = CallClientHelper.Accept(_incomingCall, acceptCallOptions, Xamarin.Essentials.Platform.AppContext);
            _incomingCall.CallEnded += IncomingCall_CallEnded;
            _call.RemoteParticipantsUpdated += Call_RemoteParticipantsUpdated;
            _call.IsMutedChanged += Call_IsMutedChanged;
            _call.StateChanged += Call_StateChanged;
        }

        private void IncomingCall_CallEnded(object sender, PropertyChangedEventArgs e)
        {

        }

        public Task RejectAsync()
        {
            CallClientHelper.Reject(_incomingCall);
            return Task.CompletedTask;
        }
    }
}