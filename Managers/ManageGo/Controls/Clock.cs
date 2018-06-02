using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace ManageGo.Controls
{
	public class Clock : SKCanvasView
    {
        SKPaint blackStrokePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 1,
            StrokeCap = SKStrokeCap.Round
        };

		SKPaint blueStrokePaint = new SKPaint
		{
			Style = SKPaintStyle.StrokeAndFill,
			Color = SKColor.Parse("#3E90F4"),
			StrokeWidth = 2,
			StrokeCap = SKStrokeCap.Round
		};
      
        public Clock()
        {
			EnableTouchEvents = false;
		}

		bool _started = false;

        void Start()
		{
			_started = true;

			Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                //InvalidateSurface();
                return true;
            });
		}
           
		SKCanvas canvas;

		protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            canvas = surface.Canvas;
         
            canvas.Clear(Color.White.ToSKColor());
                     
			int width = e.Info.Width;
            int height = e.Info.Height;

            // Set transforms
            canvas.Translate(width / 2, height / 2);
            
            canvas.DrawCircle(0, 0, info.Width / 2, blackStrokePaint);

			canvas.DrawCircle(0, 0, 20, new SKPaint { Color = SKColor.Parse("#3E90F4"), Style = SKPaintStyle.Fill });

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
                    
					canvas.DrawText(count.ToString(), new SKPoint(-(textPaint.MeasureText(count.ToString()) / 2),
					                                              -(info.Height / 2 - 60)), textPaint);
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

			// Get DateTime
            var dateTime = DateTime.Now;
            
			// Second hand
            canvas.Save();
            
			var newAngle = CurrentAngle + 7.5f;

			Console.WriteLine($"ANGLE = {newAngle}");

            canvas.RotateDegrees(newAngle);

			CurrentAngle = newAngle;

			canvas.DrawLine(0, 10, 0, -(info.Height / 2 - 50), blueStrokePaint);

			// Draw Arc
            SKPaint skPaint = new SKPaint()
            {
                Style = SKPaintStyle.StrokeAndFill,
                Color = SKColors.BlueViolet,
                StrokeWidth = 10,
                IsAntialias = true,
            };
            
            _draggableEndCircle = new SKRect();
			_draggableEndCircle.Size = new SKSize(10, 10);
			_draggableEndCircle.Location = new SKPoint(-5, -(info.Height / 2 - 50));

            float startAngle = -90;
            float sweepAngle = 360; // (75 / 100) * 360
            
            SKPath skPath = new SKPath();
            skPath.AddArc(_draggableEndCircle, startAngle, sweepAngle);

            canvas.DrawPath(skPath, skPaint);

			SKCanvas circle = new SKCanvas(new SKBitmap());

			//canvas.DrawCircle(0, -(info.Height / 2 - 50), 10, blueStrokePaint);

			canvas.Restore();
            
            if (!_started)
			    Start();
        }

		SKRect _draggableEndCircle;

        public bool ContainsPoint(SKPoint point)
		{
			canvas.RotateDegrees(CurrentAngle);

			var containsPoint = _draggableEndCircle.Contains(point);

			canvas.Restore();

			return containsPoint;
		}
      
		float _currentAngle = 0f;
        float CurrentAngle
		{
			get
			{
				if (_currentAngle >= 360)
					_currentAngle = 0;

				return _currentAngle;
			}
			set => _currentAngle = value;
		}
	}
}
