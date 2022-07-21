using AzureSample.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AzureSample.Model
{
    public class IncomingConferenceRequest
    {
        public string CallId { get; set; }
        public string CallerId { get; set; }
        public string CallerName { get; set; }
        public bool WithVideo { get; set; }
        public bool IsGroup { get; set; }
        public ConferenceParticipant[] Participants { get; set; }
        public string AccessToken { get; set; }
        public DateTime Date { get; set; }
    }

    public class MissedConferenceRequest
    {
        public string CallId { get; set; }
        public string CallerId { get; set; }
        public string CallerName { get; set; }
        public bool WithVideo { get; set; }
        public bool IsGroup { get; set; }
        public DateTime Date { get; set; }
    }
    public class ConferenceParticipant
    {
        public ConferenceParticipant(string id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.State = PartipantState.Invited;
        }

        public ConferenceParticipant(string id, string name, PartipantState state)
        {
            this.Id = id;
            this.Name = name;
            this.State = state;
        }

        public string Id { get; }
        public string Name { get; }
        public PartipantState State { get; set; }
        public bool MicrophoneMuted { get; set; }

        public enum PartipantState
        {
            Invited,
            Joined,
            Leave
        }
    }
    public class BindingObject : INotifyPropertyChanged
    {
        protected BindingObject() { }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void SetProperty<TValue>(ref TValue prop, TValue value, [CallerMemberName] string propertyName = "")
        {
            prop = value;
            RaisePropertyChanged(propertyName);
        }

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsEquals(object compareObject)
        {
            var instance = JsonConvert.SerializeObject(this);
            var compare = JsonConvert.SerializeObject(compareObject);

            return instance.Equals(compare);
        }
    }
    public class ConferenceParticipantWrapper : BindingObject
    {
        public ConferenceParticipantWrapper()
        {
        }

        public ConferenceParticipantWrapper(ConferenceParticipant participant)
        {
            this.Id = participant.Id;
            this.Name = participant.Name;
            this.State = participant.State;
            this.MicrophoneMuted = participant.MicrophoneMuted;
        }

        public ConferenceParticipantWrapper(string id, string name, StackLayout streamView, ConferenceParticipant.PartipantState state)
        {
            this.Id = id;
            this.Name = name;
            this.State = state;
            this.StreamVideo = streamView;
        }

        public string Id { get; }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private ConferenceParticipant.PartipantState _state;
        public ConferenceParticipant.PartipantState State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }

        private bool _microphoneMuted;
        public bool MicrophoneMuted
        {
            get => _microphoneMuted;
            set => SetProperty(ref _microphoneMuted, value);
        }
        private bool _isSpeaking = false;
        public bool IsSpeaking
        {
            get => _isSpeaking;
            set => SetProperty(ref _isSpeaking, value);
        }  
        private bool _isVideoSharing;
        public bool IsVideoSharing
        {
            get => _isVideoSharing;
            set => SetProperty(ref _isVideoSharing, value);
        }
        private StackLayout _streamVideo;
        public StackLayout StreamVideo
        {
            get => _streamVideo;
            set => SetProperty(ref _streamVideo, value);
        }
    }
    public class ConferenceStateChangedEnventArgs : EventArgs
    {
        public ConferenceStateChangedEnventArgs(ConferenceState state)
        {
            NewState = state;
        }

        public ConferenceState NewState { get; }
    }
    public class MessageReceivedArgs : EventArgs
    {
        public string Name { get; private set; }
        public string Message { get; private set; }

        public MessageReceivedArgs(string name, string message)
        {
            this.Name = name;
            this.Message = message;
        }
    }
    public enum ConnectionState
    {
        New = 1,
        Initializing,
        Connecting,
        Connected,
        Failing,
        Failed,
        Closing,
        Closed
    }
    public enum TypeCall
    {
        Teams,
        Group,
        Direct,
        PSTN,
        Bot
    } 
    public enum TypeSpeaker
    {
        Default,
        Speaker
    }
    public enum SelectedCamera
    {
        Front,
        Back
    }
    public class ConnectionStateArgs : EventArgs
    {
        public string UserId { get; private set; }
        public ConnectionState State { get; private set; }

        public ConnectionStateArgs(string userId, ConnectionState state)
        {
            this.UserId = userId;
            this.State = state;
        }
    }

    

    public class RemoteVideoClosingArgs : EventArgs
    {
        public string Id { get; private set; }

        public RemoteVideoClosingArgs(string id)
        {
            Id = id;
        }
    }

    public class LocalVideoAvailableArgs : EventArgs
    {

        public LocalVideoAvailableArgs()
        {
        }
    }

    public class LocalVideoClosingArgs : EventArgs
    {


    }

  

    public class ParticipantJoinArgs : EventArgs
    {
        public string UserId { get; private set; }
        public string UserName { get; private set; }

        public ParticipantJoinArgs(string userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }
    }

    public class ParticipantLeftArgs : EventArgs
    {
        public string UserId { get; private set; }
        public string UserName { get; private set; }

        public ParticipantLeftArgs(string userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }
    }

    public class ParticipantsInvitedArgs : EventArgs
    {
        public IReadOnlyCollection<ConferenceParticipant> NewParticipants { get; private set; }

        public ParticipantsInvitedArgs(IReadOnlyCollection<ConferenceParticipant> newParticipants)
        {
            NewParticipants = newParticipants;
        }
    }

    public class MissedConferenceArgs : EventArgs
    {
        public MissedConferenceArgs(string callId, string callerId, string callerName, bool isGroup, bool withVideo)
        {
            CallId = callId;
            CallerId = callerId;
            CallerName = callerName;
            IsGroup = isGroup;
            WithVideo = withVideo;
        }

        public string CallId { get; private set; }
        public string CallerId { get; private set; }
        public string CallerName { get; private set; }
        public bool IsGroup { get; set; }
        public bool WithVideo { get; set; }
    }

    public class ParticipantMicrophoneStatusChangedArgs : EventArgs
    {
        public ParticipantMicrophoneStatusChangedArgs(string participantId, bool muted)
        {
            ParticipantId = participantId;
            Muted = muted;
        }

        public string ParticipantId { get; private set; }
        public bool Muted { get; set; }
    }
    public class ParticipantVideoStatusChangedArgs : EventArgs
    {
        public ParticipantVideoStatusChangedArgs(string participantId, bool muted, View streamVideo)
        {
            ParticipantId = participantId;
            Muted = muted;
            StreamVideo = streamVideo;
        }

        public string ParticipantId { get; private set; }
        public bool Muted { get; set; }
        public View StreamVideo { get; set; }        
    }
    public class ParticipantSpeakingStatusChangedArgs : EventArgs
    {
        public ParticipantSpeakingStatusChangedArgs(string participantId, bool muted, bool speaking)
        {
            ParticipantId = participantId;
            Muted = muted;
            Speaking = speaking;
        }

        public string ParticipantId { get; private set; }
        public bool Muted { get; set; }
        public bool Speaking { get; set; }
    }
    public class RequestChangeToVideoConferenceArgs : EventArgs
    {
        public RequestChangeToVideoConferenceArgs(string participantId)
        {
            ParticipantId = participantId;
        }

        public string ParticipantId { get; private set; }
    }

    public class RequestStopVideoConferenceArgs : EventArgs
    {
        public RequestStopVideoConferenceArgs(string participantId)
        {
            ParticipantId = participantId;
        }

        public string ParticipantId { get; private set; }
    }

    public class AnswerChangeToVideoConferenceArgs : EventArgs
    {
        public AnswerChangeToVideoConferenceArgs(string participantId, bool accepted)
        {
            ParticipantId = participantId;
            Accepted = accepted;
        }

        public string ParticipantId { get; private set; }
        public bool Accepted { get; }
    }
    public class VoipChannelNotification
    {
        public const string CHANNEL_ID = "voip_channel";

    }
}
