using System;
using System.Collections.Generic;
using System.Linq;
using AzureSample.Interfaces;
using AzureSample.iOS.Implementations;
using CoreFoundation;
using Foundation;
using Microsoft.Extensions.DependencyInjection;
using PushKit;
using Syncfusion.XForms.iOS.TextInputLayout;
using UIKit;
using UserNotifications;
using Xamarin.Essentials;

namespace AzureSample.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IUNUserNotificationCenterDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Sharpnado.Shades.iOS.iOSShadowsRenderer.Initialize();
            SfTextInputLayoutRenderer.Init();
            Syncfusion.XForms.iOS.Buttons.SfCheckBoxRenderer.Init();
            ContainerDependencyInjectionService.Init(ConfigureServices);
            RegisterForPushNotifications();
            RegisterConferenceNotifications();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
        private void RegisterForPushNotifications()
        {
            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Sound | UNAuthorizationOptions.Badge, (approved, err) =>
            {
                if (approved)
                {

                    MainThread.BeginInvokeOnMainThread(() => UIApplication.SharedApplication.RegisterForRemoteNotifications());
                }
            });
        }

        private void RegisterConferenceNotifications()
        {

            var mainQueue = DispatchQueue.MainQueue;
            PKPushRegistry voipRegistry = new PKPushRegistry(mainQueue)
            {
                Delegate = new ConferenceManagerSpecificPlatformiOS(),
                DesiredPushTypes = new NSSet(new string[] { PKPushType.Voip })
            };
        }
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConferenceManagerSpecificPlatform, ConferenceManagerSpecificPlatformiOS>();
        }
    }
}
