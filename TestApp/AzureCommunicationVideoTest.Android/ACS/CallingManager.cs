using System;
using System.Threading.Tasks;
using Com.Azure.Android.Communication.Common;
using Xamarin.Forms;
using Com.Azure.Communication.Calling;
using Application = Android.App.Application;
using Java.Util;
using Java.Util.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms.Platform.Android;
using CameraFacing = Com.Azure.Communication.Calling.CameraFacing;

[assembly: Dependency(typeof(AzureCommunicationVideoTest.Droid.ACS.CallingManager))]
namespace AzureCommunicationVideoTest.Droid.ACS
{
    public class CallingManager : IACSCallingManager
    {
        private CallAgent _callAgent;
        private CallClient _callClient;
        private DeviceManager _deviceManager;
        private LocalVideoStream _localVideoStream;
        private Renderer _localRenderer;
        private readonly List<RemoteVideoStream> _remoteVideoStreams;
        private Call _call;

        public CallingManager()
        {
            _remoteVideoStreams = new List<RemoteVideoStream>();
        }

        public async Task<bool> Init(string token)
        {
            var credentials = new CommunicationTokenCredential(token);
            _callClient = new CallClient();
            _callAgent = (CallAgent) await _callClient.CreateCallAgent(Application.Context, credentials).GetAsync();
            _deviceManager = (DeviceManager) await _callClient.DeviceManager.GetAsync();
            return true;
        }

        public Task JoinGroup(Guid groupID)
        {
            var groupCallLocator = new GroupCallLocator(UUID.FromString(groupID.ToString()));
            var joinCallOptions = new JoinCallOptions();
            joinCallOptions.AudioOptions = new AudioOptions();
            var camera = _deviceManager.CameraList.First(c => c.CameraFacing == CameraFacing.Front);
            _localVideoStream = new LocalVideoStream(camera, MainActivity.Instance);
            _localRenderer = new Renderer(_localVideoStream, MainActivity.Instance);
            var renderingOptions = new RenderingOptions(ScalingMode.Crop);
            var nativeView = _localRenderer.CreateView(renderingOptions);
            var formsView = nativeView.ToView();
            LocalVideoAdded?.Invoke(this, formsView);
            joinCallOptions.VideoOptions = new VideoOptions(_localVideoStream);
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
            var renderer = new Renderer(v, MainActivity.Instance);
            var renderingOptions = new RenderingOptions(ScalingMode.Crop);
            var nativeView = renderer.CreateView(renderingOptions);
            var formsView = nativeView.ToView();
            RemoteVideoAdded?.Invoke(this, formsView);
        }

        public void Hangup()
        {
            _call.RemoteParticipantsUpdated -= _call_RemoteParticipantsUpdated;
            var hangupOptions = new HangupOptions();
            _call.Hangup(hangupOptions).Get();
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
            var camera = _deviceManager.CameraList.First(c => c.CameraFacing == CameraFacing.Front);

            callOptions.AudioOptions = new AudioOptions();

            //callOptions.AudioOptions.Muted = true;
            var localVideoStream = new LocalVideoStream(camera, MainActivity.Instance);
            callOptions.VideoOptions = new VideoOptions(localVideoStream);

            var receivers = new CommunicationIdentifier[] { new CommunicationUserIdentifier("8:echo123") };

            _call = _callAgent.Call(MainActivity.Instance, receivers, callOptions);
        }

        public event EventHandler<View> LocalVideoAdded;
        public event EventHandler<View> RemoteVideoAdded;

        public void CallPhone(string phoneNumber)
        {
        }
    }
}
