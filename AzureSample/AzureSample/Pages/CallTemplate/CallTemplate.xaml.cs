using AzureSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AzureSample.Pages.CallTemplate
{
    public partial class CallTemplate : ContentPage
    {
        public CallTemplate()
        {
            InitializeComponent();
        }
        private Stopwatch time = new Stopwatch();
        protected override void OnAppearing()
        {
            var vm = new CallTemplateViewModel();
            BindingContext = vm;
            try
            {
                Task.Run(() =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {

                        time.Start();
                        Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
                        {
                            LoadChonometer();

                            return true;
                        });
                    });
                });
            }
            catch (Exception)
            {

            }
            async void LoadChonometer()
            {
                await timerLabel.TranslateTo(0, -10, 200, Easing.SinInOut);
                await Task.Delay(400);
                timerLabel.Text = time.Elapsed.ToString(@"m\:ss");
                await timerLabel.TranslateTo(0, 0, 200, Easing.SinIn);
            }
            base.OnAppearing();
        }
    }
}