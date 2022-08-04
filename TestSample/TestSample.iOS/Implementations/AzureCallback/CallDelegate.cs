using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.AzureCommunicationCalling.iOS;

namespace TestSample.iOS.Implementations
{
    public class CallDelegate : ACSCallDelegate
    {
        private CallingCallbackManager _videoCallbackManager;
        private List<ACSRemoteParticipant> _remoteParticipants = new List<ACSRemoteParticipant>();
        private Action<ACSCallState> _acsCallState;

        public CallDelegate(Action<ACSCallState> acsCallState)
        {
            _acsCallState = acsCallState;
        }
        public CallDelegate(CallingCallbackManager videoCallbackManager)
        {
            _videoCallbackManager = videoCallbackManager;
        }

        public override void OnStateChanged(ACSCall call, ACSPropertyChangedEventArgs args)
        {
            _videoCallbackManager.LocalStateChanged?.Invoke(call);
            _acsCallState?.Invoke(call.State);
            LoggerService.Debug($"Call state changed: {call.State}");
        }

        public override void OnLocalVideoStreamsUpdated(ACSCall call, ACSLocalVideoStreamsUpdatedEventArgs args)
        {
            LoggerService.Debug($"Local video streams changed");
        }

        public override void OnRemoteParticipantsUpdated(ACSCall call, ACSParticipantsUpdatedEventArgs args)
        {
            LoggerService.Debug($"Remote participants changed");
            foreach (var participantAdded in args.AddedParticipants)
            {

                _videoCallbackManager.HandleRemoteParticipantAdded(participantAdded);                
                participantAdded.Delegate = new RemoteParticipantDelegate(_videoCallbackManager);
                //ParticipantJoined?.Invoke(this, new ParticipantJoinArgs(participantAdded.DisplayName, participantAdded.DisplayName));
                _remoteParticipants.Add(participantAdded);
            }
            foreach (var participantRemoved in args.RemovedParticipants)
            {
                participantRemoved.Delegate = new RemoteParticipantDelegate(_videoCallbackManager);
                _remoteParticipants.Remove(participantRemoved);
                //ParticipantLeft?.Invoke(this, new ParticipantLeftArgs(participantRemoved.DisplayName, participantRemoved.DisplayName));
            }
            //foreach (var participant in args.AddedParticipants)
            //{
            //    LoggerService.Debug($"Setting up new remote participant");
            //    _videoCallbackManager.HandleRemoteParticipantAdded(participant);
            //    participant.Delegate = new RemoteParticipantDelegate(_videoCallbackManager);
            //    _remoteParticipants.Add(participant);
            //}
        }
    }
}