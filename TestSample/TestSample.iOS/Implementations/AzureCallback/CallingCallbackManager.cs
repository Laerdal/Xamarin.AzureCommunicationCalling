using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.AzureCommunicationCalling.iOS;

namespace TestSample.iOS.Implementations
{
    public class CallingCallbackManager
    {
        public CallingCallbackManager(Action<VideoStream> remoteVideoStreamRemoved,
            Action<ACSRemoteParticipant> remoteParticipantAdded,
            Action<VideoStream> remoteVideoStreamAdded,
            Action<ACSRemoteParticipant> remoteParticipantRemoved,
            Action<ACSRemoteParticipant> remoteParticipantMutedChanged,
            Action<ACSCall> localStateChanged,
            Action<ACSRemoteParticipant> remoteParticipantSpeaking,
            Action<ACSIncomingCall> incomingCall,
            Action<ACSIncomingCall> callEnded,
            Action<ACSRawOutgoingVideoStreamOptions, ACSOutgoingVideoStreamStateChangedEventArgs> screenSharing)
        {
            RemoteVideoStreamRemoved = remoteVideoStreamRemoved;
            RemoteParticipantAdded = remoteParticipantAdded;
            RemoteVideoStreamAdded = remoteVideoStreamAdded;
            RemoteParticipantRemoved = remoteParticipantRemoved;
            RemoteParticipantMutedChanged = remoteParticipantMutedChanged;
            LocalStateChanged = localStateChanged;
            RemoteParticipantSpeaking = remoteParticipantSpeaking;
            IncomingCall = incomingCall;
            CallEnded = callEnded;
            ScreenSharing = screenSharing;
        }
        public Action<VideoStream> RemoteVideoStreamAdded { get; }
        public Action<VideoStream> RemoteVideoStreamRemoved { get; }
        public Action<ACSRemoteParticipant> RemoteParticipantAdded { get; }
        public Action<ACSRemoteParticipant> RemoteParticipantRemoved { get; }
        public Action<ACSRemoteParticipant> RemoteParticipantMutedChanged { get; }
        public Action<ACSRemoteParticipant> RemoteParticipantSpeaking { get; }
        public Action<ACSIncomingCall> IncomingCall { get; }
        public Action<ACSIncomingCall> CallEnded { get; }
        public Action<ACSCall> LocalStateChanged { get; }
        public Action<ACSRawOutgoingVideoStreamOptions, ACSOutgoingVideoStreamStateChangedEventArgs> ScreenSharing { get; }
        //public Action<VideoStream> RemoteStreamAdded { get; }

        public void HandleRemoteParticipantAdded(ACSRemoteParticipant participant)
        {
            RemoteParticipantAdded.Invoke(participant);
            LoggerService.Debug("Remote participant added");
        }
        public void HandleRemoteParticipantRemoved(ACSRemoteParticipant participant)
        {
            RemoteParticipantRemoved.Invoke(participant);
            LoggerService.Debug("Remote participant removed");
        }
        public void HandleRemoteParticipantVideoStreamsRemoved(ACSRemoteVideoStream aCSRemoteVideoStream, ACSRemoteParticipant participant)
        {
            RemoteVideoStreamRemoved?.Invoke(new VideoStream(participant, aCSRemoteVideoStream));
        }
        public void HandleRemoteParticipantVideoStreamsAdded(ACSRemoteVideoStream aCSRemoteVideoStream, ACSRemoteParticipant participant)
        {
            LoggerService.Debug("Remote participant added");
            RemoteVideoStreamAdded?.Invoke(new VideoStream(participant, aCSRemoteVideoStream));
        }
    }
}