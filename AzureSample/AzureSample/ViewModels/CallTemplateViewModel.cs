using AzureSample.Model;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureSample.ViewModels
{
    public class CallTemplateViewModel:BaseViewModel
    {
        public ObservableRangeCollection<Participants> _participants;
        public ObservableRangeCollection<Participants> Participants
        {
            get => _participants;
            set { SetProperty(ref _participants, value); }
        }
        public bool _isSharingRemoteVideo;
        public bool IsSharingRemoteVideo
        {
            get => _isSharingRemoteVideo;
            set { SetProperty(ref _isSharingRemoteVideo, value); }
        }
        public CallTemplateViewModel()
        {
            Participants = new ObservableRangeCollection<Participants>(LoadParticipants());
            IsSharingRemoteVideo = false;
        }
        public ObservableRangeCollection<Participants> LoadParticipants()
        {
            return new ObservableRangeCollection<Participants>
            {
                new  Participants{ Name = "Anderson", Image = "avatar2",
                    Speaking = true, Muted = false, IsVideo = false, Video = new Xamarin.Forms.StackLayout() },
                new  Participants{ Name = "Lopes", Image = "avatar6",
                    Speaking = false, Muted = false, IsVideo = false, Video = new Xamarin.Forms.StackLayout() },
                new  Participants{ Name = "Lauro", Image = "avatar5",
                    Speaking = false, Muted = true, IsVideo = false, Video = new Xamarin.Forms.StackLayout() },
                new  Participants{ Name = "Sidney", Image = "avatar3",
                    Speaking = true, Muted = false, IsVideo = false, Video = new Xamarin.Forms.StackLayout() },
                new  Participants{ Name = "Jennifer", Image = "avatar4",
                    Speaking = false, Muted = true, IsVideo = false, Video = new Xamarin.Forms.StackLayout() },
                new  Participants{ Name = "Ryan", Image = "avatar3",
                    Speaking = false, Muted = false, IsVideo = false, Video = new Xamarin.Forms.StackLayout() }
            };
        }

    }
    public class Participants
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public bool Muted { get; set; }
        public bool Speaking { get; set; }
        public bool IsVideo { get; set; }
        public Xamarin.Forms.StackLayout Video { get; set; }
    }
}
