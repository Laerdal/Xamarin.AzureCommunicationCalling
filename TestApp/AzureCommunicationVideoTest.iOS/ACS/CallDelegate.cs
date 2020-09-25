using System;
using Xamarin.AzureCommunicationCalling.iOS;

namespace AzureCommunicationVideoTest.iOS.ACS
{
    public class CallDelegate : ACSCallDelegate
    {
        public CallDelegate()
        {
        }

        public override void OnRemoteParticipantsUpdated(ACSCall call, ACSParticipantsUpdatedEventArgs args)
        {
            base.OnRemoteParticipantsUpdated(call, args);
            foreach (var participant in args.AddedParticipants)
            {
                participant.Delegate = new RemoteParticipantDelegate();
            }
        }
    }
}
