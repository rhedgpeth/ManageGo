using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace ManageGo.Controls
{
	public class ListRunnerView : SKCanvasView
    {
		public static readonly BindableProperty FirstColorProperty = BindableProperty.Create(nameof(FirstColor),
                                                                                        typeof(Color),
		                                                                                     typeof(ListRunnerView),
                                                                                        Color.White);


        public Color FirstColor
        {
            get { return (Color)GetValue(FirstColorProperty); }
            set { SetValue(FirstColorProperty, value); }
        }

        public static readonly BindableProperty SecondColorProperty = BindableProperty.Create(nameof(SecondColor),
		                                                                                      typeof(Color),
		                                                                                      typeof(ListRunnerView),
                                                                                        Color.White);


        public Color SecondColor
        {
            get { return (Color)GetValue(SecondColorProperty); }
            set { SetValue(SecondColorProperty, value); }
        }

        public ListRunnerView()
        { }

		protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
		{
			SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

			canvas.Clear(Color.White.ToSKColor());
      
            var point1 = new SKPoint(10, 0);
            var point2 = new SKPoint(10, 50);
			var point3 = new SKPoint(10, info.Height);
            
            var paint1 = new SKPaint { StrokeWidth = 3, Color = FirstColor.ToSKColor() };
			var paint2 = new SKPaint { StrokeWidth = 3, Color = SecondColor.ToSKColor() };

            canvas.DrawLine(point1, point2, paint1);         
			canvas.DrawCircle(point2, 10, paint2);         
			canvas.DrawLine(point2, point3, paint2);
		}
	}
}
