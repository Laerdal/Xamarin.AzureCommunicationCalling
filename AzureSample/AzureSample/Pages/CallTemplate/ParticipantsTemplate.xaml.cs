using System.Collections.Generic;
using Xamarin.Forms;
using AzureSample.Model;
namespace AzureSample.Pages.CallTemplate
{
    public partial class ParticipantsTemplate : ContentView
    {
        private Stack<Color> Colors = new Stack<Color>();

        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
            nameof(Items),
            typeof(IEnumerable<ConferenceParticipantWrapper>),
            typeof(ParticipantsTemplate),
            null,
            defaultBindingMode: BindingMode.OneWay);

        public IEnumerable<ConferenceParticipantWrapper> Items
        {
            get => (IEnumerable<ConferenceParticipantWrapper>)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        public static readonly BindableProperty BasisProperty = BindableProperty.Create(
            nameof(Basis),
            typeof(FlexBasis),
            typeof(ParticipantsTemplate),
            new FlexBasis(.33f),
            defaultBindingMode: BindingMode.TwoWay);

        public FlexBasis Basis
        {
            get => (FlexBasis)GetValue(BasisProperty);
            set => SetValue(BasisProperty, value);
        }

        public ParticipantsTemplate()
        {
            Colors.Push(Color.FromHex("#CC00AB"));
            Colors.Push(Color.FromHex("#FFC700"));
            Colors.Push(Color.FromHex("#007AFF"));
            Colors.Push(Color.FromHex("#009688"));
            Colors.Push(Color.FromHex("#007AFF"));
            Colors.Push(Color.FromHex("#FFC700"));
            Colors.Push(Color.FromHex("#00B22E"));
            Colors.Push(Color.Black);
            InitializeComponent();
        }

        void flexLayout_ChildAdded(object sender, ElementEventArgs e)
        {
            var view = (ParticipantTemplate)e.Element;
            view.ParticipantColor = Colors.Count > 0 ? Colors.Pop() : Color.Aqua;
            SetBasis();
        }

        void flexLayout_ChildRemoved(object sender, ElementEventArgs e)
        {
            var view = (ParticipantTemplate)e.Element;
            Colors.Push(view.ParticipantColor);
            SetBasis();
        }

        void SetBasis()
        {
            float size = .33f;
            if (flexLayout.Children.Count > 6)
            {
                size = .33f;
            }

            if (Basis.Length != size)
            {
                Basis = new FlexBasis(size);
                flexLayout.ForceLayout();
            }
        }
    }
}
