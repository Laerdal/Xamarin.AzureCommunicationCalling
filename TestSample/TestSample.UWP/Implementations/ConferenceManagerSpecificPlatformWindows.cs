using Azure.Communication;
using Azure.Communication.Calling;
using Azure.WinRT.Communication;
using TestSample.Enums;
using TestSample.Interfaces;
using TestSample.Model;
using TestSample.UWP.Implementations;
using TestSample.UWP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using static Xamarin.Essentials.AppleSignInAuthenticator;
using Windows.Graphics.Capture;
using Microsoft.Graphics.Canvas;
using Windows.Graphics.DirectX;
using Windows.Graphics;
using Microsoft.Graphics.Canvas.UI.Composition;
using SkiaSharp;
using Windows.UI;
using Windows.UI.Composition;
using Windows.Security.Authorization.AppCapabilityAccess;
using System.IO;
using Windows.Foundation;
using Windows.Graphics.Imaging;
using System.Collections;
using Windows.Storage.Streams;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Graphics.DirectX.Direct3D11;
using Windows.Media.Capture;
using System.Runtime.InteropServices;
using Xamarin.Essentials;

namespace TestSample.UWP.Implementations
{
    public class ConferenceManagerSpecificPlatformWindows : IConferenceManagerSpecificPlatform
    {
        private CallAgent _callAgent;
        private CallClient _callClient;
        private DeviceManager _deviceManager;
        private LocalVideoStream[] _localVideoStream;
        private VideoDeviceInfo _videoDeviceInfo;
        private MediaElement mediaElement;
        private Call _call;
        public event EventHandler<View> LocalVideoAdded;
        public event EventHandler<ParticipantVideoStatusChangedArgs> RemoteVideoRemoved;
        public event EventHandler<ParticipantVideoStatusChangedArgs> RemoteVideoAdded;
        public event EventHandler<ParticipantJoinArgs> ParticipantJoined;
        public event EventHandler<ParticipantLeftArgs> ParticipantLeft;
        public event EventHandler<ParticipantMicrophoneStatusChangedArgs> ParticipantMicrophoneStatusChanged;
        public event EventHandler<ConferenceStateChangedEnventArgs> StateChanged;
        public event EventHandler<ParticipantSpeakingStatusChangedArgs> SpeakingChanged = delegate { };

        private OutgoingVideoStream videoOptions;
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
#if DEBUG
            // Force graphicscapture.dll.
            var picker = new GraphicsCapturePicker();
#endif
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
                    _videoDeviceInfo = _deviceManager.Cameras.First();
                    _localVideoStream = new LocalVideoStream[1];
                    _localVideoStream[0] = new LocalVideoStream(_videoDeviceInfo);
                    if (azureSetupRoom.VideoEnabled)
                    {
                        var video = new VideoOptions(_localVideoStream);
                        startCallOptions.VideoOptions = video;
                        joinCallOptions.VideoOptions = video;
                    }
                }
                else
                {
                    try
                    {
                        await Task.Delay(2000);
                        _videoDeviceInfo = _deviceManager.Cameras.First();
                        _localVideoStream = new LocalVideoStream[1];
                        _localVideoStream[0] = new LocalVideoStream(_videoDeviceInfo);
                        if (azureSetupRoom.VideoEnabled)
                        {
                            var video = new VideoOptions(_localVideoStream);
                            startCallOptions.VideoOptions = video;
                            joinCallOptions.VideoOptions = video;
                        }
                    }
                    catch (Exception ex)
                    {

                        new ConferenceExceptions(ex);
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
        {
            //wait for the next version
            //videoOptions = CreateVideoOptions(OutgoingVideoStreamKind.ScreenShare);
            //if (videoOptions != null && _call != null)
            //    await _call.StartVideo(videoOptions);
        }

        private RawOutgoingVideoStreamOptions CreateRawOutgoingVideoStreamOptions()
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            var width = 1280;
            var height = 720;
            var videoFormats = new List<VideoFormat>();
            VideoFormat videoFormat = new VideoFormat();
            videoFormat.Width = 1280;
            videoFormat.Height = 720;
            videoFormat.PixelFormat = PixelFormat.Rgba;
            videoFormat.VideoFrameKind = VideoFrameKind.VideoSoftware;
            videoFormat.FramesPerSecond = 30;
            videoFormat.Stride1 = width * 4;  
            videoFormats.Add(videoFormat);
            var options = new RawOutgoingVideoStreamOptions();
            options.SetVideoFormats(videoFormats.ToArray());
            options.OnVideoFrameSenderChanged += Options_OnVideoFrameSenderChanged1;
            return options;
        }
        private VideoFrameSender videoFrameSender = null;

        private void Options_OnVideoFrameSenderChanged1(object sender, VideoFrameSenderChangedEventArgs args)
        {
            videoFrameSender = args.VideoFrameSender;
        }

        private void Options_OnOutgoingVideoStreamStateChanged(object sender, OutgoingVideoStreamStateChangedEventArgs args)
        {
        }

        private void Options_OnVideoFrameSenderChanged(object sender, VideoFrameSenderChangedEventArgs args)
        {
            throw new NotImplementedException();
        }

        public static OutgoingVideoStreamState outgoingVideoStreamState = OutgoingVideoStreamState.None;
        private RawOutgoingVideoStreamOptions options;
        private OutgoingVideoStream outgoingVideoStream;
        private ScreenShareRawOutgoingVideoStream screenShareRawOutgoingVideoStream;

        private OutgoingVideoStream CreateVideoOptions(OutgoingVideoStreamKind outgoingVideoStreamKind)
        {
            options = CreateRawOutgoingVideoStreamOptions();

            if (outgoingVideoStreamKind == OutgoingVideoStreamKind.Virtual)
            {

                outgoingVideoStream = new VirtualRawOutgoingVideoStream(options);
            }
            else
            {

                outgoingVideoStream = screenShareRawOutgoingVideoStream = new ScreenShareRawOutgoingVideoStream(options);
                screenShareRawOutgoingVideoStream.OnOutgoingVideoStreamStateChanged += ScreenShareRawOutgoingVideoStream_OnOutgoingVideoStreamStateChanged;
            }

            return outgoingVideoStream;
        }

        private void ScreenShareRawOutgoingVideoStream_OnOutgoingVideoStreamStateChanged(object sender, OutgoingVideoStreamStateChangedEventArgs args)
        {
            switch (outgoingVideoStreamState = args.OutgoingVideoStreamState)
            {
                case OutgoingVideoStreamState.None:
                    break;
                case OutgoingVideoStreamState.Started:
                    break;
                case OutgoingVideoStreamState.Stopped:
                    break;
                case OutgoingVideoStreamState.Failed:
                    break;
                default:
                    break;
            }
        }

        //public async void SharingAudio()
        //{
        //wait for the next version
        //    RawOutgoingAudioProperties outgoingAudioOptions = new RawOutgoingAudioProperties(AudioSampleRate.SampleRate_48000, AudioChannelMode.ChannelMode_Stereo, AudioFormat.Pcm_16_Bit, OutgoingAudioMsOfDataPerBlock.Ms_20);
        //    RawIncomingAudioProperties rawIncomingAudioProperties = new RawIncomingAudioProperties(AudioSampleRate.SampleRate_48000, AudioChannelMode.ChannelMode_Stereo, AudioFormat.Pcm_16_Bit);
        //    RawOutgoingAudioStream outgoingAudioStream_ = new RawOutgoingAudioStream(outgoingAudioOptions);
        //    RawIncomingAudioStream rawIncomingAudioStream = new RawIncomingAudioStream(rawIncomingAudioProperties);
        //    OutgoingAudioBuffer outgoingAudioBuffer = new OutgoingAudioBuffer(outgoingAudioOptions);
        //    //outgoingAudioStream_.SendOutgoingAudioBuffer(outgoingAudioBuffer);
        //    //outgoingAudioStream_.OnAudioStreamReady += OutgoingAudioStream__OnAudioStreamReady;
        //    rawIncomingAudioStream.OnNewAudioBufferAvailable += RawIncomingAudioStream_OnNewAudioBufferAvailable;
        //    await _call.StartIncomingAudioStreamAsync(rawIncomingAudioStream);
        //}

        //private void RawIncomingAudioStream_OnNewAudioBufferAvailable(object sender, IncomingAudioEventArgs args)
        //{

        //}

        private void OutgoingAudioStream__OnAudioStreamReady(object sender, PropertyChangedEventArgs args)
        {

        }

        public async void StartCamera()
        {
            await global::Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(global::Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                try
                {                   
                    LocalVideoAdded.Invoke(this, await GetCameraViewAsync());
                    if (_localVideoStream[0] != null)
                        await _call.StartVideo(_localVideoStream[0]);
                }
                catch (Exception ex)
                {
                    new ConferenceExceptions(ex);
                }
            });
            await StartCaptureAsync();

        }
        public async Task StartCaptureAsync()
        {
            var picker = new GraphicsCapturePicker();
            var item = await picker.PickSingleItemAsync();

            if (item == null)
                return;
            if (item != null)
            {
                StartCaptureInternal(item);
            }
        }
        private SizeInt32 _lastSize;
        private GraphicsCaptureItem _item;
        private Direct3D11CaptureFramePool _framePool;
        private GraphicsCaptureSession _session;
        private CanvasDevice _canvasDevice;
        private CanvasBitmap _currentFrame;
        private CompositionDrawingSurface _surface;
        private CompositionGraphicsDevice _compositionGraphicsDevice;
        public void StartCaptureInternal(GraphicsCaptureItem item)
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            _item = item;
            if (_canvasDevice == null)
            {
                _canvasDevice = new CanvasDevice();
            }
            _compositionGraphicsDevice = CanvasComposition.CreateCompositionGraphicsDevice(
                Window.Current.Compositor,
                _canvasDevice);
            _surface = _compositionGraphicsDevice.CreateDrawingSurface(
                new Windows.Foundation.Size(1280, 720),
                DirectXPixelFormat.B8G8R8A8UIntNormalized,
                DirectXAlphaMode.Premultiplied);
            _framePool = Direct3D11CaptureFramePool.Create(
                _canvasDevice, // D3D device
                DirectXPixelFormat.B8G8R8A8UIntNormalized, // Pixel format
                2, // Number of frames
                _item.Size); // Size of the buffers
            _session = _framePool.CreateCaptureSession(item);
            _framePool.FrameArrived += FramePool_FrameArrived;

            _session.StartCapture();           
        }
        private async void FramePool_FrameArrived2(Direct3D11CaptureFramePool sender, object args)
        {
            using (var frame = _framePool.TryGetNextFrame())
            {
                using (var sbmp = await this.CreateSoftwareBitmapFromSurface(frame.Surface))
                {
                    _processBitmap(sbmp);
                }
              
            }
        }
        private unsafe void _processBitmap(SoftwareBitmap bitmap)
        {
            using (var buffer = bitmap.LockBuffer(BitmapBufferAccessMode.Read))
            {
                var reference = (IMemoryBufferByteAccess)buffer.CreateReference();

                reference.GetBuffer(out byte* nativeBuffer, out uint capacity);
                byte[] frameBuffer = new byte[capacity];
                for (int i = 0; i < bitmap.PixelHeight; i++)
                {
                    for (int j = 0; j < bitmap.PixelWidth; j++)
                    {
                        var indexManaged = (i * bitmap.PixelWidth + j) * 4;
                        var indexNative = ((bitmap.PixelHeight - 1 - i) * bitmap.PixelWidth + j) * 4;
                        frameBuffer[indexManaged + 0] = nativeBuffer[indexNative + 0];
                        frameBuffer[indexManaged + 1] = nativeBuffer[indexNative + 1];
                        frameBuffer[indexManaged + 2] = nativeBuffer[indexNative + 2];
                        frameBuffer[indexManaged + 3] = nativeBuffer[indexNative + 3];
                    }
                }
            }
        }
        private async Task<SoftwareBitmap> CreateSoftwareBitmapFromSurface(IDirect3DSurface surface)
        {
            return await SoftwareBitmap.CreateCopyFromSurfaceAsync(surface);
        }

        private async Task<byte[]> EncodeImageAsync(SoftwareBitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.BmpEncoderId, stream.AsRandomAccessStream());
                encoder.SetSoftwareBitmap(bitmap);
                await encoder.FlushAsync();
                return stream.ToArray();
            }
        }
        public bool IsBusy { get; set; } = false;
        private void FramePool_FrameArrived(Direct3D11CaptureFramePool sender, object args)
        {
            using (var frame = _framePool.TryGetNextFrame())
            {
                if (frame == null)
                    return;
                if(!IsBusy)
                ProcessFrame(frame);
            }
        }

        private void ProcessFrame(Direct3D11CaptureFrame frame)
        {
            IsBusy = true;
            bool needsReset = false;
            bool recreateDevice = false;

            if ((frame.ContentSize.Width != _lastSize.Width) ||
                (frame.ContentSize.Height != _lastSize.Height))
            {
                needsReset = true;
                _lastSize = frame.ContentSize;
            }

            try
            {
                CanvasBitmap canvasBitmap = CanvasBitmap.CreateFromDirect3D11Surface(
                    _canvasDevice,
                    frame.Surface);

                _currentFrame = canvasBitmap;
                FillSurfaceWithBitmap(canvasBitmap);
            }

            catch (Exception e) when (_canvasDevice.IsDeviceLost(e.HResult))
            {
                needsReset = true;
                recreateDevice = true;
            }

            if (needsReset)
            {
                ResetFramePool(frame.ContentSize, recreateDevice);
            }
        }
        public IBuffer byteArray;
        MemoryBuffer memoryBuffer;
        private async void FillSurfaceWithBitmap(CanvasBitmap canvasBitmap)
        {
            try
            {
                Windows.Foundation.Size sizeInPixels = new Windows.Foundation.Size(canvasBitmap.Size.Width, canvasBitmap.Size.Height);
                CanvasComposition.Resize(_surface, sizeInPixels);
                using (var session = CanvasComposition.CreateDrawingSession(_surface))
                {
                    session.Clear(Colors.Transparent);
                    session.DrawImage(canvasBitmap);
                }
                if (outgoingVideoStreamState == OutgoingVideoStreamState.Started)
                {
                    SoftwareBasedVideoFrameSender sender = (SoftwareBasedVideoFrameSender)videoFrameSender;
                    byteArray = canvasBitmap.GetPixelBytes().AsBuffer();
                    memoryBuffer = Windows.Storage.Streams.Buffer.CreateMemoryBufferOverIBuffer(byteArray);
                    if (sender != null)
                        await sender.SendFrameAsync(memoryBuffer, sender.TimestampInTicks);
                    IsBusy = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ResetFramePool(SizeInt32 size, bool recreateDevice)
        {
            do
            {
                try
                {
                    if (recreateDevice)
                    {
                        _canvasDevice = new CanvasDevice();
                    }

                    _framePool.Recreate(
                        _canvasDevice,
                        DirectXPixelFormat.B8G8R8A8UIntNormalized,
                        2,
                        size);

                }
                catch (Exception e) when (_canvasDevice.IsDeviceLost(e.HResult))
                {
                    _canvasDevice = null;
                    recreateDevice = true;
                }
            } while (_canvasDevice == null);
        }
        public async void StopScreensharing() 
        {
            //wait for the next version
            //if (videoOptions != null)
               // await _call.StopVideo(videoOptions);
        }
        public async Task<string> GetServerCallId()
        {
            return await _call.Info.GetServerCallIdAsync();
        }
        public async void SwitchCamera()
        {
        }
        public async void RetrieveCameraPreview()
        {
            var cameras = _deviceManager.Cameras.FirstOrDefault();
            if (cameras != null)
            {
                LocalVideoAdded?.Invoke(this, await GetCameraViewAsync());
            }
        }
        public async Task<View> GetCameraViewAsync()
        {
            VideoDeviceInfo videoDeviceInfo = _deviceManager.Cameras.First();
            if (_deviceManager.Cameras.Count <= 0)
            {
                await Task.Delay(2000);
                videoDeviceInfo = _deviceManager.Cameras.First();
            }
            var localVideoStream = new LocalVideoStream[1];
            localVideoStream[0] = new LocalVideoStream(videoDeviceInfo);
            if (localVideoStream != null)
            {
                Uri localUri = await localVideoStream[0].MediaUriAsync();
                MediaElement RemoteVideo = new MediaElement();
                RemoteVideo.Source = localUri;
                RemoteVideo.AutoPlay = true;
                RemoteVideo.Play();
                var stackPanel = new StackPanel();
                stackPanel.Children.Add(RemoteVideo);
                var renderingOptions = new CreateViewOptions(ScalingMode.Crop);
                return stackPanel.ToView();
            }
            else return null;

        }
        public async void StopCamera()
        {
            await global::Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(global::Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                try
                {
                    LocalVideoAdded.Invoke(this, null);
                    if (_localVideoStream[0] != null)
                        await _call.StopVideo(_localVideoStream[0]);
                }
                catch (Exception ex)
                {

                    new ConferenceExceptions(ex);
                }

            });
        }
    }
    public class CapturedFrame
    {
        public CapturedFrame(byte[] bitmap, int width, int height)
        {
            this.ImageData = bitmap;
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; }

        public int Height { get; }

        public byte[] ImageData { get; internal set; } = new byte[0];

        public object Raw => this.ImageData;
    }
    [ComImport]
    [Guid("5b0d3235-4dba-4d44-865e-8f1d0e4fd04d")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    unsafe interface IMemoryBufferByteAccess
    {
        void GetBuffer(out byte* buffer, out uint capacity);
    }
}

