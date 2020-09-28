using System;
using System.Threading.Tasks;
using Foundation;
using Xamarin.Forms;
using Xamarin.AzureCommunicationCalling.iOS;
using System.Linq;
using AzureCommunicationVideoTest.iOS.ACS;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(AzureCommunicationVideoTest.iOS.VideoCalling))]
namespace AzureCommunicationVideoTest.iOS
{
    public class VideoCalling : IVideoCalling
    {
        private ACSCallClient _callClient;
        private ACSDeviceManager _deviceManager;
        private ACSCallAgent _callAgent;
        private ACSCall _call;

        public Task<bool> Init(string token)
        {
            var _initTask = new TaskCompletionSource<bool>();
            _callClient = new ACSCallClient();

            void OnCallAgenttCreated(ACSCallAgent callAgent, NSError callAgentError)
            {
                if (callAgentError != null)
                {
                    _initTask.TrySetCanceled();
                    throw new Exception(callAgentError.Description);
                }
                _callAgent = callAgent;
                _callAgent.Delegate = new CallAgentDelegate();

                // Create device manager AFTER callagent
                void OnDeviceManagerCreated(ACSDeviceManager deviceManager, NSError deviceManagerError)
                {
                    if (deviceManagerError != null)
                    {
                        throw new Exception(deviceManagerError.Description);
                    }
                    _deviceManager = deviceManager;
                    _initTask.TrySetResult(true);
                }
                _callClient.GetDeviceManagerWithCompletionHandler(OnDeviceManagerCreated);
            }

            var credentials = new CommunicationUserCredential(token, out var nSError);
            if (nSError != null)
            {
                _initTask.TrySetCanceled();
                throw new Exception(nSError.Description);
            }
            _callClient.CreateCallAgent(credentials, OnCallAgenttCreated);

            return _initTask.Task;
        }

        public void CallEchoService()
        {
            var callOptions = new ACSStartCallOptions();
            var camera = _deviceManager.CameraList.FirstOrDefault(c => c.CameraFacing == ACSCameraFacing.Front);

            callOptions.AudioOptions = new ACSAudioOptions();

            //callOptions.AudioOptions.Muted = true;
            var localVideoStream = new ACSLocalVideoStream(camera);
            callOptions.VideoOptions = new ACSVideoOptions(localVideoStream);

            var receivers = new CommunicationIdentifier[] { new CommunicationUser("8:echo123") };

            _callAgent.Call(receivers, callOptions);
        }


        public View JoinGroup(Guid groupID)
        {
            //Log.Debug($"Starting group call: {groupID}");
            var groupCallContext = new ACSGroupCallContext();
            groupCallContext.GroupId = new NSUuid(groupID.ToString());
            var callOptions = new ACSJoinCallOptions();

            var camera = _deviceManager.CameraList.FirstOrDefault(c => c.CameraFacing == ACSCameraFacing.Front);

            callOptions.AudioOptions = new ACSAudioOptions();

            //callOptions.AudioOptions.Muted = true;
            var localVideoStream = new ACSLocalVideoStream(camera);
            callOptions.VideoOptions = new ACSVideoOptions(localVideoStream);
            var renderer = new ACSRenderer(localVideoStream);
            var renderingOptions = new ACSRenderingOptions(ACSScalingMode.Crop);
            var view = renderer.CreateView(renderingOptions);
            _call = _callAgent.JoinWithGroupCallContext(groupCallContext, callOptions);
            //_call.StartVideo(localVideoStream, OnVideoStarted);
            //Log.Debug($"Started group call: {groupID}");

            return new ContentView { Content = view.ToView() };
        }

        void OnVideoStarted(NSError error)
        {
            if (error != null) throw new Exception(error.Description);
            //Log.Debug($"Started local video");
        }
        
    }
}