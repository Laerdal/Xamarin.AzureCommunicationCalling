using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using SKSvg = SkiaSharp.Extended.Svg.SKSvg;

namespace AzureSample.Controls
{
    public class SvgImage : Frame
    {
        #region Private Members

        private readonly SKCanvasView _canvasView = new SKCanvasView();
        public event EventHandler<EventArgs> Clicked;
        #endregion

        #region Bindable Properties

        #region ResourceId

        public static readonly BindableProperty ResourceIdProperty = BindableProperty.Create(
            nameof(ResourceId), typeof(string), typeof(SvgImage), default(string), propertyChanged: RedrawCanvas);

        public string ResourceId
        {
            get => (string)GetValue(ResourceIdProperty);
            set => SetValue(ResourceIdProperty, value);
        }

        #endregion

        #region Command
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command), typeof(ICommand), typeof(SvgImage), propertyChanged: (bindable, oldValue, newValue) => {
                if (bindable is SvgImage svgIcon && newValue is ICommand command)
                {
                    if (svgIcon.GestureRecognizers.Any())
                    {
                        var tapGesture = svgIcon.GestureRecognizers.FirstOrDefault(w => w is TapGestureRecognizer);
                        (tapGesture as TapGestureRecognizer).Tapped -= Tap_Tapped;
                    }

                    svgIcon.GestureRecognizers.Clear();

                    var tap = new TapGestureRecognizer
                    {
                        NumberOfTapsRequired = 1
                    };
                    tap.Tapped += Tap_Tapped;
                    svgIcon.GestureRecognizers.Add(tap);
                }
            });

        internal void OnClicked()
        {
            this.Clicked?.Invoke(this, EventArgs.Empty);
        }

        private static async void Tap_Tapped(object sender, EventArgs e)
        {
            var image = (sender as SvgImage);

            await image?.ScaleTo(1.2, 100);
            await image?.ScaleTo(1, 100);

            image?.Command?.Execute(image.CommandParameter);
            image?.OnClicked();
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }
        #endregion

        #region Command

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            nameof(CommandParameter), typeof(object), typeof(SvgImage));

        public object CommandParameter
        {
            get => (object)GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        #endregion

        #endregion

        #region Constructor

        public SvgImage()
        {
            Padding = new Thickness(0);
            BackgroundColor = Color.Transparent;
            HasShadow = false;
            Content = _canvasView;
            _canvasView.PaintSurface += CanvasViewOnPaintSurface;
            this.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetCanBecomeFirstResponder(true);
        }

        #endregion

        #region Private Methods

        private static void RedrawCanvas(BindableObject bindable, object oldvalue, object newvalue)
        {
            SvgImage svgIcon = bindable as SvgImage;
            svgIcon?._canvasView.InvalidateSurface();
        }

        private void CanvasViewOnPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKCanvas canvas = args.Surface.Canvas;
            canvas.Clear();

            if (string.IsNullOrEmpty(ResourceId))
                return;

            using (Stream stream = GetType().Assembly.GetManifestResourceStream($"AzureSample.Images.{ResourceId}.svg"))
            {
                SKSvg svg = new SKSvg();
                svg.Load(stream);

                SKImageInfo info = args.Info;
                canvas.Translate(info.Width / 2f, info.Height / 2f);

                SKRect bounds = svg.ViewBox;
                float xRatio = info.Width / bounds.Width;
                float yRatio = info.Height / bounds.Height;

                float ratio = Math.Min(xRatio, yRatio);

                canvas.Scale(ratio);
                canvas.Translate(-bounds.MidX, -bounds.MidY);

                canvas.DrawPicture(svg.Picture);
            }
        }
        #endregion
    }
}
