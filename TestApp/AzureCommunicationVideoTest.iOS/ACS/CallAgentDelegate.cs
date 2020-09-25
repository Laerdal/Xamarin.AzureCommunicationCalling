using System;
using Xamarin.AzureCommunicationCalling.iOS;

namespace AzureCommunicationVideoTest.iOS.ACS
{
    public class CallAgentDelegate : ACSCallAgentDelegate
    {
        public CallAgentDelegate()
        {
        }

        public override void OnCallsUpdated(ACSCallAgent callAgent, ACSCallsUpdatedEventArgs args)
        {
            base.OnCallsUpdated(callAgent, args);
            foreach (var call in callAgent.Calls)
            {
                call.Delegate = new CallDelegate();
            }
        }

    }
}
