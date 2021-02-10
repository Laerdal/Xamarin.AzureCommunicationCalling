using Xamarin.AzureCommunicationCalling.iOS;

namespace AzureCommunicationVideoTest.iOS.ACS
{
    public class RemoteParticipantDelegate : ACSRemoteParticipantDelegate
    {
        private readonly CallingCallbackManager _videoCallbackManager;

        public RemoteParticipantDelegate(CallingCallbackManager videoCallbackManager)
        {
            _videoCallbackManager = videoCallbackManager;
        }

        public override void OnParticipantStateChanged(ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args)
        {
            foreach (var remoteVideoStream in remoteParticipant.VideoStreams)
            {
                _videoCallbackManager.RemoteVideoStreamAdded?.Invoke(remoteVideoStream);
            }
        }

        public override void OnVideoStreamsUpdated(ACSRemoteParticipant remoteParticipant, ACSRemoteVideoStreamsEventArgs args)
        {
            foreach (var remoteVideoStream in args.AddedRemoteVideoStreams)
            {
                _videoCallbackManager.RemoteVideoStreamAdded?.Invoke(remoteVideoStream);
            }
        }
    }
}
