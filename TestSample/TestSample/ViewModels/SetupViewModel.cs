using TestSample.Interfaces;
using TestSample.Model;
using TestSample.Pages;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace TestSample.ViewModels
{
    public class SetupViewModel : BaseViewModel
    {
        public bool _isEnableCamera = false;
        public bool IsEnableCamera
        {
            get => _isEnableCamera;
            set { SetProperty(ref _isEnableCamera, value); }
        }
        public bool _isEnableMicrophone = false;
        public bool IsEnableMicrophone
        {
            get => _isEnableMicrophone;
            set { SetProperty(ref _isEnableMicrophone, value); }
        }
        public AzureSetupRoom _azureSetupRoom;
        public AzureSetupRoom AzureSetup
        {
            get => _azureSetupRoom;
            set { SetProperty(ref _azureSetupRoom, value); }
        }
        public string _codeMeeting;
        public string CodeMeeting
        {
            get => _codeMeeting;
            set { SetProperty(ref _codeMeeting, value); }
        }
        public string _name;
        public string Name
        {
            get => _name;
            set { SetProperty(ref _name, value); }
        }
        public ICommand EnableDisableCameraCommand { get; set; }
        public ICommand EnableDisableMicrophoneCommand { get; set; }
        public ICommand SwitchCameraCommand { get; set; }
        public ICommand JoinOrStartCallCommand { get; set; }

        public SetupViewModel(AzureSetupRoom azureSetupRoom)
        {
            EnableDisableCameraCommand = new Command(() => EnableDisableCamera());
            EnableDisableMicrophoneCommand = new Command(() => EnableDisableMicrophone());
            SwitchCameraCommand = new Command(() => SwitchCamera());
            JoinOrStartCallCommand = new Command(() => JoinOrStartCall());
            IsEnableCamera = false;
            IsEnableMicrophone = true;
            AzureSetup = azureSetupRoom;
            AzureSetup.SelectedCamera = SelectedCamera.Front;
            if (azureSetupRoom.CodeMeeting.Equals("")) CodeMeeting = Guid.NewGuid().ToString();
            else CodeMeeting = azureSetupRoom.CodeMeeting;
            Name = "";
        }

        private void SwitchCamera()
        {
            if (AzureSetup.SelectedCamera == SelectedCamera.Front)
                AzureSetup.SelectedCamera = SelectedCamera.Back;
            else
                AzureSetup.SelectedCamera = SelectedCamera.Front;
        }
        public async void JoinOrStartCall()
        {
            if (IsBusy)
                return;
            if (!await CheckAndAskForCameraPermission() || !await CheckAndAskForStorageReadPermission()|| !await CheckAndAskForMicrophonePermission() || !await CheckAndAskForLocationPermission()|| !await CheckAndAskForStorageWritePermission())
                return;
            if (Name.Equals(""))
                return;
            AzureSetup.MicrophoneEnabled = IsEnableMicrophone;
            AzureSetup.VideoEnabled = IsEnableCamera;
            AzureSetup.CodeMeeting = CodeMeeting;
            await LoadAzure();
            await App.Current.MainPage.Navigation.PushAsync(new CallPage(AzureSetup));

        }
        public async Task LoadAzure()
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                IsBusy = true;
                var token = await AppConfiguration.GetToken();
                var conference = ContainerDependencyInjectionService.GetService<IConferenceManagerSpecificPlatform>();
                if(!conference.Initialized)
                await ContainerDependencyInjectionService.GetService<IConferenceManagerSpecificPlatform>().Init(await AppConfiguration.GetToken(), Name);
                IsBusy = false;
            });
        }
        public async Task<bool> CheckAndAskForCameraPermission()
        {
            return await CheckAndAskPermission<Permissions.Camera>();
        }
        public async Task<bool> CheckAndAskForMicrophonePermission()
        {
            return await CheckAndAskPermission<Permissions.Microphone>();
        }
        public async Task<bool> CheckAndAskForStorageWritePermission()
        {
            return await CheckAndAskPermission<Permissions.StorageWrite>();
        }
        public async Task<bool> CheckAndAskForStorageReadPermission()
        {
            return await CheckAndAskPermission<Permissions.StorageRead>();
        }
        public async Task<bool> CheckAndAskForLocationPermission()
        {
            if (Device.RuntimePlatform == Device.UWP)
                return true;
            return await CheckAndAskPermission<Permissions.LocationWhenInUse>();
        }
        private async Task<bool> CheckAndAskPermission<T>() where T : Permissions.BasePermission, new()
        {
            var status = await Permissions.CheckStatusAsync<T>();
            if (status == PermissionStatus.Granted) return true;

            status = await Permissions.RequestAsync<T>();
            var hasPermission = status == PermissionStatus.Granted;

            return hasPermission;
        }
        public bool Initialized { get; set; } = false;
        private void EnableDisableCamera()
        {
            IsEnableCamera = !IsEnableCamera;
        }
        private void EnableDisableMicrophone()
        {
            IsEnableMicrophone = !IsEnableMicrophone;
        }
    }
}
