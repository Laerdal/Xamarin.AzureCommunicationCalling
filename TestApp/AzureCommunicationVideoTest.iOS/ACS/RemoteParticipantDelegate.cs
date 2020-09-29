using Xamarin.AzureCommunicationCalling.iOS;

namespace AzureCommunicationVideoTest.iOS.ACS
{
    public class RemoteParticipantDelegate : ACSRemoteParticipantDelegate
    {
        private readonly VideoCallbackManager _videoCallbackManager;
        //private List<ACSRemoteVideoStream> _remoteVideoStreams = new List<ACSRemoteVideoStream>();

        public RemoteParticipantDelegate(VideoCallbackManager videoCallbackManager)
        {
            _videoCallbackManager = videoCallbackManager;
        }

        public override void OnParticipantStateChanged(ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args)
        {
            
        }

        public override void OnVideoStreamsUpdated(ACSRemoteParticipant remoteParticipant, ACSRemoteVideoStreamsEventArgs args)
        {
            foreach (var videoStream in args.AddedRemoteVideoStreams)
            {
                if (videoStream.IsAvailable)
                {
                    _videoCallbackManager.RemoteVideoStreamAdded?.Invoke(videoStream);
                }
                //_remoteVideoStreams.Add(videoStream);
            }
        }
    }
}
