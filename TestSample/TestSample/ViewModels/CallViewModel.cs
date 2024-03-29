﻿using TestSample.Enums;
using TestSample.Interfaces;
using TestSample.Model;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;

namespace TestSample.ViewModels
{
    public class CallViewModel : BaseViewModel
    {
        IConferenceManagerSpecificPlatform _conferenceManagerSpecificPlatform = ContainerDependencyInjectionService.GetService<IConferenceManagerSpecificPlatform>();

        public ICommand MicrophoneCommand { get; set; }
        public ICommand CameraCommand { get; set; }
        public ICommand CameraSwitchCommand { get; set; }
        public ICommand SpeakerCommand { get; set; }
        public ICommand VideoCommand { get; set; }
        public ICommand ChangeCameraCommand { get; set; }
        public ICommand HangUpCallCommand { get; set; }
        public ICommand CreateNewCallCommand { get; set; }
        bool _speakerEnabled;
        public bool SpeakerEnabled
        {
            get => _speakerEnabled;
            set => SetProperty(ref _speakerEnabled, value);
        }
        bool _microphoneEnabled;
        public bool MicrophoneEnabled
        {
            get => _microphoneEnabled;
            set => SetProperty(ref _microphoneEnabled, value);
        }
        bool _cameraEnabled;
        public bool VideoEnabled
        {
            get => _cameraEnabled;
            set => SetProperty(ref _cameraEnabled, value);
        }
        bool _videoConference = false;
        public bool VideoConference
        {
            get => _videoConference;
            set
            {
                SetProperty(ref _videoConference, value);
            }
        }
        public bool _isSharingRemoteVideo;
        public bool IsSharingRemoteVideo
        {
            get => _isSharingRemoteVideo;
            set { SetProperty(ref _isSharingRemoteVideo, value); }
        }
        public bool _isSharingLocalCamera = false;
        public bool IsSharingLocalCamera
        {
            get => _isSharingLocalCamera;
            set { SetProperty(ref _isSharingLocalCamera, value); }
        }

        ObservableCollection<ConferenceParticipantWrapper> _participants;
        public ObservableCollection<ConferenceParticipantWrapper> Participants
        {
            get => _participants;
            set
            {
                SetProperty(ref _participants, value);
            }
        }

        Xamarin.Forms.Frame localCamera;
        public Xamarin.Forms.Frame LocalCamera
        {
            get => localCamera;
            set => SetProperty(ref localCamera, value);
        }
        public CallViewModel()
        {
            LocalCamera = new Xamarin.Forms.Frame();

            HangUpCallCommand = new Command(HangUpCall);
            SpeakerCommand = new Command(ExecuteToggleSpeaker);
            MicrophoneCommand = new Command(ExecuteToggleMicrophone);
            CameraCommand = new Command(ExecuteToggleCamera);
            CameraSwitchCommand = new Command(ExecuteCameraSwitch);
            Participants = new ObservableCollection<ConferenceParticipantWrapper>();
            IsSharingRemoteVideo = false;

        }
        public void InitializeAsync(object navigationData)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                if (navigationData is AzureSetupRoom azure)
                {
                    if (azure.CodeMeeting == "")
                    {
                        azure.CodeMeeting = GenerateNewCodeMeeting();
                    }
                    VideoEnabled = azure.VideoEnabled;
                    MicrophoneEnabled = azure.MicrophoneEnabled;
                    azure.MicrophoneEnabled = !azure.MicrophoneEnabled;//Invert bool microfone ;)
                    Participants = new ObservableCollection<ConferenceParticipantWrapper>();
                    await _conferenceManagerSpecificPlatform.InitializeConference(azure);
                    _conferenceManagerSpecificPlatform.StateChanged += ConferenceManagerSpecificPlatform_StateChanged;
                    _conferenceManagerSpecificPlatform.ParticipantJoined += OnParticipantJoined;
                    _conferenceManagerSpecificPlatform.ParticipantLeft += OnParticipantLeft;
                    _conferenceManagerSpecificPlatform.ParticipantMicrophoneStatusChanged += ParticipantMicrophoneStatusChanged;
                    _conferenceManagerSpecificPlatform.RemoteVideoAdded += ConferenceManagerSpecificPlatform_RemoteVideoAdded;
                    _conferenceManagerSpecificPlatform.RemoteVideoRemoved += ConferenceManagerSpecificPlatform_RemoteVideoRemoved;
                    _conferenceManagerSpecificPlatform.LocalVideoAdded += ConferenceManagerSpecificPlatform_LocalVideoAdded;
                    _conferenceManagerSpecificPlatform.SpeakingChanged += ConferenceManagerSpecificPlatform_SpeakingChanged;
                }
            });
        }

        private void ConferenceManagerSpecificPlatform_LocalVideoAdded(object sender, Xamarin.Forms.View e)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    if (e != null)
                    {
                        LocalCamera = new Xamarin.Forms.Frame();
                        LocalCamera.HeightRequest = e.HeightRequest;
                        LocalCamera.WidthRequest = e.WidthRequest;
                        LocalCamera.Content = e;
                        IsSharingLocalCamera = true;
                    }
                    else
                    {
                        IsSharingLocalCamera = false;
                        LocalCamera = null;
                        LocalCamera = new Xamarin.Forms.Frame();
                    }
                }
                catch (Exception ex)
                {

                    new ConferenceExceptions(ex);
                }

            });
        }

        private void ConferenceManagerSpecificPlatform_SpeakingChanged(object sender, ParticipantSpeakingStatusChangedArgs e)
        {
            var existing = Participants.FirstOrDefault(p => p.Id == e.ParticipantId);
            if (existing != null)
            {
                existing.IsSpeaking = e.Speaking;
            }
        }

        private void ConferenceManagerSpecificPlatform_RemoteVideoRemoved(object sender, ParticipantVideoStatusChangedArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    var existing = Participants.FirstOrDefault(p => p.Id == e.ParticipantId);
                    if (existing != null)
                    {
                        existing.IsVideoSharing = false;
                        existing.IsSpeaking = false;
                        existing.StreamVideo.Children.Remove(existing.StreamVideo);
                        existing.StreamVideo.Children.Clear();
                        existing.StreamVideo.ForceLayout();
                    }
                }
                catch (Exception ex)
                {

                    new ConferenceExceptions(ex);
                }
            });
        }



        private void ConferenceManagerSpecificPlatform_RemoteVideoAdded(object sender, ParticipantVideoStatusChangedArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    var existing = Participants.FirstOrDefault(p => p.Id == e.ParticipantId);
                    if (existing != null)
                    {
                        existing.IsVideoSharing = true;
                        existing.StreamVideo.HeightRequest = Xamarin.Forms.Device.Idiom == Xamarin.Forms.TargetIdiom.Desktop ? 180 : 100;
                        existing.StreamVideo.WidthRequest = Xamarin.Forms.Device.Idiom == Xamarin.Forms.TargetIdiom.Desktop ? 180 : 100;
                        existing.StreamVideo.WidthRequest = Xamarin.Forms.Device.Idiom == Xamarin.Forms.TargetIdiom.Desktop ? 180 : 100;
                        existing.StreamVideo.VerticalOptions = Xamarin.Forms.LayoutOptions.Center;
                        existing.StreamVideo.HorizontalOptions = Xamarin.Forms.LayoutOptions.Center;
                        existing.StreamVideo.Children.Add(new Xamarin.Forms.Frame
                        {
                            Content = e.StreamVideo,
                            HeightRequest = Xamarin.Forms.Device.Idiom == Xamarin.Forms.TargetIdiom.Desktop ? 180 : 100,
                            WidthRequest = Xamarin.Forms.Device.Idiom == Xamarin.Forms.TargetIdiom.Desktop ? 180 : 100,
                            VerticalOptions = Xamarin.Forms.LayoutOptions.Center,
                            HorizontalOptions = Xamarin.Forms.LayoutOptions.Center,
                        });
                    }
                }
                catch (Exception ex)
                {

                    new ConferenceExceptions(ex);
                }
            });
        }
        public void ExecuteCameraSwitch()
        {
            _conferenceManagerSpecificPlatform.SwitchCamera();
        }
        public void ExecuteToggleCamera()
        {
            if (VideoEnabled)
            {
                _conferenceManagerSpecificPlatform.StopCamera();
                VideoEnabled = false;
            }
            else
            {
                _conferenceManagerSpecificPlatform.StartCamera();
                VideoEnabled = true;
            }

        }
        public string GenerateNewCodeMeeting()
        {
            return new Guid().ToString();
        }
        public void Dispose()
        {
            _conferenceManagerSpecificPlatform.StateChanged -= ConferenceManagerSpecificPlatform_StateChanged;
            _conferenceManagerSpecificPlatform.ParticipantJoined -= OnParticipantJoined;
            _conferenceManagerSpecificPlatform.ParticipantLeft -= OnParticipantLeft;
            _conferenceManagerSpecificPlatform.ParticipantMicrophoneStatusChanged -= ParticipantMicrophoneStatusChanged;
        }

        private void OnParticipantJoined(object sender, ParticipantJoinArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (!Participants.Any(p => p.Id == e.UserId))
                {
                    Participants.Add(new ConferenceParticipantWrapper(
                        e.UserId,
                        e.UserName, new Xamarin.Forms.StackLayout()
                        , ConferenceParticipant.PartipantState.Joined));

                }
                if (Participants.Count >= 1)
                {

                }
                try
                {
                    Vibration.Vibrate(TimeSpan.FromSeconds(2));
                }
                catch (FeatureNotSupportedException ex)
                {
                }
                catch (Exception ex)
                {
                    new ConferenceExceptions(ex);
                }
            });
        }
        private void ExecuteToggleSpeaker()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            _conferenceManagerSpecificPlatform.SpeakerOn = SpeakerEnabled = !SpeakerEnabled;
            IsBusy = false;
        }
        private void OnParticipantLeft(object sender, ParticipantLeftArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var existing = Participants.FirstOrDefault(p => p.Id == e.UserId);
                if (existing != null)
                {
                    Participants.Remove(existing);
                }
                if (Participants.Count == 0)
                {
                }

                try
                {
                    Vibration.Vibrate(TimeSpan.FromSeconds(2));
                }
                catch (FeatureNotSupportedException ex)
                {
                }
                catch (Exception ex)
                {
                    new ConferenceExceptions(ex);
                }
            });
        }
        private void ParticipantMicrophoneStatusChanged(object sender, ParticipantMicrophoneStatusChangedArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var existing = Participants.FirstOrDefault(p => p.Id == e.ParticipantId);
                if (existing != null)
                {
                    existing.MicrophoneMuted = e.Muted;
                }
            });
        }
        private void ConferenceManagerSpecificPlatform_StateChanged(object sender, ConferenceStateChangedEnventArgs e)
        {
            switch (e.NewState)
            {
                case ConferenceState.Dialing:
                    break;
                case ConferenceState.Receiving:
                    break;
                case ConferenceState.Accepted:
                case ConferenceState.Accepting:
                    break;
                case ConferenceState.InLobby:
                    break;
                case ConferenceState.Initializing:
                    break;
                case ConferenceState.Connecting:
                    break;
                case ConferenceState.Reconnecting:
                    break;
                case ConferenceState.Connected:
                    //This should retrieve the user image in the preview if the call starts with the camera on.
                    //if (VideoEnabled)
                    //    _conferenceManagerSpecificPlatform.GetCameraPreview();
                    break;
                case ConferenceState.Reconnected:
                    break;
                case ConferenceState.Disconnecting:
                    break;
                case ConferenceState.Disconnected:
                    break;
                default:
                    break;
            }
        }
        public async void HangUpCall()
        {
            _conferenceManagerSpecificPlatform.Hangup();
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }
        public async void ExecuteToggleMicrophone()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            await _conferenceManagerSpecificPlatform.MuteUnMuted();
            MicrophoneEnabled = !MicrophoneEnabled;
            IsBusy = false;
        }
    }
}
