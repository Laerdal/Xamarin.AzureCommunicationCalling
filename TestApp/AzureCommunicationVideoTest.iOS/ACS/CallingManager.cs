using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.AzureCommunicationCalling.iOS;
using System.Linq;

[assembly:Dependency(typeof(AzureCommunicationVideoTest.iOS.ACS.CallingManager))]
namespace AzureCommunicationVideoTest.iOS.ACS
{
    public class CallingManager : IACSCallingManager
    {
        private ACSCallClient _callClient;
        private ACSDeviceManager _deviceManager;
        private ACSCallAgent _callAgent;
        private ACSCall _call;
        private ACSLocalVideoStream _localVideoStream;
        private ACSVideoStreamRenderer _localVideoStreamRenderer;
        private readonly CallingCallbackManager _videoCallbackManager;
        private readonly List<ACSRemoteVideoStream> _remoteVideoStreams;

        public CallingManager()
        {
            _remoteVideoStreams = new List<ACSRemoteVideoStream>();
            _videoCallbackManager = new CallingCallbackManager(RemoteVideoStreamAdded);
        }

        private void RemoteVideoStreamAdded(ACSRemoteVideoStream remoteVideoStream)
        {
            Logger.Debug("RemoteVideoStreamAdded");
            if (!remoteVideoStream.IsAvailable)
            {
                return;
            }

            _remoteVideoStreams.RemoveAll(s => s.Id == remoteVideoStream.Id);

            _remoteVideoStreams.Add(remoteVideoStream);
            Logger.Debug("RemoteVideoStreamAdded: Creating renderer");
            var renderer = new ACSVideoStreamRenderer(remoteVideoStream, out var rendererError);
            ThrowIfError(rendererError);
            var renderingOptions = new ACSCreateViewOptions(ACSScalingMode.Crop);
            var nativeView = renderer.CreateViewWithOptions(renderingOptions, out var createViewError);
            Logger.Debug("RemoteVideoStreamAdded: Created renderer");
            ThrowIfError(createViewError);
            var formsView = nativeView.ToView();
            RemoteVideoAdded?.Invoke(this, formsView);
        }

        private void ThrowIfError(NSError rendererError)
        {
            if (!string.IsNullOrEmpty(rendererError?.Description))
            {
                Logger.Debug(rendererError.Description);
                throw new Exception(rendererError.Description);
            }
        }

        public Task<bool> Init(string token)
        {
            var initTask = new TaskCompletionSource<bool>();
            _callClient = new ACSCallClient();

            void OnCallAgenttCreated(ACSCallAgent callAgent, NSError callAgentError)
            {
                if (callAgentError != null)
                {
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
            }

            var credentials = new CommunicationTokenCredential(token, out var nSError);
            if (nSError != null)
            {
                initTask.TrySetCanceled();
                throw new Exception(nSError.Description);
            }
            _callClient.CreateCallAgent(credentials, OnCallAgenttCreated);

            return initTask.Task;
        }

        public void CallEchoService()
        {
            var callOptions = new ACSStartCallOptions();
            var camera = _deviceManager.Cameras.First(c => c.CameraFacing == ACSCameraFacing.Front);
            callOptions.AudioOptions = new ACSAudioOptions();

            //callOptions.AudioOptions.Muted = true;
            var localVideoStream = new ACSLocalVideoStream(camera);
            callOptions.VideoOptions = new ACSVideoOptions(new[] { localVideoStream });

            var receivers = new CommunicationIdentifier[] { new CommunicationUserIdentifier("8:echo123") };

            _callAgent.StartCall(receivers, callOptions, null);
        }

        public event EventHandler<View> LocalVideoAdded = delegate {  };
        public event EventHandler<View> RemoteVideoAdded = delegate {  };

        public void CallPhone(string phoneNumber)
        {
            var acsNumber = new PhoneNumberIdentifier(phoneNumber, phoneNumber);
            var receivers = new CommunicationIdentifier[] { acsNumber };
            var callOptions = new ACSStartCallOptions
            {
                AudioOptions = new ACSAudioOptions()
            };
            _callAgent.StartCall(receivers, callOptions, callCompleted);
        }

        private void callCompleted(ACSCall call, NSError err)
        {
            Logger.Debug("Call setup");
            _call = call;
            // Respond to changes
            _call.Delegate = new CallDelegate(_videoCallbackManager);
            // Setup initial streams. This is clumsy and probably an API flaw...
            // IMHO delegate should be called after setting it on existing state...
            foreach (var remoteParticipant in _call.RemoteParticipants)
            {
                Logger.Debug("Remote participant already in call");
                remoteParticipant.Delegate = new RemoteParticipantDelegate(_videoCallbackManager);
                foreach (var remoteVideoStream in remoteParticipant.VideoStreams)
                {
                    RemoteVideoStreamAdded(remoteVideoStream);
                }
            }

            Logger.Debug("Starting video");
            _call.StartVideo(_localVideoStream, OnVideoStarted);
        }

        public async Task JoinGroup(Guid groupID)
        {
            Logger.Debug("Setting up local video");
            var camera = _deviceManager
                .Cameras.First(c => c.CameraFacing == ACSCameraFacing.Front);
            _localVideoStream = new ACSLocalVideoStream(camera);
            _localVideoStreamRenderer = new ACSVideoStreamRenderer(_localVideoStream, out var rendererError);
            ThrowIfError(rendererError);
            var renderingOptions = new ACSCreateViewOptions(ACSScalingMode.Crop);
            var nativeView = _localVideoStreamRenderer.CreateViewWithOptions(renderingOptions, out var viewError);
            ThrowIfError(viewError);
            var formsView = nativeView.ToView();

            LocalVideoAdded?.Invoke(this, formsView);

            var groupCallLocator = new ACSGroupCallLocator(new NSUuid(groupID.ToString()));
            var callOptions = new ACSJoinCallOptions
            {
                AudioOptions = new ACSAudioOptions(),
                VideoOptions = new ACSVideoOptions(new [] { _localVideoStream })
            };
            
            Logger.Debug("Joining group");
            //callOptions.AudioOptions.Muted = true;
            _callAgent.JoinWithMeetingLocator(groupCallLocator, callOptions, callCompleted);
        }

        void OnVideoStarted(NSError error)
        {
            Logger.Debug("Video started");
            if (error != null) throw new Exception(error.Description);
        }

        public void Hangup()
        {
            
            Logger.Debug("Hanging up");
            _call?.HangUp(new ACSHangUpOptions(), OnVideoHangup);
            _localVideoStreamRenderer?.Dispose();
            _localVideoStream?.Dispose();
            _localVideoStream = null;
            _remoteVideoStreams.Clear();
            _call?.Dispose();
            Logger.Debug("Finished hanging up");
        }

        private void OnVideoHangup(NSError nsError)
        {
            if (nsError != null)
            {
                throw new Exception(nsError.ToString());
            }
        }
    }
}