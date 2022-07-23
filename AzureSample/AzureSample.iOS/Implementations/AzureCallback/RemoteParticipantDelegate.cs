using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.AzureCommunicationCalling.iOS;

namespace AzureSample.iOS.Implementations
{
    public class RemoteParticipantDelegate : ACSRemoteParticipantDelegate
    {
        private readonly CallingCallbackManager _videoCallbackManager;
        private Action<ACSRemoteParticipant> remoteParticipants;

        public RemoteParticipantDelegate(Action<ACSRemoteParticipant> remoteParticipants)
        {
            this.remoteParticipants = remoteParticipants;
        }
        public RemoteParticipantDelegate(CallingCallbackManager videoCallbackManager)
        {
            _videoCallbackManager = videoCallbackManager;
        }

        public override void OnStateChanged(ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args)
        {
            foreach (var remoteVideoStream in remoteParticipant.VideoStreams)
            {
                //_videoCallbackManager.RemoteParticipantStateChanged?.Invoke(new VideoStream(remoteParticipant,remoteVideoStream));
            }
        }
        public override void OnIsSpeakingChanged(ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args)
        {
            _videoCallbackManager.RemoteParticipantSpeaking?.Invoke(remoteParticipant);
        }
        public override void OnIsMutedChanged(ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args)
        {
            _videoCallbackManager.RemoteParticipantMutedChanged?.Invoke(remoteParticipant);
            //remoteParticipants?.Invoke(remoteParticipant);
            //_videoCallbackManager.RemoteStreamAdded(new VideoStream(remoteParticipant, remoteParticipant.VideoStreams))
        }
        public override void OnVideoStreamsUpdated(ACSRemoteParticipant remoteParticipant, ACSRemoteVideoStreamsEventArgs args)
        {
            foreach (var remoteVideoStream in args.AddedRemoteVideoStreams)
            {
                _videoCallbackManager.HandleRemoteParticipantVideoStreamsAdded(remoteVideoStream,remoteParticipant);
            } 
            foreach (var remoteVideoStream in args.RemovedRemoteVideoStreams)
            {
                _videoCallbackManager.HandleRemoteParticipantVideoStreamsRemoved(remoteVideoStream, remoteParticipant);
            }

        }
        
    }
}