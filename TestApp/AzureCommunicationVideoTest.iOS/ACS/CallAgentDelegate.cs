using Xamarin.Forms.Internals;
using Xamarin.AzureCommunicationCalling.iOS;

namespace AzureCommunicationVideoTest.iOS.ACS
{
    public class CallAgentDelegate : ACSCallAgentDelegate
    {
        private readonly VideoCallbackManager _videoCallbackManager;

        public CallAgentDelegate(VideoCallbackManager videoCallbackManager)
        {
            _videoCallbackManager = videoCallbackManager;
        }

        public override void OnCallsUpdated(ACSCallAgent callAgent, ACSCallsUpdatedEventArgs args)
        {
            foreach (var call in args.AddedCalls)
            {
                call.Delegate = new CallDelegate(_videoCallbackManager);
            }
        }

    }
}
