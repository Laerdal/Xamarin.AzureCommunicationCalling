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

[assembly: Dependency(typeof(AzureCommunicationVideoTest.Droid.ACS.CallingManager))]
namespace AzureCommunicationVideoTest.Droid.ACS
{
    public class CallingManager : IACSCallingManager
    {
        private CallAgent _callAgent;
        private CallClient _callClient;
        private DeviceManager _deviceManager;
        private LocalVideoStream _localVideoStream;
        private VideoStreamRenderer _localRenderer;
        private readonly List<RemoteVideoStream> _remoteVideoStreams;
        private Call _call;

        public CallingManager()
        {
            _remoteVideoStreams = new List<RemoteVideoStream>();
        }

        public Task<bool> Init(string token)
        {
            var credentials = new CommunicationTokenCredential(token);
            _callClient = new CallClient();
            var callOptions = new CallAgentOptions();
            
            _callAgent = CallClientHelper.GetCallAgent(_callClient, Application.Context, credentials);
            _deviceManager = CallClientHelper.GetDeviceManager(_callClient, Application.Context);
            return Task.FromResult(true);
        }

        public Task JoinGroup(Guid groupID)
        {
            var camera = _deviceManager.Cameras.First(c => c.CameraFacing == CameraFacing.Front);
            _localVideoStream = new LocalVideoStream(camera, MainActivity.Instance);
            _localRenderer = new VideoStreamRenderer(_localVideoStream, MainActivity.Instance);
            var renderingOptions = new CreateViewOptions(ScalingMode.Crop);
            var nativeView = _localRenderer.CreateView(renderingOptions);
            var formsView = nativeView.ToView();
            LocalVideoAdded?.Invoke(this, formsView);
            var groupCallLocator = new GroupCallLocator(UUID.FromString(groupID.ToString()));
            var videoOptions = new VideoOptions(new LocalVideoStream[] { _localVideoStream });
            var joinCallOptions = new JoinCallOptions();
            joinCallOptions.SetVideoOptions(videoOptions);
            _call = _callAgent.Join(Application.Context, groupCallLocator, joinCallOptions);
            _call.RemoteParticipantsUpdated += _call_RemoteParticipantsUpdated;
            return Task.CompletedTask;
        }

        private void _call_RemoteParticipantsUpdated(object sender, ParticipantsUpdatedEventArgs e)
        {
            foreach (var participantAdded in e.P0.AddedParticipants)
            {
                participantAdded.VideoStreamsUpdated += RemoteVideoStreamsUpdated;
                //participantAdded.AddOnVideoStreamsUpdatedListener(this);

                foreach (var videoStream in participantAdded.VideoStreams)
                {
                    if (videoStream.IsAvailable) PublishRemoteVideoStream(videoStream);
                }
            }
            
        }

        private void RemoteVideoStreamsUpdated(object sender, RemoteVideoStreamsUpdatedEventArgs e)
        {
            foreach (var v in e.P0.AddedRemoteVideoStreams)
            {
                if (v.IsAvailable) PublishRemoteVideoStream(v);                
            }
        }

        private void PublishRemoteVideoStream(RemoteVideoStream v)
        {
            _remoteVideoStreams.Add(v);
            var renderer = new VideoStreamRenderer(v, MainActivity.Instance);
            var renderingOptions = new CreateViewOptions(ScalingMode.Crop);
            var nativeView = renderer.CreateView(renderingOptions);
            var formsView = nativeView.ToView();
            RemoteVideoAdded?.Invoke(this, formsView);
        }

        public void Hangup()
        {
            _call.RemoteParticipantsUpdated -= _call_RemoteParticipantsUpdated;
            CallClientHelper.HangUp(_call, new HangUpOptions());
            _localRenderer?.Dispose();
            _localRenderer = null;
            _localVideoStream?.Dispose();
            _localVideoStream = null;
            _remoteVideoStreams.Clear();
            _call.Dispose();
            _call = null;
        }

        public void CallEchoService()
        {
            var callOptions = new StartCallOptions();
            var camera = _deviceManager.Cameras.First(c => c.CameraFacing == CameraFacing.Front);

            callOptions.SetAudioOptions(new AudioOptions());

            //callOptions.AudioOptions.Muted = true;
            var localVideoStream = new LocalVideoStream(camera, MainActivity.Instance);
            callOptions.SetVideoOptions(new VideoOptions(new LocalVideoStream[] { localVideoStream }));

            var receivers = new CommunicationIdentifier[] { new CommunicationUserIdentifier("8:echo123") };
            // TODO:
            //_callAgent.StartCall();
            //var locator = new GroupCallLocator()
            //_call = _callAgent. Join(MainActivity.Instance, receivers, callOptions);
        }

        public event EventHandler<View> LocalVideoAdded;
        public event EventHandler<View> RemoteVideoAdded;

        public void CallPhone(string phoneNumber)
        {
        }

        public async Task SetupLocalVideo()
        {
            try
            {
                if (_deviceManager == null)
                {
                    _deviceManager = CallClientHelper.GetDeviceManager(_callClient, MainActivity.Instance);
                }

                // First cleanup existing local video
                _localRenderer?.Dispose();
                _localVideoStream?.Dispose();

                // A few times Ive seen that there is NOT a camera available at this time,
                // assume its still initializing, and just wait a little while
                if (_deviceManager.Cameras.All(c => c.CameraFacing != CameraFacing.Front))
                {
                    await Task.Delay(1_000);
                }

                var camera = _deviceManager.Cameras.First(c => c.CameraFacing == CameraFacing.Front);
                _localVideoStream = new LocalVideoStream(camera, MainActivity.Instance);
                _localRenderer = new VideoStreamRenderer(_localVideoStream, MainActivity.Instance);
                var renderingOptions = new CreateViewOptions(ScalingMode.Fit);
                var nativeView = _localRenderer.CreateView(renderingOptions);
                var formsView = nativeView.ToView();
            }
            catch (Exception)
            {
                //_logger.Error("Local video setup failed", e);
                throw;
            }
        }

    }
}
