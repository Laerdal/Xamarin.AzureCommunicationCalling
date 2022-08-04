namespace TestSample.Model
{
    public class AzureSetupRoom
    {
        public bool Direct { get; set; }
        public bool VideoEnabled { get; set; }
        public bool MicrophoneEnabled { get; set; }
        public TypeCall TypeCall { get; set; }
        public SelectedCamera SelectedCamera { get; set; }
        public TypeSpeaker TypeSpeaker { get; set; }
        public string Name { get; set; }
        public string CodeMeeting { get; set; }
        public AzureSetupRoom(bool videoEnabled, bool microphoneEnabled, TypeCall typeCall, SelectedCamera selectedCamera, TypeSpeaker typeSpeaker, string name, string codeMeeting)
        {
            VideoEnabled = videoEnabled;
            MicrophoneEnabled = microphoneEnabled;
            TypeCall = typeCall;
            SelectedCamera = selectedCamera;
            TypeSpeaker = typeSpeaker;
            Name = name;
            CodeMeeting = codeMeeting;
        }
    }
}
