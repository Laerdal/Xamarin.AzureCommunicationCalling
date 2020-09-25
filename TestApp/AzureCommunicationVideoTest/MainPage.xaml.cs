using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Xamarin.Forms;

namespace AzureCommunicationVideoTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CallEchoButton.Clicked += CallEchoButton_Clicked;
            CallGroupButton.Clicked += CallGroupButton_Clicked;
        }

        private void CallGroupButton_Clicked(object sender, EventArgs e)
        {
            StartGroupCall().SafeFireAndForget();
        }

        private void CallEchoButton_Clicked(object sender, EventArgs e)
        {
            CallEchoService().SafeFireAndForget();
        }

        private async Task CallEchoService()
        {
            var permissionService = new PermissionService();
            await permissionService.CheckAndAskForCameraPermission();
            await permissionService.CheckAndAskForLocationPermission();
            await permissionService.CheckAndAskForMicrophonePermission();

            var restClient = new RestClient();
            var token = await restClient.GetToken("ios2");

            var videoCalling = Xamarin.Forms.DependencyService.Get<IVideoCalling>();
            await videoCalling.Init(token.Token);
            videoCalling.CallEchoService();
        }

        private async Task StartGroupCall()
        {
            var permissionService = new PermissionService();
            await permissionService.CheckAndAskForCameraPermission();
            await permissionService.CheckAndAskForLocationPermission();
            await permissionService.CheckAndAskForMicrophonePermission();
            
            var restClient = new RestClient();
            var token = await restClient.GetToken("ios2");

            var videoCalling = Xamarin.Forms.DependencyService.Get<IVideoCalling>();
            await videoCalling.Init(token.Token);
            videoCalling.JoinGroup(new Guid("8833bec5-3ec0-41db-8657-c55626b5ee71"));
        }
    }
}
