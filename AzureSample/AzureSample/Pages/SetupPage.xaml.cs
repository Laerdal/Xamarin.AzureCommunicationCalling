using AzureSample.Model;
using AzureSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AzureSample.Pages
{
    public partial class SetupPage : ContentPage
    {
        SetupViewModel vm;
        public SetupPage(AzureSetupRoom azureSetupRoom)
        {
            InitializeComponent();
            vm = new SetupViewModel(azureSetupRoom);
            BindingContext = vm;
        }
        protected async override void OnAppearing()
        {

            base.OnAppearing();
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.UWP)
                return;
                vm.SwitchCameraCommand.Execute(null);
            if (cameraView.CameraOptions == Xamarin.CommunityToolkit.UI.Views.CameraOptions.Front)
                cameraView.CameraOptions = Xamarin.CommunityToolkit.UI.Views.CameraOptions.Back;
            else
                cameraView.CameraOptions = Xamarin.CommunityToolkit.UI.Views.CameraOptions.Front;
        }
    }
}