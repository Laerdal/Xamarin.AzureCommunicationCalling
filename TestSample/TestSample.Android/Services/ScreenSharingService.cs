using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Hardware.Display;
using Android.Media.Projection;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestSample.Droid.Implementations;
using Xamarin.Essentials;

namespace TestSample.Droid.Services
{
    [Service(ForegroundServiceType = Android.Content.PM.ForegroundService.TypeMediaProjection, Exported = true)]
    public class ScreenSharingService : Service
    {
        private HandlerThread _handlerThread = null;
        public ImageReader _imageReader;
        private MediaProjection _mediaProjection;

        private Android.OS.Handler _handler = new Android.OS.Handler();
        public Android.Hardware.Display.VirtualDisplay _virtualDisplay
        {
            get;
            private set;
        }


        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            if (intent.Action == "START_SERVICE")
            {
                RegisterForegroundService();
                StartRecording();
            }
            else if (intent.Action == "STOP_SERVICE")
            {
                StopForeground(true);
                StopSelfResult(startId);
            }
            return StartCommandResult.Sticky;
        }

        public void StartRecording()
        {
            _mediaProjection = ConferenceManagerSpecificPlatformAndroid._mediaProjectionManager.GetMediaProjection((int)ConferenceManagerSpecificPlatformAndroid.ReturnResultFromPermission, ConferenceManagerSpecificPlatformAndroid.ReturnDataFromPermission);

            _handlerThread = new HandlerThread("ScreenCapture");
            _handlerThread.Start();
            _handler = new Android.OS.Handler(_handlerThread.Looper);
            //DisplayMetrics metrics = new DisplayMetrics();
            var windowMetrics = Xamarin.Essentials.Platform.CurrentActivity.WindowManager.CurrentWindowMetrics;
            Android.Graphics.Rect bounds = windowMetrics.Bounds;
            //Xamarin.Essentials.Platform.CurrentActivity.WindowManager.DefaultDisplay.GetRealMetrics(metrics);
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            _imageReader = ImageReader.NewInstance(1280, 720, (ImageFormatType)Android.Graphics.Format.Rgba8888, 20);
            _virtualDisplay = _mediaProjection.CreateVirtualDisplay("CreateVirtual", 1280, 720, (int)mainDisplayInfo.Density, (DisplayFlags)VirtualDisplayFlags.AutoMirror, _imageReader.Surface, null, _handler);
            _imageReader.SetOnImageAvailableListener(ConferenceManagerSpecificPlatformAndroid.frameGenerator, _handler);

        }

        public void StopRecording()
        {
            _handlerThread.Stop();
        }

        private void RegisterForegroundService()
        {
            NotificationChannel chan = new NotificationChannel(
              "ScreenSharingChannel",
              "Screen Sharing foreground service",
              NotificationImportance.Max);

            NotificationManager manager = (NotificationManager)Xamarin.Essentials.Platform.AppContext.GetSystemService(Context.NotificationService);
            manager.CreateNotificationChannel(chan);

            Notification notification = new Notification.Builder(this, "videoChannel")
                .SetContentTitle("Screen Sharing")
                .SetSmallIcon(Resource.Mipmap.icon)
                .SetOngoing(true)
                .Build();

            StartForeground(125, notification);
        }

        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }
    }
}