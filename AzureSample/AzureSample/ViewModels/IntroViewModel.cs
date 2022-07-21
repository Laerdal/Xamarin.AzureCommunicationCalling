using AzureSample.Model;
using AzureSample.Pages;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AzureSample.ViewModels
{
    public class IntroViewModel:BaseViewModel
    {
        public ICommand JoinCommand { get; set; }
        public ICommand StartCommand { get; set; }
        public AzureSetupRoom _azureSetup;
        public AzureSetupRoom AzureSetup
        {
            get => _azureSetup;
            set { SetProperty(ref _azureSetup, value); }
        }
        public IntroViewModel()
        {
            JoinCommand = new Command(Join);
            StartCommand = new Command(Start);
        }

        private async void Join()
        {
            await App.Current.MainPage.Navigation.PushAsync(new JoinCallPage());

        }
        private async void Start()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SetupPage(new Model.AzureSetupRoom(false, true, TypeCall.Group, SelectedCamera.Front, TypeSpeaker.Default, "", "")));

        }
    }
}
