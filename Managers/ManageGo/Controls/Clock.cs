using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace ManageGo.Controls
{
	public class Clock : SKCanvasView
    {
		SKPaint blackFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black
        };

        SKPaint whiteStrokePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.White,
            StrokeWidth = 2,
            StrokeCap = SKStrokeCap.Round,
            IsAntialias = true
        };

        SKPaint whiteFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.White
        };

        SKPaint greenFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.PaleGreen
        };

        SKPaint blackStrokePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 1,
            StrokeCap = SKStrokeCap.Round
        };

        SKPaint grayFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Gray
        };

        SKPaint backgroundFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill
        };

        public Clock()
        { }

		protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(Color.White.ToSKColor());
                     
			int width = e.Info.Width;
            int height = e.Info.Height;

            // Set transforms
            canvas.Translate(width / 2, height / 2);
            
            canvas.DrawCircle(0, 0, info.Width / 2, blackStrokePaint);

			canvas.DrawCircle(0, 0, 10, new SKPaint { Color = SKColor.Parse("#3E90F4"), Style = SKPaintStyle.Fill });

			var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke
            };

			int count = 0;

            // Hour and minute marks
			for (float angle = 0f; angle < 360.0; angle += 7.5f)
            {              
                if (angle % 30 == 0)
				{
					paint.Color = SKColor.Parse("#3E90F4");
					paint.StrokeWidth = 4;

					var textPaint = new SKPaint
					{
						Style = SKPaintStyle.Fill,
						Color = SKColor.Parse("#A7A9AC"),
                        TextSize = 24
					};

					//canvas.Save();
					//canvas.RotateDegrees(-30);

					canvas.DrawText(count.ToString(), new SKPoint(-(textPaint.MeasureText(count.ToString()) / 2),
					                                              -(info.Height / 2 - 60)), textPaint);
                    //canvas.Restore();
                                   
					count++;
				}
				else
				{
					paint.Color = SKColor.Parse("#A7A9AC");
					paint.StrokeWidth = 2;
				}

				canvas.DrawLine(0, -(info.Height / 2 - 30), 0, -(info.Height / 2  - 10), paint);

                canvas.RotateDegrees(7.5f);
            }

			canvas.Restore();
        }
    }
}
