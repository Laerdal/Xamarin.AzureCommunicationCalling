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
            if (!remoteVideoStream.IsAvailable ||
                _remoteVideoStreams.Any(s => s.Id == remoteVideoStream.Id))
            {
                return;
            }
            
            _remoteVideoStreams.Add(remoteVideoStream);
            Device.BeginInvokeOnMainThread(() =>
            {
                var renderer = new ACSVideoStreamRenderer(remoteVideoStream, out var rendererError);
                ThrowIfError(rendererError);
                var renderingOptions = new ACSRenderingOptions(ACSScalingMode.Crop);
                var nativeView = renderer.CreateViewWithOptions(renderingOptions, out var createViewError);
                ThrowIfError(createViewError);
                var formsView = nativeView.ToView();
                RemoteVideoAdded?.Invoke(this, formsView);
            });
        }

        private void ThrowIfError(NSError rendererError)
        {
            if (!string.IsNullOrEmpty(rendererError?.Description))
            {
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
            callOptions.VideoOptions = new ACSVideoOptions(localVideoStream);

            var receivers = new CommunicationIdentifier[] { new CommunicationUserIdentifier("8:echo123") };

            _callAgent.StartCall(receivers, callOptions);
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
            _call = _callAgent.StartCall(receivers, callOptions);
        }


        public async Task JoinGroup(Guid groupID)
        {
            var camera = _deviceManager
                .Cameras.First(c => c.CameraFacing == ACSCameraFacing.Front);
            _localVideoStream = new ACSLocalVideoStream(camera);
            _localVideoStreamRenderer = new ACSVideoStreamRenderer(_localVideoStream, out var rendererError);
            ThrowIfError(rendererError);
            var renderingOptions = new ACSRenderingOptions(ACSScalingMode.Crop);
            var nativeView = _localVideoStreamRenderer.CreateViewWithOptions(renderingOptions, out var viewError);
            ThrowIfError(viewError);
            var formsView = nativeView.ToView();

            LocalVideoAdded?.Invoke(this, formsView);

            var groupCallLocator = new ACSGroupCallLocator(new NSUuid(groupID.ToString()));
            var callOptions = new ACSJoinCallOptions
            {
                AudioOptions = new ACSAudioOptions(),
                VideoOptions = new ACSVideoOptions(_localVideoStream)
            };
            //callOptions.AudioOptions.Muted = true;
            _call = _callAgent.JoinWithMeetingLocator(groupCallLocator, callOptions);
            // Respond to changes
            _call.Delegate = new CallDelegate(_videoCallbackManager);
            // Setup initial streams. This is clumsy and probably an API flaw...
            // IMHO delegate should be called after setting it on existing state...
            foreach (var remoteParticipant in _call.RemoteParticipants)
            {
                remoteParticipant.Delegate = new RemoteParticipantDelegate(_videoCallbackManager);
                foreach (var remoteVideoStream in remoteParticipant.VideoStreams)
                {
                    RemoteVideoStreamAdded(remoteVideoStream);
                }
            }

            _call.StartVideo(_localVideoStream, OnVideoStarted);
        }

        void OnVideoStarted(NSError error)
        {
            if (error != null) throw new Exception(error.Description);
        }

        public void Hangup()
        {
            _call?.HangUp(new ACSHangUpOptions(), OnVideoHangup);
            _localVideoStreamRenderer?.Dispose();
            _localVideoStream?.Dispose();
            _localVideoStream = null;
            _remoteVideoStreams.Clear();
            _call?.Dispose();
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