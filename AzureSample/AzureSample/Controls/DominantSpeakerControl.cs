using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AzureSample.Controls
{
    public class DominantSpeakerControl : SKCanvasView
    {
        public bool IsRun;
        private SKBitmap _resourceBitmap;
        private double _cycleTime = 30000;
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private readonly float[] _t = new float[3];
        private readonly SKPaint _paint = new SKPaint
        {
            Style = SKPaintStyle.Stroke
        };

        public static readonly BindableProperty PulseColorProperty = BindableProperty.Create(nameof(PulseColor), typeof(Color), typeof(DominantSpeakerControl), Color.Red, propertyChanged: OnPropertyChanged);
        public static readonly BindableProperty AutoStartProperty = BindableProperty.Create(nameof(AutoStart), typeof(bool), typeof(DominantSpeakerControl), false, propertyChanged: OnPropertyChanged);
        public static readonly BindableProperty IsRunningProperty = BindableProperty.Create(nameof(IsRunningProperty), typeof(bool), typeof(DominantSpeakerControl), true, propertyChanged: OnPropertyChanged);
        public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string), typeof(DominantSpeakerControl), "", propertyChanged: OnPropertyChanged);
        public static readonly BindableProperty SpeedProperty = BindableProperty.Create(nameof(Speed), typeof(int), typeof(DominantSpeakerControl), 10, propertyChanged: OnPropertyChanged);

        public Color PulseColor
        {
            get => (Color)GetValue(PulseColorProperty);
            set => SetValue(PulseColorProperty, value);
        }

        public bool AutoStart
        {
            get => (bool)GetValue(AutoStartProperty);
            set => SetValue(AutoStartProperty, value);
        }
        public bool IsRunning
        {
            get => (bool)GetValue(IsRunningProperty);
            set => SetValue(IsRunningProperty, value);
        }

        public string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }
        public int Speed
        {
            get => (int)GetValue(SpeedProperty);
            set
            {
                SetValue(SpeedProperty, value);
                _cycleTime *= value;
            }
        }

        public DominantSpeakerControl()
        {
            _cycleTime /= Speed;
        }

        private static void OnPropertyChanged(BindableObject bindable, object oldVal, object newVal)
        {
            var pulse = bindable as DominantSpeakerControl;
            pulse?.InvalidateSurface();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(Speed):
                    _cycleTime /= Speed;
                    break;
                case nameof(AutoStart):
                    {
                        if (AutoStart) Start();
                        break;
                    }
                case nameof(Source):
                    {
                        string resourceId = Source;
                        Assembly assembly = GetType().GetTypeInfo().Assembly;

                        using (Stream stream = assembly.GetManifestResourceStream(resourceId))
                        {
                            if (stream != null) _resourceBitmap = SKBitmap.Decode(stream);
                        }

                        _resourceBitmap = _resourceBitmap?.Resize(new SKImageInfo(90, 90), SKFilterQuality.Medium);
                        break;
                    }
            }
        }
        public void Start()
        {
            IsRun = true;
            _stopwatch.Start();
            Device.StartTimer(TimeSpan.FromMilliseconds(33), () =>
            {
                _t[0] = (float)(_stopwatch.Elapsed.TotalMilliseconds % _cycleTime / _cycleTime);
                if (_stopwatch.Elapsed.TotalMilliseconds > _cycleTime / 3) _t[1] = (float)((_stopwatch.Elapsed.TotalMilliseconds - _cycleTime / 3) % _cycleTime / _cycleTime);
                if (_stopwatch.Elapsed.TotalMilliseconds > _cycleTime * 2 / 3) _t[2] = (float)((_stopwatch.Elapsed.TotalMilliseconds - _cycleTime * 2 / 3) % _cycleTime / _cycleTime);

                InvalidateSurface();

                if (!IsRun)
                {
                    _stopwatch.Stop();
                    _stopwatch.Reset();
                }

                return IsRun;
            });
        }
        protected override void OnPaintSurface(SKPaintSurfaceEventArgs args)
        {
            base.OnPaintSurface(args);
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
            var r = (byte)(PulseColor.R * 255);
            var g = (byte)(PulseColor.G * 255);
            var b = (byte)(PulseColor.B * 255);
            canvas.Clear();

            if (IsRunning)
            {
                var center = new SKPoint(info.Width / 2, info.Height / 2);

                foreach (float t in _t)
                {
                    float radius = info.Width / 2 * (t);
                    _paint.Color = new SKColor(r, g, b, (byte)(255 * (1 - t)));
                    _paint.Style = SKPaintStyle.Fill;
                    canvas.DrawCircle(center.X, center.Y, radius, _paint);
                }

                _paint.Color = new SKColor(r, g, b);
                canvas.DrawCircle(center.X, center.Y, 20, _paint);
                if (_resourceBitmap != null) canvas.DrawBitmap(_resourceBitmap, center.X - _resourceBitmap.Width / 2, center.Y - _resourceBitmap.Height / 2);
            }
        }
    }
}