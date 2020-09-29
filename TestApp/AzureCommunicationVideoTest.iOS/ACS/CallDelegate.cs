using System;
using Xamarin.Forms;
using Xamarin.AzureCommunicationCalling.iOS;
using System.Collections.Generic;

namespace AzureCommunicationVideoTest.iOS.ACS
{
    public class CallDelegate : ACSCallDelegate
    {
        private VideoCallbackManager _videoCallbackManager;
        private List<ACSRemoteParticipant> _remoteParticipants = new List<ACSRemoteParticipant>();

        public CallDelegate(VideoCallbackManager videoCallbackManager)
        {
            _videoCallbackManager = videoCallbackManager;
        }

        public override void OnCallStateChanged(ACSCall call, ACSPropertyChangedEventArgs args)
        {
        }

        public override void OnLocalVideoStreamsChanged(ACSCall call, ACSLocalVideoStreamsUpdatedEventArgs args)
        {
        }

        public override void OnRemoteParticipantsUpdated(ACSCall call, ACSParticipantsUpdatedEventArgs args)
        {
            foreach (var participant in args.AddedParticipants)
            {
                _videoCallbackManager.HandleRemoteParticipantAdded(participant);
                participant.Delegate = new RemoteParticipantDelegate(_videoCallbackManager);
                _remoteParticipants.Add(participant);
            }
        }
    }
}
