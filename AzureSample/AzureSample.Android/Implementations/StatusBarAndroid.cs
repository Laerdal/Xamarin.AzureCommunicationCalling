using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzureSample.Droid.Implementations
{
    public class StatusBarAndroid
    {
        public void HideStatusBar()
        {
            Xamarin.Essentials.Platform.CurrentActivity.Window.AddFlags(WindowManagerFlags.Fullscreen);
        }

        public void ShowStatusBar()
        {
   
            Xamarin.Essentials.Platform.CurrentActivity.Window.ClearFlags(WindowManagerFlags.Fullscreen);
        }
    }
}