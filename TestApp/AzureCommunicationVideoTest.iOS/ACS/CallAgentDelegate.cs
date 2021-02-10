using Xamarin.Forms.Internals;
using Xamarin.AzureCommunicationCalling.iOS;

namespace AzureCommunicationVideoTest.iOS.ACS
{
    public class CallAgentDelegate : ACSCallAgentDelegate
    {
        private readonly CallingCallbackManager _videoCallbackManager;

        public CallAgentDelegate(CallingCallbackManager videoCallbackManager)
        {
            _videoCallbackManager = videoCallbackManager;
        }

        public override void OnCallsUpdated(ACSCallAgent callAgent, ACSCallsUpdatedEventArgs args)
        {
            foreach (var call in args.AddedCalls)
            {
                foreach (var remoteParticipant in call.RemoteParticipants)
                {
                    remoteParticipant.Delegate = new RemoteParticipantDelegate(_videoCallbackManager);

                    foreach (var remoteVideoStream in remoteParticipant.VideoStreams)
                    {
                        _videoCallbackManager.RemoteVideoStreamAdded?.Invoke(remoteVideoStream);
                    }
                }
                call.Delegate = new CallDelegate(_videoCallbackManager);
            }
        }

    }
}
