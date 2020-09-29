using System;
using Xamarin.AzureCommunicationCalling.iOS;

namespace AzureCommunicationVideoTest.iOS.ACS
{
    public class VideoCallbackManager
    {
        public VideoCallbackManager(Action<ACSRemoteVideoStream> remoteVideoStreamAdded)
        {
            RemoteVideoStreamAdded = remoteVideoStreamAdded;
        }

        public Action<ACSRemoteVideoStream> RemoteVideoStreamAdded { get; }

        internal void HandleRemoteParticipantAdded(ACSRemoteParticipant participant)
        {
            foreach (var videoStream in participant.VideoStreams)
            {
                if (videoStream.IsAvailable)
                {
                    RemoteVideoStreamAdded?.Invoke(videoStream);
                }
            }
        }
    }
}