using System;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AzureCommunicationVideoTest
{
    public partial class MainPage
    {
        private readonly IACSCallingManager _callingManager;
        private string _token;
        private readonly RestClient _restClient;

        public MainPage()
        {
            InitializeComponent();
            _restClient = new RestClient();
            CallEchoButton.Clicked += CallEchoButton_Clicked;
            CallGroupButton.Clicked += CallGroupButton_Clicked;
            CallPhoneButton.Clicked += CallPhoneButtonOnClicked;
            GetTokenButton.Clicked += GetTokenButtonOnClicked;
            HangupButton.Clicked += HangupButton_Clicked;
            _callingManager = DependencyService.Get<IACSCallingManager>();
            _callingManager.LocalVideoAdded += delegate(object sender, View view)
            {
                Device.BeginInvokeOnMainThread(() => LocalVideoView.Content = view);
            };
            _callingManager.RemoteVideoAdded += delegate (object sender, View view)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Logger.Debug("Adding remote video");
                    // Add the new view to stack layout
                    RemoteVideoView.Children.Add(new Frame
                    {
                        Content = view,
                        BackgroundColor = GetAlternateBg()
                    });

                    // Calculate sizes based on screen and number of remotes
                    var totalCount = RemoteVideoView.Children.Count;
                    var width = DeviceDisplay.MainDisplayInfo.Width;
                    var height = DeviceDisplay.MainDisplayInfo.Height / totalCount;

                    // Apply size to new view and all existing
                    foreach (var child in RemoteVideoView.Children)
                    {
                        child.HeightRequest = height;
                        child.WidthRequest = width;
                    }
                    Logger.Debug($"Added remote video: {height} x {width}");
                });
            };
        }

        private int _bgColorIx;
        private Color GetAlternateBg()
        {
            _bgColorIx++;
            return _bgColorIx % 3 == 0 ? Color.Red : _bgColorIx % 2 == 0 ? Color.Aqua : Color.Crimson;
        }

        private void HangupButton_Clicked(object sender, EventArgs e)
        {
            LocalVideoView.Content = null;
            RemoteVideoView.Children.Clear();
            _callingManager.Hangup();
        }

        private void GetTokenButtonOnClicked(object sender, EventArgs e)
        {
            GetTokenAndInitACS().SafeFireAndForget();
        }

        private async Task GetTokenAndInitACS()
        {
            Device.BeginInvokeOnMainThread(() => Spinner.IsVisible = true);
            try
            {
                try
                {
                    _token = (await _restClient.GetToken("ios2")).Token;
                }
                catch (Exception e)
                {
                    Popup("Error", $"Failed to get token: {e.Message}");
                    return;
                }

                try
                {
                    await _callingManager.Init(_token);
                }
                catch (Exception e)
                {
                    Popup("Error", $"Failed to init ACS: {e.Message}");
                    return;
                }
                Popup("Success", "Got token and initialized ACS");
                CallEchoButton.IsEnabled = CallPhoneButton.IsEnabled = CallGroupButton.IsEnabled = HangupButton.IsEnabled = true;
            }
            finally
            {
                Device.BeginInvokeOnMainThread(() => Spinner.IsVisible = false);
            }
        }

        private void Popup(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() => DisplayAlert(title, message, "OK"));
        }

        private void CallPhoneButtonOnClicked(object sender, EventArgs e)
        {
            StartPhoneCall().SafeFireAndForget();
        }
        
        private void CallGroupButton_Clicked(object sender, EventArgs e)
        {
            StartGroupCall().SafeFireAndForget();
        }

        private void CallEchoButton_Clicked(object sender, EventArgs e)
        {
            CallEchoService().SafeFireAndForget();
        }

        private async Task AskForPermissions()
        {
            var permissionService = new PermissionService();
            await permissionService.CheckAndAskForCameraPermission();
            await permissionService.CheckAndAskForLocationPermission();
            await permissionService.CheckAndAskForMicrophonePermission();
        }

        private async Task CallEchoService()
        {
            await AskForPermissions();
            
            var videoCalling = DependencyService.Get<IACSCallingManager>();
            videoCalling.CallEchoService();
        }

        private async Task StartGroupCall()
        {
            await AskForPermissions();

            var groupId = GroupEntry.Text;
            var groupIdGuid = new Guid(groupId);
            
            _callingManager.JoinGroup(groupIdGuid).SafeFireAndForget();
        }
        private async Task StartPhoneCall()
        {
            await AskForPermissions();
            var phoneNumber = PhoneEntry.Text;
            
            _callingManager.CallPhone(phoneNumber);

        }
    }
}
