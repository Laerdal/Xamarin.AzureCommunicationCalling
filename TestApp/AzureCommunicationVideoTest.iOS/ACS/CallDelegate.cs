using System;
using Xamarin.Forms;
using Xamarin.AzureCommunicationCalling.iOS;
using System.Collections.Generic;

namespace AzureCommunicationVideoTest.iOS.ACS
{
    public class CallDelegate : ACSCallDelegate
    {
        private CallingCallbackManager _videoCallbackManager;
        private List<ACSRemoteParticipant> _remoteParticipants = new List<ACSRemoteParticipant>();

        public CallDelegate(CallingCallbackManager videoCallbackManager)
        {
            _videoCallbackManager = videoCallbackManager;
        }

        public override void OnCallStateChanged(ACSCall call, ACSPropertyChangedEventArgs args)
        {
            Logger.Debug($"Call state changed: {call.State}");
        }

        public override void OnLocalVideoStreamsChanged(ACSCall call, ACSLocalVideoStreamsUpdatedEventArgs args)
        {
            Logger.Debug($"Local video streams changed");
        }

        public override void OnRemoteParticipantsUpdated(ACSCall call, ACSParticipantsUpdatedEventArgs args)
        {
            Logger.Debug($"Remote participants changed");
            foreach (var participant in args.AddedParticipants)
            {
                _videoCallbackManager.HandleRemoteParticipantAdded(participant);
                participant.Delegate = new RemoteParticipantDelegate(_videoCallbackManager);
                _remoteParticipants.Add(participant);
            }
        }
    }
}
