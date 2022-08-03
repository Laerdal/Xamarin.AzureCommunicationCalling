using TestSample.Interfaces;
using TestSample.Pages;
using TestSample.Pages.CallTemplate;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(AppConfiguration.SyncfusionLicense);
            MainPage = new NavigationPage(new IntroPage());

        }

        protected override void OnStart()
        {


        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
