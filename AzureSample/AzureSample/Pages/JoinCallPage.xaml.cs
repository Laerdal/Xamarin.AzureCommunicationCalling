using AzureSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AzureSample.Pages
{
    public partial class JoinCallPage : ContentPage
    {

        public JoinCallPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            BindingContext = new  JoinCallViewModel();
            base.OnAppearing();
        }       
    }
}