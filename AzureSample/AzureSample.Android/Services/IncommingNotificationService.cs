using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Telecom;
using Android.Views;
using Android.Widget;
using AndroidX.Core.App;
using AzureSample.Droid.Activities;
using AzureSample.Droid.Implementations;
using AzureSample.Interfaces;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzureSample.Droid.Services
{
    [Service(Label = "com.azure.IncommingNotificationService", Exported = true, ForegroundServiceType = ForegroundService.TypePhoneCall)]
    public class IncommingNotificationService : Service
    {
        public string CHANNEL_ID = "VoipChannel";
        public string CHANNEL_NAME = "Voip Channel";
        public const string CALL_RESPONSE_ACTION_KEY = "";
        public const string CALL_RECEIVE_ACTION = "RECEIVE_CALL";
        public const string CALL_CANCEL_ACTION = "CANCEL_ACTION";
        public IncommingNotificationService()
        {

        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Bundle data = null;

            if (intent != null && intent.Extras != null)
            {
                data = intent.GetBundleExtra("key");
            }

            Intent receiveCallAction = new Intent(this, typeof(IncommingNotificationActionReceiver));
            receiveCallAction.SetAction(CALL_RECEIVE_ACTION);




            Intent cancelCallAction = new Intent(this, typeof(IncommingNotificationActionReceiver));
            cancelCallAction.SetAction(CALL_CANCEL_ACTION);




            PendingIntent acceptCallPendingIntent = PendingIntent.GetBroadcast(this, 1200, receiveCallAction, PendingIntentFlags.UpdateCurrent);
            PendingIntent declineCallPendingIntent = PendingIntent.GetBroadcast(this, 1201, cancelCallAction, PendingIntentFlags.UpdateCurrent);
            CreateChannel();
            NotificationCompat.Builder notificationBuilder = null;


            //if (data != null)
            //{
            notificationBuilder = new NotificationCompat.Builder(this, CHANNEL_ID)
                .SetContentText("Call from desktop")
                .SetContentTitle("Incoming Voice Call")
                .SetSmallIcon(Resource.Mipmap.SymDefAppIcon)
                .SetPriority(NotificationCompat.PriorityMax)
                .SetCategory(NotificationCompat.CategoryCall)
                .AddAction(Resource.Mipmap.SymDefAppIcon, "Accept", acceptCallPendingIntent)
                .AddAction(Resource.Mipmap.SymDefAppIcon, "Decline", declineCallPendingIntent)
                .SetAutoCancel(true)
                .SetOngoing(true)
                .SetFullScreenIntent(acceptCallPendingIntent, true);
            //}
            Notification incomingCallNotification = null;

            if (notificationBuilder != null)
            {
                incomingCallNotification = notificationBuilder.Build();

            }
            StartForeground(120, incomingCallNotification);
            return StartCommandResult.Sticky;
        }
    
        public void CreateChannel()
        {
            var notificationManager = (NotificationManager)this.GetSystemService(Context.NotificationService);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {

                var channelNameJava = new Java.Lang.String(CHANNEL_NAME);

                NotificationChannel channel = new NotificationChannel(CHANNEL_ID, channelNameJava, NotificationImportance.High);
                channel.Description = "Call Notifications";
                channel.LockscreenVisibility = NotificationVisibility.Public;

                //channel.SetSound(Uri.parse("android.resource://" + .PackageName() + "/" + R.raw.voip_ringtone),
                //new Android.Media.AudioAttributes.Builder().SetContentType(Android.Media.AudioContentType.Sonification)
                //        .SetLegacyStreamType(AudioManager.STREAM_RING)
                //        .setUsage(AudioAttributes.USAGE_VOICE_COMMUNICATION).build());
                notificationManager.CreateNotificationChannel(channel);


            }
        }
        public void Show(string title, string message)
        {
            Intent intent = new Intent(Android.App.Application.Context, typeof(MainActivity));
            intent.PutExtra("", title);
            intent.PutExtra("", message);

            var color = Android.Graphics.Color.Red;
            var notificationLayout = new RemoteViews(Android.App.Application.Context.PackageName, 2131427378);
            PendingIntent pendingIntent = PendingIntent.GetActivity(Android.App.Application.Context, 0, intent, PendingIntentFlags.UpdateCurrent);
            NotificationCompat.Builder builder = new NotificationCompat.Builder(Android.App.Application.Context, CHANNEL_ID)
                .SetContentIntent(pendingIntent)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetColor(color)
                .SetColorized(true)
                .SetStyle(new AndroidX.Media.App.NotificationCompat.MediaStyle())
                .SetCustomContentView(notificationLayout)
                .SetCustomBigContentView(notificationLayout)
                //.SetLargeIcon(BitmapFactory.DecodeResource(Android.App.Application.Context.Resources, Resource.Drawable.notification_template_icon_bg))
                //.SetSmallIcon(Resource.Drawable.notification_template_icon_bg)
                .SetDefaults((int)NotificationDefaults.Sound | (int)NotificationDefaults.Vibrate)
                .SetPriority((int)NotificationPriority.Max);



            Notification notification = builder.Build();
            //manager.Notify(messageId++, notification);
        }

    }
    [BroadcastReceiver(Enabled = true, Exported = true)]
    public class IncommingNotificationActionReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action != null)
            {
                PerformClickAction(context, intent.Action);
            }
            Intent it = new Intent(Intent.ActionCloseSystemDialogs);
            context.SendBroadcast(it);
            context.StopService(new Intent(context, typeof(IncommingNotificationService)));

        }
        private async void PerformClickAction(Context context, String action)
        {
            IConferenceManagerSpecificPlatform _conferenceManagerSpecificPlatform = ContainerDependencyInjectionService.GetService<IConferenceManagerSpecificPlatform>();
            if (action.Equals(IncommingNotificationService.CALL_RECEIVE_ACTION))
            {
                try
                {
                    await _conferenceManagerSpecificPlatform.AcceptAsync();
                    Intent openIntent = null;
                    openIntent = new Intent(context, typeof(MainActivity));
                    openIntent.AddFlags(ActivityFlags.NewTask);
                    context.StartActivity(openIntent);
                }
                catch (Exception)
                {
                    //
                }
            }
            else if (action.Equals(IncommingNotificationService.CALL_CANCEL_ACTION))
            {
                await _conferenceManagerSpecificPlatform.RejectAsync();
                context.StopService(new Intent(context, typeof(IncommingNotificationService)));
                //if android api <= 30
                Intent it = new Intent(Intent.ActionCloseSystemDialogs);
                context.SendBroadcast(it);
            }
        }
    }
}



