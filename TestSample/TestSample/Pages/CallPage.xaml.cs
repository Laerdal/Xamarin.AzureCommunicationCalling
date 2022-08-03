using TestSample.Model;
using TestSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestSample.Pages
{
    public partial class CallPage : ContentPage
    {
        public CallPage(AzureSetupRoom azureSetupRoom)
        {
            InitializeComponent();
            var vm = new CallViewModel();
            BindingContext = vm;
            vm.InitializeAsync(azureSetupRoom);
        }
        protected override void OnAppearing()
        {

            
            base.OnAppearing();
        }
    }
}