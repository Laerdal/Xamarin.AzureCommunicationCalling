using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.App;
using AzureSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzureSample.Droid.Services
{
    [Service(Label = "com.azure.AzureConferenceSpecificPlatformService", Exported = true, ForegroundServiceType = ForegroundService.TypeMicrophone)]

    public class AzureConferenceSpecificPlatformService : Service
    {
        public const string NewConference = "com.azure.intent.action.Rooms";
        public const string HangUpConference = "com.azure.intent.action.HANG_UP_CONFENRENCE";
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override void OnCreate()
        {
            base.OnCreate();
        }
        private const int NotificationId = 10;

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {

            if (intent == null)
            {
                throw new ArgumentNullException(nameof(intent));
            }
            switch (intent.Action)
            {
                case HangUpConference:
                    StopForeground(true);
                    StopSelf();
                    break;

                case NewConference:
                    var notification = BuildNotification();
                    this.StartForeground(NotificationId, notification);   
                    break;
                default:
                    throw new ArgumentException($"Invalid intent actions: {intent.Action}");
            }

            return StartCommandResult.NotSticky;
        }
        private Notification BuildNotification()
        {
            return new NotificationCompat.Builder(this, VoipChannelNotification.CHANNEL_ID)
                          .SetContentTitle($"In Call")
                          //.SetSmallIcon(Resource.Mipmap)
                          .Build();
        }
    }
}