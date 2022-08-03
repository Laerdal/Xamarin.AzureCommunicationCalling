using Azure.Communication;
using Azure.Communication.Calling;
using Azure.WinRT.Communication;
using AzureSample.Enums;
using AzureSample.Interfaces;
using AzureSample.Model;
using AzureSample.UWP.Implementations;
using AzureSample.UWP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;


namespace AzureSample.UWP.Implementations
{
    public class ConferenceManagerSpecificPlatformWindows : IConferenceManagerSpecificPlatform
    {
        private CallAgent _callAgent;
        private CallClient _callClient;
        private DeviceManager _deviceManager;
        private LocalVideoStream[] _localVideoStream;
        private MediaElement mediaElement;
        private Call _call;
        private List<RemoteParticipant> _remoteParticipants = new List<RemoteParticipant>();
        public event EventHandler<ParticipantVideoStatusChangedArgs> RemoteVideoRemoved;
        public event EventHandler<ParticipantVideoStatusChangedArgs> RemoteVideoAdded;
        public event EventHandler<ParticipantJoinArgs> ParticipantJoined;
        public event EventHandler<ParticipantLeftArgs> ParticipantLeft;
        public event EventHandler<ParticipantMicrophoneStatusChangedArgs> ParticipantMicrophoneStatusChanged;
        public event EventHandler<ConferenceStateChangedEnventArgs> StateChanged;
        public event EventHandler<ParticipantSpeakingStatusChangedArgs> SpeakingChanged = delegate { };

        private readonly List<RemoteVideoStream> _remoteVideoStreams;
        private IncomingCall _incomingCall;
        public bool MicrophoneMute => _call.IsMuted;
        private bool isSpeakerOn;
        public string DisplayName { get; set; }
        public DateTime? ConnectingStart { get; private set; }
        public DateTime? ConnectionStart { get; set; }
        public ConferenceState State => _call != null && _call.State == CallState.Connected ? ConferenceState.Connected : ConferenceState.Disconnected;
        public bool Initialized { get; private set; } = false;
        public bool SpeakerOn
        {
            get
            {
                return SpeakerOn;
            }
            set
            {
                SpeakerOn = value;
            }
        }
        public Task<bool> InCall()
        {
            return Task.FromResult(_call != null ? true : false);
        }
        public async void Muted()
        {
            if (_call != null)
            {
                await _call.Mute();
            }
        }
        public async void UnMuted()
        {
            if (_call != null)
            {
                await _call.Unmute();
            }
        }
        public async Task<bool> MuteUnMuted()
        {
            if (_call != null)
            {
                if (_call.IsMuted)
                    await _call.Unmute();
                else
                    await _call.Mute();
                return _call.IsMuted;
            }
            return false;
        }
        [Xamarin.Forms.Internals.Preserve]
        public ConferenceManagerSpecificPlatformWindows()
        {
            _remoteVideoStreams = new List<RemoteVideoStream>();
        }
        public string CodeConference()
        {
            return _call.Id;
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
        public async Task<bool> Init(string token, string name)
        {
            try
            {
                global::Azure.WinRT.Communication.CommunicationTokenCredential token_credential = new global::Azure.WinRT.Communication.CommunicationTokenCredential(token);
                CallClient callClient = new CallClient();
                _deviceManager = await callClient.GetDeviceManager();
                CallAgentOptions callAgentOptions = new CallAgentOptions()
                {
                    DisplayName = DisplayName = name
                };
                _callAgent = await callClient.CreateCallAgent(token_credential, callAgentOptions);
                _callAgent.OnIncomingCall += CallAgent_OnIncomingCall;
                _callAgent.OnCallsUpdated += CallAgent_OnCallsUpdated;

                return Initialized = true;
            }
            catch (Exception ex)
            {
                new ConferenceExceptions(ex);
                return Initialized = false;
            }
        }
        public void AddParticipants(string[] participantIds)
        {
            foreach (var item in participantIds)
            {
                _call.AddParticipant(new Azure.WinRT.Communication.CommunicationUserIdentifier(item));

            }
        }
        private void CallAgent_OnCallsUpdated(object sender, CallsUpdatedEventArgs args)
        {
            foreach (var call in args.AddedCalls)
            {
                call.OnRemoteParticipantsUpdated += Call_RemoteParticipantsUpdated;
                call.OnStateChanged += Call_StateChanged;
            }
        }

        private void CallAgent_OnIncomingCall(object sender, IncomingCall incomingCall)
        {
            _incomingCall = incomingCall;
            //_incomingCall.OnCallEnded += IncomingCall_OnCallEnded;
        }

        public async Task AcceptAsync()
        {
            var acceptCallOptions = new AcceptCallOptions();
            await Task.Delay(2000);
            _call = await _incomingCall.AcceptAsync(acceptCallOptions);
            _call.OnRemoteParticipantsUpdated += Call_RemoteParticipantsUpdated;
            _call.OnIsMutedChanged += Call_OnIsMutedChanged;
            _call.OnStateChanged += Call_StateChanged;
        }

        private void IncomingCall_OnCallEnded(object sender, PropertyChangedEventArgs args)
        {            
        }

        public async Task RejectAsync()
        {
            await _incomingCall.RejectAsync();
        }
        private void Call_StateChanged(object sender, PropertyChangedEventArgs e)
        {
            var stateConference = ((Call)sender).State;
            switch (stateConference)
            {
                case CallState.None:
                    StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.Unset));
                    break;
                case CallState.EarlyMedia:
                    break;
                case CallState.Connecting:
                    StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.Connecting));
                    break;
                case CallState.Ringing:
                    break;
                case CallState.Connected:
                    StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.Connected));
                    break;
                case CallState.LocalHold:
                    break;
                case CallState.Disconnecting:
                    StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.Disconnecting));
                    break;
                case CallState.Disconnected:
                    StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.Disconnected));
                    break;
                case CallState.InLobby:
                    StateChanged?.Invoke(this, new ConferenceStateChangedEnventArgs(ConferenceState.InLobby));
                    break;
                case CallState.RemoteHold:
                    break;
                default:
                    break;
            }
        }
        public async Task InitializeConference(AzureSetupRoom azureSetupRoom)
        {
            try
            {
                JoinCallOptions joinCallOptions = new JoinCallOptions();
                StartCallOptions startCallOptions = new StartCallOptions();
                var AudioOptions = new AudioOptions();
                AudioOptions.Muted = azureSetupRoom.MicrophoneEnabled;
                startCallOptions.AudioOptions = AudioOptions;
                joinCallOptions.AudioOptions = AudioOptions;

                var callees = new List<ICommunicationIdentifier>();
                var acsNumber = new Azure.WinRT.Communication.PhoneNumberIdentifier[] { new Azure.WinRT.Communication.PhoneNumberIdentifier(azureSetupRoom.CodeMeeting) };
                if (_deviceManager.Cameras.Count > 0)
                {
                    VideoDeviceInfo videoDeviceInfo = _deviceManager.Cameras[0];
                    _localVideoStream = new LocalVideoStream[1];
                    _localVideoStream[0] = new LocalVideoStream(videoDeviceInfo);
                    if (azureSetupRoom.VideoEnabled)
                    {
                        var video = new VideoOptions(_localVideoStream);
                        startCallOptions.VideoOptions = video;
                        joinCallOptions.VideoOptions = video;
                    }
                }
                switch (azureSetupRoom.TypeCall)
                {
                    case TypeCall.Teams:
                        TeamsMeetingLinkLocator teamsMeetingLinkLocator = new TeamsMeetingLinkLocator(azureSetupRoom.CodeMeeting);
                        _call = await _callAgent.JoinAsync(teamsMeetingLinkLocator, joinCallOptions);
                        break;
                    case TypeCall.Group:
                        var code = new Guid(azureSetupRoom.CodeMeeting);
                        GroupCallLocator groupmeetinglocator = new GroupCallLocator(code);
                        _call = await _callAgent.JoinAsync(groupmeetinglocator, joinCallOptions); break;
                    case TypeCall.Direct:
                        callees.Add(new Azure.WinRT.Communication.CommunicationUserIdentifier(azureSetupRoom.CodeMeeting));
                        _call = await _callAgent.StartCallAsync(callees, startCallOptions);
                        break;
                    case TypeCall.PSTN:
                        _call = await _callAgent.StartCallAsync(acsNumber, startCallOptions);
                        break;
                    case TypeCall.Bot:
                        callees.Add(new Azure.WinRT.Communication.CommunicationUserIdentifier("8:echo123"));
                        _call = await _callAgent.StartCallAsync(callees, startCallOptions);
                        break;
                    default:
                        break;
                }
                _call.OnRemoteParticipantsUpdated += Call_RemoteParticipantsUpdated;
                _call.OnIsMutedChanged += Call_OnIsMutedChanged;
                _call.OnStateChanged += Call_StateChanged;
            }
            catch (Exception ex)
            {
                new ConferenceExceptions(ex);
            }

        }

        private void Call_OnIsMutedChanged(object sender, PropertyChangedEventArgs args)
        {
            var stateConference = ((Call)sender);
            ParticipantMicrophoneStatusChanged?.Invoke(this, new ParticipantMicrophoneStatusChangedArgs(DisplayName, stateConference.IsMuted));
        }

        private void Call_RemoteParticipantsUpdated(object sender, ParticipantsUpdatedEventArgs e)
        {
            foreach (var participantAdded in e.AddedParticipants)
            {
                _remoteParticipants.Add(participantAdded);

                ParticipantJoined?.Invoke(this, new ParticipantJoinArgs(CommunicationIdentifierExtension.IdentifierExtension(participantAdded), participantAdded.DisplayName));
                ParticipantMicrophoneStatusChanged?.Invoke(this, new ParticipantMicrophoneStatusChangedArgs(CommunicationIdentifierExtension.IdentifierExtension(participantAdded), participantAdded.IsMuted));
                participantAdded.OnIsMutedChanged += ParticipantAdded_OnIsMutedChanged;
                participantAdded.OnIsSpeakingChanged += ParticipantAdded_OnIsSpeakingChanged;
                participantAdded.OnStateChanged += ParticipantAdded_OnStateChanged;
                participantAdded.OnVideoStreamsUpdated += RemoteVideoStreamsUpdated;
                foreach (var videoStream in participantAdded.VideoStreams)
                {
                    if (videoStream.IsAvailable) PublishRemoteVideoStream(participantAdded, videoStream);
                }
            }
            foreach (var participantRemoved in e.RemovedParticipants)
            {
                _remoteParticipants.Remove(participantRemoved);
                ParticipantMicrophoneStatusChanged?.Invoke(this, new ParticipantMicrophoneStatusChangedArgs(CommunicationIdentifierExtension.IdentifierExtension(participantRemoved), participantRemoved.IsMuted));
                ParticipantLeft?.Invoke(this, new ParticipantLeftArgs(CommunicationIdentifierExtension.IdentifierExtension(participantRemoved), participantRemoved.DisplayName));
            }
        }

        private void ParticipantAdded_OnStateChanged(object sender, PropertyChangedEventArgs args)
        {
        }

        private void ParticipantAdded_OnIsSpeakingChanged(object sender, PropertyChangedEventArgs args)
        {
            var participantAdded = ((RemoteParticipant)sender);
            SpeakingChanged?.Invoke(this, new ParticipantSpeakingStatusChangedArgs(CommunicationIdentifierExtension.IdentifierExtension(participantAdded), participantAdded.IsMuted, participantAdded.IsSpeaking));
        }

        private void ParticipantAdded_OnIsMutedChanged(object sender, PropertyChangedEventArgs args)
        {
            var stateConference = ((RemoteParticipant)sender);
            ParticipantMicrophoneStatusChanged?.Invoke(this, new ParticipantMicrophoneStatusChangedArgs(CommunicationIdentifierExtension.IdentifierExtension(stateConference), stateConference.IsMuted));
        }

        private void RemoteVideoStreamsUpdated(object sender, RemoteVideoStreamsEventArgs e)
        {
            if (sender != null)
            {
                if (sender is RemoteParticipant remoteParticipant)
                {
                    foreach (var v in e.AddedRemoteVideoStreams)
                    {
                        if (v.IsAvailable) PublishRemoteVideoStream(remoteParticipant, v);
                    }
                    foreach (var v in e.RemovedRemoteVideoStreams)
                    {
                        RemoveRemoteVideoStream(remoteParticipant, v);
                        remoteParticipant.OnVideoStreamsUpdated += RemoteVideoStreamsUpdated;
                    }
                }
            }

        }
        private async void RemoveRemoteVideoStream(RemoteParticipant remoteParticipant, RemoteVideoStream remoteVideoStream)
        {
            await global::Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(global::Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                var RemoteVideo = new MediaElement();

                _remoteVideoStreams.Add(remoteVideoStream);
                List<FrameworkElement> controls = new List<FrameworkElement>();
                controls.Add(RemoteVideo);
                var video = controls.FirstOrDefault();
                var renderingOptions = new CreateViewOptions(ScalingMode.Crop);
                var formsView = video.ToView();
                RemoteVideoRemoved?.Invoke(this, new ParticipantVideoStatusChangedArgs(CommunicationIdentifierExtension.IdentifierExtension(remoteParticipant), remoteParticipant.IsMuted, formsView));

            });
        }
        private async void PublishRemoteVideoStream(RemoteParticipant remoteParticipant, RemoteVideoStream remoteVideoStream)
        {

            await global::Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(global::Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                var RemoteVideo = new MediaElement();
                var remoteUri = await remoteVideoStream.Start();
                RemoteVideo.Source = remoteUri;
                RemoteVideo.Play();
                _remoteVideoStreams.Add(remoteVideoStream);
                List<FrameworkElement> controls = new List<FrameworkElement>();
                controls.Add(RemoteVideo);
                var video = controls.FirstOrDefault();
                var renderer = remoteUri;

                var renderingOptions = new CreateViewOptions(ScalingMode.Crop);
                var formsView = video.ToView();
                RemoteVideoAdded?.Invoke(this, new ParticipantVideoStatusChangedArgs(CommunicationIdentifierExtension.IdentifierExtension(remoteParticipant), remoteParticipant.IsMuted, formsView));
            });
        }

        public async void Hangup()
        {
            if (_call != null)
            {
                await _call.HangUpAsync(new HangUpOptions());
                _localVideoStream = null;
                _remoteVideoStreams.Clear();
                _call = null;
            }
        }
        public void StartScreensharing()
        { }
        public async void StartVideo()
        {
            await global::Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(global::Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                var video = _localVideoStream[0];
                await _call.StartVideo(video);
            });
        }
        public void StopScreensharing() { }
        public async Task<string> GetServerCallId()
        {
            return await _call.Info.GetServerCallIdAsync(); 
        }

        public async void StopVideo()
        {
            await global::Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(global::Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                var video = _localVideoStream[0];
                await _call.StopVideo(video);
            });
        }
    }
}

