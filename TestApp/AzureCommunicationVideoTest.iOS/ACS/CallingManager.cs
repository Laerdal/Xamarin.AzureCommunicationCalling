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
        private ACSRenderer _localVideoStreamRenderer;
        private readonly CallingCallbackManager _videoCallbackManager;
        private readonly List<ACSRemoteVideoStream> _remoteVideoStreams;

        public CallingManager()
        {
            _remoteVideoStreams = new List<ACSRemoteVideoStream>();
            _videoCallbackManager = new CallingCallbackManager(RemoteVideoStreamAdded);
        }

        private void RemoteVideoStreamAdded(ACSRemoteVideoStream remoteVideoStream)
        {
            _remoteVideoStreams.Add(remoteVideoStream);
            var renderer = new ACSRenderer(remoteVideoStream);
            var renderingOptions = new ACSRenderingOptions(ACSScalingMode.Crop);
            var nativeView = renderer.CreateView(renderingOptions);
            var formsView = nativeView.ToView();
            RemoteVideoAdded?.Invoke(this, formsView);
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

            var credentials = new CommunicationUserCredential(token, out var nSError);
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
            var camera = _deviceManager.CameraList.First(c => c.CameraFacing == ACSCameraFacing.Front);
            callOptions.AudioOptions = new ACSAudioOptions();

            //callOptions.AudioOptions.Muted = true;
            var localVideoStream = new ACSLocalVideoStream(camera);
            callOptions.VideoOptions = new ACSVideoOptions(localVideoStream);

            var receivers = new CommunicationIdentifier[] { new CommunicationUser("8:echo123") };

            _callAgent.Call(receivers, callOptions);
        }

        public event EventHandler<View> LocalVideoAdded = delegate {  };
        public event EventHandler<View> RemoteVideoAdded = delegate {  };

        public void CallPhone(string phoneNumber)
        {
            var acsNumber = new PhoneNumber(phoneNumber);
            var receivers = new CommunicationIdentifier[] { acsNumber };
            var callOptions = new ACSStartCallOptions
            {
                AudioOptions = new ACSAudioOptions()
            };
            _call = _callAgent.Call(receivers, callOptions);
        }


        public async Task JoinGroup(Guid groupID)
        {
            var camera = _deviceManager
                .CameraList.First(c => c.CameraFacing == ACSCameraFacing.Front);
            _localVideoStream = new ACSLocalVideoStream(camera);
            _localVideoStreamRenderer = new ACSRenderer(_localVideoStream);
            var renderingOptions = new ACSRenderingOptions(ACSScalingMode.Crop);
            var nativeView = _localVideoStreamRenderer.CreateView(renderingOptions);
            var formsView = nativeView.ToView();

            LocalVideoAdded?.Invoke(this, formsView);

            var groupCallContext = new ACSGroupCallContext {GroupId = new NSUuid(groupID.ToString())};
            var callOptions = new ACSJoinCallOptions
            {
                AudioOptions = new ACSAudioOptions(),
                VideoOptions = new ACSVideoOptions(_localVideoStream)
            };
            //callOptions.AudioOptions.Muted = true;
            _call = _callAgent.JoinWithGroupCallContext(groupCallContext, callOptions);
            _call.Delegate = new CallDelegate(_videoCallbackManager);

            _call.StartVideo(_localVideoStream, OnVideoStarted);
        }

        void OnVideoStarted(NSError error)
        {
            if (error != null) throw new Exception(error.Description);
        }

        public void Hangup()
        {
            _call?.Hangup(new ACSHangupOptions(), OnVideoHangup);
            _localVideoStreamRenderer?.Dispose();
            _localVideoStream?.Dispose();
            _localVideoStream = null;
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