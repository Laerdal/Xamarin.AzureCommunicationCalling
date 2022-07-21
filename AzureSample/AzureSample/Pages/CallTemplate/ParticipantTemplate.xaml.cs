using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;
namespace AzureSample.Pages.CallTemplate
{
    public partial class ParticipantTemplate : ContentView
    {
        static Regex initialsRegex = new Regex(@"(\b[a-zA-Z])[a-zA-Z]* ?", RegexOptions.Compiled);

        public static readonly BindableProperty ParticipantNameProperty = BindableProperty.Create(
            nameof(ParticipantName),
            typeof(string),
            typeof(ParticipantTemplate),
            string.Empty,
            BindingMode.OneWay);

        public string ParticipantName
        {
            get => (string)GetValue(ParticipantNameProperty);
            set => SetValue(ParticipantNameProperty, value);
        }

        public static readonly BindableProperty ParticipantAvatarProperty = BindableProperty.Create(
            nameof(ParticipantAvatar),
            typeof(string),
            typeof(ParticipantTemplate),
            null,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: AvatarPropertyChanged);

        public string ParticipantAvatar
        {
            get => (string)GetValue(ParticipantAvatarProperty);
            set => SetValue(ParticipantAvatarProperty, value);
        }

        public static readonly BindableProperty ParticipantColorProperty = BindableProperty.Create(
            nameof(ParticipantColor),
            typeof(Color),
            typeof(ParticipantTemplate),
            Color.Black,
            defaultBindingMode: BindingMode.OneWay);

        public Color ParticipantColor
        {
            get => (Color)GetValue(ParticipantColorProperty);
            set => SetValue(ParticipantColorProperty, value);
        }

        public static readonly BindableProperty ParticipantMicrophoneMutedProperty = BindableProperty.Create(
            nameof(ParticipantMicrophoneMuted),
            typeof(bool),
            typeof(ParticipantTemplate),
            false,
            BindingMode.OneWay);

        public bool ParticipantMicrophoneMuted
        {
            get => (bool)GetValue(ParticipantMicrophoneMutedProperty);
            set => SetValue(ParticipantMicrophoneMutedProperty, value);
        }  
        public static readonly BindableProperty VideoStreamProperty = BindableProperty.Create(
            nameof(VideoStream),
            typeof(StackLayout),
            typeof(ParticipantTemplate),
            new StackLayout(),
            BindingMode.OneWay);

        public StackLayout VideoStream
        {
            get => (StackLayout)GetValue(VideoStreamProperty);
            set => SetValue(VideoStreamProperty, value);
        }

        public ParticipantTemplate()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }

        private static void AvatarPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ParticipantTemplate)bindable;
            if (newValue != null)
            {
                //control.avatar.Source = AvatarHelper.GetApiUrl(newValue.ToString());
            }
        }            
    }
}
