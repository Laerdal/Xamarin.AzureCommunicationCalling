using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TestSample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSample.Droid.Activities
{
    [Activity(Label = "IncomingCallActivity")]
    public class IncomingCallActivity : Activity
    {
        private string username = null;
        private string callUser = null;
        private TextView callerID = null;

        private NotificationManager notifyManager = null;
        IConferenceManagerSpecificPlatform _conferenceManagerSpecificPlatform = ContainerDependencyInjectionService.GetService<IConferenceManagerSpecificPlatform>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.AddFlags(WindowManagerFlags.KeepScreenOn);
            //Window.AddFlags(WindowManagerFlags.ShowWhenLocked | WindowManagerFlags.TurnScreenOn | WindowManagerFlags.TranslucentStatus);
            Window.AddFlags(WindowManagerFlags.Fullscreen | WindowManagerFlags.KeepScreenOn |
                  WindowManagerFlags.TurnScreenOn |
                  WindowManagerFlags.ShowWhenLocked |
                 WindowManagerFlags.DismissKeyguard);
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
        public async void Accept()
        {
           await _conferenceManagerSpecificPlatform.AcceptAsync();
            SetTurnScreenOn(false);

        }
        public async void Reject()
        {
            await _conferenceManagerSpecificPlatform.RejectAsync();
            SetTurnScreenOn(false);

        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
        protected override void OnStop()
        {
            base.OnStop();
        }
    }
}