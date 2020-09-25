using System;
using Xamarin.AzureCommunicationCalling.iOS;

namespace AzureCommunicationVideoTest.iOS.ACS
{
    public class RemoteParticipantDelegate : ACSRemoteParticipantDelegate
    {
        public RemoteParticipantDelegate()
        {
        }

        public override void OnVideoStreamsUpdated(ACSRemoteParticipant remoteParticipant, ACSRemoteVideoStreamsEventArgs args)
        {
            base.OnVideoStreamsUpdated(remoteParticipant, args);
            
            foreach (var videoStream in args.AddedRemoteVideoStreams)
            {
                var renderer = new ACSRenderer(videoStream);
                //renderer.
            }
        }
    }
}
