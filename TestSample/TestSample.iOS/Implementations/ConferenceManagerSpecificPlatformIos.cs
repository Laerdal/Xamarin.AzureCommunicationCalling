using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.AzureCommunicationCalling.iOS;
using System.Linq;
using TestSample.Interfaces;
using TestSample.Model;
using TestSample.iOS.Implementations;
using TestSample.Enums;
using System.ComponentModel;
using CallKit;
using AVFoundation;
using PushKit;
using Xamarin.Essentials;
using UIKit;
using static Xamarin.Essentials.AppleSignInAuthenticator;
using ReplayKit;
using CoreMedia;
using ARKit;
using System.Numerics;
using CoreFoundation;
using CoreVideo;
using System.Threading;
using CoreGraphics;

namespace TestSample.iOS.Implementations
{
    public class ConferenceManagerSpecificPlatformiOS : PKPushRegistryDelegate, IConferenceManagerSpecificPlatform
    {
        public ACSCallClient _callClient;
        private ACSDeviceManager _deviceManager;
        private ACSCallAgent _callAgent;
        private ACSCall _call;
        private ACSVideoDeviceInfo _videoDeviceInfo = null;
        private ACSIncomingCall _incomingCall;
        private ACSLocalVideoStream _localVideoStream;
        private ACSVideoStreamRenderer _previewRenderer;
        private ACSVideoStreamRendererView _preview;
        #region Screensharing
        ACSScreenShareRawOutgoingVideoStream screenShareRawOutgoingVideoStream;
        NSRecursiveLock recursiveLock = new NSRecursiveLock();
        ACSRawOutgoingVideoStreamOptions options;
        ACSOutgoingVideoStreamState outgoingVideoStreamState = ACSOutgoingVideoStreamState.None;
        #endregion
        private readonly CallingCallbackManager _videoCallbackManager;
        public event EventHandler<View> LocalVideoAdded;
        public event EventHandler<ConferenceStateChangedEnventArgs> StateChanged = delegate { };
        public event EventHandler<ParticipantVideoStatusChangedArgs> RemoteVideoRemoved = delegate { };
        public event EventHandler<ParticipantVideoStatusChangedArgs> RemoteVideoAdded = delegate { };
        public event EventHandler<ParticipantSpeakingStatusChangedArgs> SpeakingChanged = delegate { };
        public event EventHandler<ParticipantJoinArgs> ParticipantJoined = delegate { };
        public event EventHandler<ParticipantLeftArgs> ParticipantLeft = delegate { };
        public event EventHandler<ParticipantMicrophoneStatusChangedArgs> ParticipantMicrophoneStatusChanged = delegate { };
        public ConferenceState State => _call != null && _call.State == ACSCallState.Connected ? ConferenceState.Connected : ConferenceState.Disconnected;
        public DateTime? ConnectingStart { get; private set; }
        public DateTime? ConnectionStart { get; set; }
        public string DisplayName { get; set; }
        public bool MicrophoneMute => _call.IsMuted;
        public SelectedCamera CurrentCamera { get; set; } = SelectedCamera.Front;
        public string ServerCallId { get; set; }
        public bool VideoEnabled { get; set; } = false;
        public bool Initialized { get; private set; } = false;
        public bool SpeakerOn
        {
            get
            {
                return AVAudioSession.SharedInstance().OverrideOutputAudioPort(AVAudioSessionPortOverride.Speaker, out NSError e);
            }

            set
            {
                ChangeAudioRoute();
            }
        }
        public bool ChangeAudioRoute()
        {
            var audiosession = AVAudioSession.SharedInstance();
            var checkAudioRoute = audiosession.OverrideOutputAudioPort(AVAudioSessionPortOverride.Speaker, out NSError e);
            if (checkAudioRoute)
                audiosession.OverrideOutputAudioPort(AVAudioSessionPortOverride.None, out NSError err);
            else
                audiosession.OverrideOutputAudioPort(AVAudioSessionPortOverride.Speaker, out NSError er);
            audiosession.SetActive(true);
            return checkAudioRoute;
        }
        [Preserve]
        public ConferenceManagerSpecificPlatformiOS()
        {
            _videoCallbackManager = new CallingCallbackManager(
                RemoteVideoStreamRemoved,
                RemoteParticipantAdded,
                RemoteVideoStreamAdded,
                RemoteParticipantRemoved,
                RemoteParticipantMutedChanged,
                LocalStateChanged,
                RemoteParticipantSpeaking,
                IncomingCall,
                IncomingCallEnd,
                ScreenSharing);
        }
        public void ScreenSharing(ACSRawOutgoingVideoStreamOptions aCSRawOutgoingVideoStreamOptions, ACSOutgoingVideoStreamStateChangedEventArgs aCSOutgoingVideoStreamStateChangedEventArgs)
        {
            outgoingVideoStreamState = aCSOutgoingVideoStreamStateChangedEventArgs.OutgoingVideoStreamState;
        }
        public void IncomingCallEnd(ACSIncomingCall aCSIncomingCall)
        {
            _incomingCall = aCSIncomingCall;
        }
        public void IncomingCall(ACSIncomingCall aCSIncomingCall)
        {
            _incomingCall = aCSIncomingCall;
        }
        private void LocalStateChanged(ACSCall aCSCall)
        {
            StateCall(aCSCall.State);
        }
        private void RemoteParticipantSpeaking(ACSRemoteParticipant participantAdded)
        {
            SpeakingChanged?.Invoke(this, new ParticipantSpeakingStatusChangedArgs(CommunicationIdentifierExtension.IdentifierExtension(participantAdded), participantAdded.IsMuted, participantAdded.IsSpeaking));
        }
        private void RemoteParticipantAdded(ACSRemoteParticipant participantAdded)
        {
            ParticipantJoined?.Invoke(this, new ParticipantJoinArgs(CommunicationIdentifierExtension.IdentifierExtension(participantAdded), participantAdded.DisplayName));

        }
        private void RemoteParticipantMutedChanged(ACSRemoteParticipant participantAdded)
        {
            ParticipantMicrophoneStatusChanged?.Invoke(this, new ParticipantMicrophoneStatusChangedArgs(CommunicationIdentifierExtension.IdentifierExtension(participantAdded), participantAdded.IsMuted));

        }
        private void RemoteParticipantRemoved(ACSRemoteParticipant participantAdded)
        {
            ParticipantJoined?.Invoke(this, new ParticipantJoinArgs(CommunicationIdentifierExtension.IdentifierExtension(participantAdded), participantAdded.DisplayName));
        }
        private void RemoteVideoStreamAdded(VideoStream videoStream)
        {
            var remoteVideoStream = videoStream.RemoteVideoStream;
            var remoteParticipant = videoStream.RemoteParticipant;
            LoggerService.Debug("RemoteVideoStreamAdded");
            if (!remoteVideoStream.IsAvailable)
            {
                return;
            }
            LoggerService.Debug("RemoteVideoStreamAdded: Creating renderer");
            var renderer = new ACSVideoStreamRenderer(remoteVideoStream, out var rendererError);
            ThrowIfError(rendererError);
            var renderingOptions = new ACSCreateViewOptions(ACSScalingMode.Crop);
            var nativeView = renderer.CreateViewWithOptions(renderingOptions, out var createViewError);
            LoggerService.Debug("RemoteVideoStreamAdded: Created renderer");
            ThrowIfError(createViewError);
            var formsView = nativeView.ToView();
            RemoteVideoAdded?.Invoke(this, new ParticipantVideoStatusChangedArgs(CommunicationIdentifierExtension.IdentifierExtension(remoteParticipant), remoteParticipant.IsMuted, formsView));

        }
        private void RemoteVideoStreamRemoved(VideoStream videoStream)
        {
            var remoteVideoStream = videoStream.RemoteVideoStream;
            var remoteParticipant = videoStream.RemoteParticipant;
            LoggerService.Debug("RemoteVideoStreamAdded");
            RemoteVideoRemoved?.Invoke(this, new ParticipantVideoStatusChangedArgs(CommunicationIdentifierExtension.IdentifierExtension(remoteParticipant), remoteParticipant.IsMuted, null));

        }
        private void configureAudioSession()
        {
            var session = AVAudioSession.SharedInstance();
            session.SetCategory(AVAudioSessionCategory.PlayAndRecord, AVAudioSessionCategoryOptions.AllowBluetoothA2DP);
            session.SetPreferredSampleRate(48000, out var N);
            session.SetPreferredIOBufferDuration(0.05, out var N2);
         session.SetActive(true);
        }
        public void StateCall(ACSCallState acsCallState)
        {
            switch (acsCallState)
            {
                case ACSCallState.Disconnected:
                    StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.Disconnected));
                    break;
                case ACSCallState.Connected:
                    StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.Connected));
                    configureAudioSession();
                    break;
                case ACSCallState.Connecting:
                    StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.Connecting));
                    break;
                case ACSCallState.Disconnecting:
                    StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.Disconnecting));
                    break;
                case ACSCallState.InLobby:
                    StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.InLobby));
                    break;
                case ACSCallState.None:
                    StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.Unset));
                    break;
                default:
                    break;
            }
        }
        public Task<bool> Init(string token, string name)
        {
            try
            {
                var initTask = new TaskCompletionSource<bool>();
                _callClient = new ACSCallClient();

                void OnCallAgenttCreated(ACSCallAgent callAgent, NSError callAgentError)
                {
                    if (callAgentError != null)
                    {
                        Initialized = false;
                        initTask.TrySetCanceled();
                        throw new Exception(callAgentError.Description);
                    }
                    _callAgent = callAgent;
                    _callAgent.Delegate = new CallAgentDelegate(_videoCallbackManager);
                    // Create device manager AFTER call agent
                    void OnDeviceManagerCreated(ACSDeviceManager deviceManager, NSError deviceManagerError)
                    {
                        if (deviceManagerError != null)
                        {
                            throw new Exception(deviceManagerError.Description);
                        }
                        _deviceManager = deviceManager;
                        initTask.TrySetResult(true);
                    }
                    _callClient.GetDeviceManagerWithCompletionHandler(OnDeviceManagerCreated);
                    Initialized = true;
                    //var tokenDevice = await SecureStorage.GetAsync("TempPushKitToken");
                    //if (tokenDevice != "")
                    //    _callAgent.RegisterPushNotifications(tokenDevice, RegisterPush);//under investigation

                }
                var credentials = new CommunicationTokenCredential(token, out var nSError);
                if (nSError != null)
                {
                    initTask.TrySetCanceled();
                    throw new Exception(nSError.Description);
                }
                var cxProviderConfiguration = new CXProviderConfiguration("Receiving Conference From")
                {
                    MaximumCallsPerCallGroup = 1,
                    SupportsVideo = true,
                    MaximumCallGroups = 1
                };
                ACSCallAgentOptions aCSCallAgentOptions = new ACSCallAgentOptions
                {
                    DisplayName = DisplayName = name,
                    CallKitOptions = new ACSCallKitOptions(cxProviderConfiguration)
                };
                //CreateCallAgentWithCallKitOptions Only available in beta version
                _callClient.CreateCallAgentWithOptions(credentials, aCSCallAgentOptions, OnCallAgenttCreated);
                return initTask.Task;
            }
            catch (Exception ex)
            {
                new ConferenceExceptions(ex);
                return Task.FromResult(false);
            }
        }
        public void RegisterPush(NSError nSError)
        {

        }
        public void HandlePushNotificationCallkit(ACSPushNotificationInfo incomingCallPushNotification)
        {
            _callAgent.HandlePushNotification(incomingCallPushNotification, PushNotification);
        }
        public async override void DidUpdatePushCredentials(PKPushRegistry registry, PKPushCredentials credentials, string type)
        {
            if (credentials != null && credentials.Token != null)
            {
                var token = registry?.PushToken(PKPushType.Voip);
                await SecureStorage.SetAsync("TempPushKitToken", token.ToString());

            }
        }
        [Export("pushRegistry:didReceiveIncomingPushWithPayload:forType:withCompletionHandler:")]
        public override void DidReceiveIncomingPush(PKPushRegistry registry, PKPushPayload payload, string type, Action completion)
        {
            var incomingCallPushNotification = ACSPushNotificationInfo.FromDictionary(payload.DictionaryPayload);
            var callId = incomingCallPushNotification.CallId;
            var handle = incomingCallPushNotification.FromDisplayName;
            var hasVideo = incomingCallPushNotification.IncomingWithVideo;
            //the documentation doesn't make it clear whether this is for use with the callkit.
            //HandlePushNotificationCallkit(incomingCallPushNotification);

            //Callkit no implemented
            completion();
        }
        public void PushNotification(NSError nSError)
        {
        }
        public override void DidReceiveIncomingPush(PKPushRegistry registry, PKPushPayload payload, string type)
        {
        }
        public void AddParticipants(string[] participantIds)
        {
            foreach (var item in participantIds)
            {
                _call.AddParticipant(new CommunicationUserIdentifier(item), out NSError nSError);

            }
        }
        public void RemoteParticipants(ACSRemoteParticipant callingCallbackManager)
        {
            if (callingCallbackManager != null)
                ParticipantMicrophoneStatusChanged?.Invoke(this, new ParticipantMicrophoneStatusChangedArgs(CommunicationIdentifierExtension.IdentifierExtension(callingCallbackManager), callingCallbackManager.IsMuted));
        }
        public void Muted()
        {
            if (_call != null)
            {
                _call.MuteWithCompletionHandler(MutedUnMutedVoid());
            }
        }
        public Action<NSError> MutedUnMutedVoid()
        {
            return (action) =>
            {
                if (action != null) return;
            };
        }
        public void UnMuted()
        {
            if (_call != null)
            {
                _call.UnmuteWithCompletionHandler(MutedUnMutedVoid());
            }
        }
        public Task<bool> MuteUnMuted()
        {
            if (_call != null)
            {
                if (_call.IsMuted)
                    _call.UnmuteWithCompletionHandler(MutedUnMutedVoid());
                else
                    _call.MuteWithCompletionHandler(MutedUnMutedVoid());
                return Task.FromResult(_call.IsMuted);
            }
            return Task.FromResult(false);
        }
        public string CodeConference()
        {
            return _call.Id;
        }
        private void ThrowIfError(NSError rendererError)
        {
            if (!string.IsNullOrEmpty(rendererError?.Description))
            {
                new ConferenceExceptions(new System.Exception(rendererError.ToString()));
            }
        }
        private void CallCompleted(ACSCall call, NSError err)
        {
            _call = new ACSCall();
            _call = call;
            _call.Delegate = new CallDelegate(_videoCallbackManager);
            foreach (var remoteParticipant in _call.RemoteParticipants)
            {
                LoggerService.Debug("Remote participant already in call");
                remoteParticipant.Delegate = new RemoteParticipantDelegate(_videoCallbackManager);
                foreach (var remoteVideoStream in remoteParticipant.VideoStreams)
                {
                    RemoteVideoStreamAdded(new VideoStream(remoteParticipant, remoteVideoStream));
                }
            }
            if (VideoEnabled)
                _call.StartVideo(_localVideoStream, OnVideoStarted);

        }

        public Task InitializeConference(AzureSetupRoom azureSetupRoom)
        {
            var audioOptions = new ACSAudioOptions();
            var callOptions = new ACSJoinCallOptions();
            callOptions.AudioOptions = audioOptions;
            var callOptionsACSS = new ACSStartCallOptions();
            callOptionsACSS.AudioOptions = audioOptions;
            audioOptions.Muted = azureSetupRoom.MicrophoneEnabled;
            var callees = new List<CommunicationIdentifier>();
            var acsNumber = new PhoneNumberIdentifier[] { new PhoneNumberIdentifier(azureSetupRoom.CodeMeeting, azureSetupRoom.CodeMeeting) };
            callees.Add(new CommunicationUserIdentifier(azureSetupRoom.CodeMeeting));
            if (_deviceManager.Cameras.Count() > 0)
            {
                switch (CurrentCamera = azureSetupRoom.SelectedCamera)
                {
                    case SelectedCamera.Front:
                        _videoDeviceInfo = _deviceManager.Cameras.First(c => c.CameraFacing == ACSCameraFacing.Front);
                        break;
                    case SelectedCamera.Back:
                        _videoDeviceInfo = _deviceManager.Cameras.First(c => c.CameraFacing == ACSCameraFacing.Front);
                        break;
                }

                VideoEnabled = azureSetupRoom.VideoEnabled;
                if (azureSetupRoom.VideoEnabled)
                {
                    _localVideoStream = new ACSLocalVideoStream(_videoDeviceInfo);
                    _previewRenderer = new ACSVideoStreamRenderer(_localVideoStream, out var rendererError);
                    ThrowIfError(rendererError);
                    var video = new ACSVideoOptions(new[] { _localVideoStream });
                    callOptionsACSS.VideoOptions = video;
                    callOptions.VideoOptions = video;
                }
            }
            switch (azureSetupRoom.TypeCall)
            {
                case TypeCall.Teams:
                    ACSTeamsMeetingLinkLocator aCSJoinMeetingLocator = new ACSTeamsMeetingLinkLocator(azureSetupRoom.CodeMeeting);
                    _callAgent.JoinWithMeetingLocator(aCSJoinMeetingLocator, callOptions, CallCompleted);
                    break;
                case TypeCall.Group:
                    var groupCallLocator = new ACSGroupCallLocator(new NSUuid(azureSetupRoom.CodeMeeting));
                    _callAgent.JoinWithMeetingLocator(groupCallLocator, callOptions, CallCompleted);
                    break;
                case TypeCall.Direct:
                    _callAgent.StartCall(callees.ToArray(), callOptionsACSS, CallCompleted);
                    break;
                case TypeCall.PSTN:
                    _callAgent.StartCall(callees.ToArray(), callOptionsACSS, CallCompleted);
                    break;
                case TypeCall.Bot:
                    callees.Add(new CommunicationUserIdentifier("8:echo123"));
                    _callAgent.StartCall(callees.ToArray(), callOptionsACSS, CallCompleted);
                    break;
                default:
                    break;
            }
            return Task.CompletedTask;
        }
        void OnVideoStarted(NSError error)
        {
            LoggerService.Debug("Video started");
            if (error != null) throw new Exception(error.Description);

        }
        public async void StartScreensharing() 
        {

            options = CreateRawOutgoingVideoStreamOptions();
            screenShareRawOutgoingVideoStream = new ACSScreenShareRawOutgoingVideoStream(options);


            var recorder = RPScreenRecorder.SharedRecorder;
            recorder.MicrophoneEnabled = false;
            recorder.CameraEnabled = false;
            if (recorder.Available)
                await recorder.StartCaptureAsync(async (buffer, rPSampleBufferType, error) =>
                {

                    if (error != null)
                    {
                        return;
                    }

                    switch (rPSampleBufferType)
                    {
                        case RPSampleBufferType.Video:
                            if (ScreenSharingDelegate.aCSVideoFrameSender != null)
                            {
                                if (outgoingVideoStreamState == ACSOutgoingVideoStreamState.Started)
                                {
                                    DispatchQueue.GetGlobalQueue(DispatchQueuePriority.Default).DispatchAsync(() =>
                                    {
                                        DispatchQueue.MainQueue.DispatchAsync(() =>
                                        {
                                            if (buffer != null)
                                            {
                                                recursiveLock.Lock();

                                                var frameBuffer = buffer.GetImageBuffer();
                                                ACSSoftwareBasedVideoFrameSender sender = (ACSSoftwareBasedVideoFrameSender)ScreenSharingDelegate.aCSVideoFrameSender;
                                                var timeStamp = sender.TimestampInTicks;
                                                if (frameBuffer != null)
                                                {
                                                    sender.SendFrame(frameBuffer, timeStamp, SendFrameCallBack);

                                                }
                                                buffer.Dispose();
                                                recursiveLock.Unlock();

                                            }
                                        });
                                    });



                                }
                            }
                            break;
                        case RPSampleBufferType.AudioApp:
                            break;
                        case RPSampleBufferType.AudioMic:
                            break;
                        default:
                            break;
                    }
                });


            #region Screensharing background await next version
            //var bundle = NSBundle.MainBundle.GetUrlForResource("TestSample.iOS.ScreensharingExtension", "appex", "PlugIns");

            //var frame = new CGRect(0, 0, 100, 100);
            //var broadcastPicker = new RPSystemBroadcastPickerView(frame);
            //var bundle2 = new NSBundle(bundle);
            //broadcastPicker.ShowsMicrophoneButton = false;
            //broadcastPicker.Hidden = false;
            //broadcastPicker.PreferredExtension = bundle2.BundleIdentifier;
            //var viewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
            //viewController.ModalInPopover = true;
            //viewController.View.Add(broadcastPicker); 
            #endregion
            _call.StartVideo(screenShareRawOutgoingVideoStream, OnVideoStarted);
        }
        public void StartCamera()
        {
            var cameras = _deviceManager.Cameras.FirstOrDefault();
            if (cameras != null)
            {
                _localVideoStream = new ACSLocalVideoStream(_videoDeviceInfo);
                _previewRenderer = new ACSVideoStreamRenderer(_localVideoStream, out var rendererError);
                ThrowIfError(rendererError);
                LocalVideoAdded?.Invoke(this, ShowPreview());
                _call.StartVideo(_localVideoStream, MutedUnMutedVoid());
            }
        }
        public View ShowPreview()
        {
            if (_previewRenderer != null)
            {
                _preview = _previewRenderer.CreateViewWithOptions(new ACSCreateViewOptions(ACSScalingMode.Crop), out var createViewError);
                ThrowIfError(createViewError);
                return _preview.ToView();
            }
            else return null;

        }
        public void RetrieveCameraPreview()
        {
            var cameras = _deviceManager.Cameras.FirstOrDefault();
            if (cameras != null)
            {
                LocalVideoAdded?.Invoke(this, ShowPreview());
            }
        }
        public async void LoadServerCallId()
        {
            _call.Info.GetServerCallIdWithCompletionHandler(ServerCallIdCallback);
        }
        public Task<string> GetServerCallId()
        {
            LoadServerCallId();
            return Task.FromResult(ServerCallId);
        }
        public void ServerCallIdCallback(NSString nSString, NSError nsError)
        {
            if (nsError != null)
                ServerCallId = null;
            else
                ServerCallId = nSString.ToString();
        }
        public void StopScreensharing()
        {
            StopRecording();
            _call.StopVideo(screenShareRawOutgoingVideoStream, OnVideoStarted);
        }
        public void StopCamera()
        {
            try
            {
                _previewRenderer?.Dispose();
                _previewRenderer = null;
                _preview = null;
                LocalVideoAdded?.Invoke(this, null);
            }
            catch (Exception ex)
            {
                new ConferenceExceptions(ex);
            }
            LocalVideoAdded?.Invoke(this, null);
            _call.StopVideo(_localVideoStream, StopVideo);
        }
        public void SwitchCamera()
        {
            ACSCameraFacing SwitchCurrentCamera = ACSCameraFacing.Unknown;
            switch (CurrentCamera)
            {
                case SelectedCamera.Front:
                    SwitchCurrentCamera = ACSCameraFacing.Back;
                    CurrentCamera = SelectedCamera.Back;
                    break;
                case SelectedCamera.Back:
                    SwitchCurrentCamera = ACSCameraFacing.Front;
                    CurrentCamera = SelectedCamera.Front;
                    break;
            }
            var switchCurrentCamera = _deviceManager.Cameras.FirstOrDefault(c => c.CameraFacing == SwitchCurrentCamera);

            if (switchCurrentCamera != null)
            {
                void SwtichCameraCompleted(NSError onSwtichCameraError)
                {
                    if (onSwtichCameraError != null)
                    {
                    }

                    return;
                }
                _localVideoStream.SwitchSource(switchCurrentCamera, SwtichCameraCompleted);
            }

        }
        void StopVideo(NSError action)
        {

        }
       
        public void toggleSendingScreenShareOutgoingVideo()
        {
            var sendingScreenShare = false;
            if (sendingScreenShare)
            {

            }
        }
        private ACSRawOutgoingVideoStreamOptions CreateRawOutgoingVideoStreamOptions()
        {

            var videoFormats = new List<ACSVideoFormat>();
            var videoFormat = new ACSVideoFormat();
            videoFormat.Width = (int)UIScreen.MainScreen.NativeBounds.Width;
            videoFormat.Height = (int)UIScreen.MainScreen.NativeBounds.Height;
            videoFormat.PixelFormat = ACSPixelFormat.Nv12;
            videoFormat.VideoFrameKind = ACSVideoFrameKind.VideoSoftware;
            videoFormat.FramesPerSecond = 30;
            videoFormat.Stride1 = (int)UIScreen.MainScreen.NativeBounds.Width;
            videoFormat.Stride2 = (int)UIScreen.MainScreen.NativeBounds.Width;
            videoFormats.Add(videoFormat);

            ACSRawOutgoingVideoStreamOptions options = new ACSRawOutgoingVideoStreamOptions();
            options.VideoFormats = videoFormats.ToArray();
            options.Delegate = new ScreenSharingDelegate(_videoCallbackManager);

            return options;
        }
        private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
       
        public CVImageBuffer NextFrame(CMSampleBuffer cMSampleBuffer)
        {
            return cMSampleBuffer.GetImageBuffer();
        }
        public void SendFrameCallBack(ACSFrameConfirmation aCSFrameConfirmation, NSError nSError)
        {

        }
        public async void StopRecording()
        {
            if (RPScreenRecorder.SharedRecorder.Recording)
            {
            }
            else
            {
            }
            await RPScreenRecorder.SharedRecorder.StopCaptureAsync();
        }
        public void OnReadyCallback()
        {
        }
        public void Hangup()
        {

            if (_call != null)
            {
                _previewRenderer?.Dispose();
                _previewRenderer = null;
                _preview = null;
                _localVideoStream?.Dispose();
                _localVideoStream = null;
                _call?.HangUp(new ACSHangUpOptions(), OnVideoHangup);
                _call?.Dispose();
                _call = null;
                StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.Disconnected));
            }
        }

        private void OnVideoHangup(NSError nsError)
        {
            if (nsError != null)
            {
                throw new Exception(nsError.ToString());
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
        public Task<bool> InCall() => Task.FromResult(_call != null ? true : false);

        public async Task AcceptAsync()
        {
            ACSAcceptCallOptions aCSAcceptCallOptions = new ACSAcceptCallOptions();
            _incomingCall.Accept(aCSAcceptCallOptions, IncommingCallbackAccept);
        }
        public void IncommingCallbackAccept(ACSCall aCSCall, NSError obj)
        {
            _call = aCSCall;
        }
        public Task RejectAsync()
        {
            _incomingCall.RejectWithCompletionHandler(IncommingCallbackReject);
            return Task.CompletedTask;

        }

        private void IncommingCallbackReject(NSError nSError)
        {

        }

    }
    public class VideoStream
    {
        public VideoStream(ACSRemoteParticipant remoteParticipant, ACSRemoteVideoStream remoteVideoStream)
        {
            RemoteParticipant = remoteParticipant;
            RemoteVideoStream = remoteVideoStream;
        }
        public ACSRemoteParticipant RemoteParticipant { get; set; }
        public ACSRemoteVideoStream RemoteVideoStream { get; set; }
    }
    public class FrameProducerProtocol
    {
        public FrameProducerProtocol()
        {
        }
        public FrameProducerProtocol(ACSVideoFormat aCSVideoFormat)
        {
        }
    }
    public class ScreenSharingProducer : NSObject, IRPScreenRecorderDelegate
    {

    }
   
    public class RawOutgoingVideoSender : ACSRawOutgoingVideoStreamOptionsDelegate
    {
        public RawOutgoingVideoSender() { }
    }
    public class RPBroadcastSampleHandler2 : RPBroadcastSampleHandler
    {
        public override void ProcessSampleBuffer(CoreMedia.CMSampleBuffer sampleBuffer, RPSampleBufferType sampleBufferType)
        {
            switch (sampleBufferType)
            {
                case RPSampleBufferType.Video:
                    break;
                case RPSampleBufferType.AudioApp:
                    break;
                case RPSampleBufferType.AudioMic:
                    break;
            }
        }
        public override void BroadcastPaused()
        {
            Console.WriteLine("BroadcastPaused");
        }

        public override void BroadcastResumed()
        {
            Console.WriteLine("BroadcastResumed");
        }

        public override void BroadcastFinished()
        {
            Console.WriteLine("BroadcastFinished");
        }
    }
}