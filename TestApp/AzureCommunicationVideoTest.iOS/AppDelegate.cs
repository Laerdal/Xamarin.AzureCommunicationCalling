using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using Foundation;
using UIKit;
using UserNotifications;

namespace AzureCommunicationVideoTest.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
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

#if DEBUG
            // Make sure we can debug against a localhost with invalid SSL certificate
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
#endif

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            UNUserNotificationCenter center = UNUserNotificationCenter.Current;
            var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Sound | UNAuthorizationOptions.Provisional;
            center.RequestAuthorization(authOptions, (bool success, NSError error) =>
            {
                if (!success) throw new Exception("No access...");
            });


            return base.FinishedLaunching(app, options);
        }
    }
}
