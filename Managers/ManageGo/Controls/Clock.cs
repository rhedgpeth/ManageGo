using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace ManageGo.Controls
{
	public class Clock : SKCanvasView
    {
		const float AngleIncrement = 7.5f;

		SKPaint blueStrokePaint = new SKPaint
		{
			Style = SKPaintStyle.StrokeAndFill,
			Color = SKColor.Parse("#3E90F4"),
			StrokeWidth = 4,
			StrokeCap = SKStrokeCap.Round
		};

		SKPaint greyStrokePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColor.Parse("#939598"),
            StrokeWidth = 1,
            StrokeCap = SKStrokeCap.Round
        };

		SKPaint greyFillPaint = new SKPaint
        {
            Style = SKPaintStyle.StrokeAndFill,
			Color = SKColor.Parse("#939598"),
            StrokeWidth = 1,
            StrokeCap = SKStrokeCap.Round
        };

		SKPaint lightGreyStrokePaint = new SKPaint
        {
            Style = SKPaintStyle.StrokeAndFill,
			Color = SKColor.Parse("#A7A9AC"),
            StrokeWidth = 1,
            StrokeCap = SKStrokeCap.Round
        };

		SKImageInfo info;
		SKPoint? _selectedPoint;
        SKColor _selectedColor;

		public Action<DateTime> TimeChanged { get; set; }
        public DateTime SelectedTime { get; set; }

        SKPoint? _lastDragPoint;

		float _currentAngle;
        float CurrentAngle
        {
            get
            {
                return _currentAngle;
            }
            set
            {
                if (value >= 720 || value <= -30)
                    return;

                _currentAngle = value;
            }
        }
        
        public Clock()
        {
			EnableTouchEvents = false;
		}
      
		SKImageInfo _sampleBitmapImageInfo;



		protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
		{
			info = e.Info;
            
			SKSurface surface = e.Surface;
			SKCanvas canvas = surface.Canvas;

			if (_sampleBitmapImageInfo.IsEmpty)
			{
				_sampleBitmapImageInfo = new SKImageInfo
				{
					ColorType = info.ColorType,
					AlphaType = info.AlphaType,
					Width = 1,
					Height = 1
				};
			}

			lightGreyStrokePaint.TextSize = (int)(info.Height * .05);

			if (_selectedPoint.HasValue)
            {
                _selectedColor = GetColorAtPoint(surface, (int)_selectedPoint.Value.X, (int)_selectedPoint.Value.Y);
                _selectedPoint = null;
            }

			canvas.Clear(Color.White.ToSKColor());

			int width = e.Info.Width;
			int height = e.Info.Height;

            int count = 0;


            for (float angle = 0f; angle < 360.0; angle += AngleIncrement)
            {
                if (angle % 30 == 0)
                {
                    //canvas.DrawText()

                    //canvas.RotateDegrees(40);

                    //canvas.RotateDegrees(45, 20, 20);

                    angle *= (float)Math.PI / 180f;


                    //x' = x + (d * cos(a))
                    //y' = y + (d * sin(a))

                    var x = (info.Height / 2) + (((info.Height / 2) - (info.Height * .055f)) * (float)Math.Cos(angle));
                    var y = (info.Height / 2) + (((info.Height / 2) - (info.Height * .02f)) * (float)Math.Sin(angle));

                    var point = new SKPoint(x, y);

                    //point += new SKPoint(info.Height / 2, info.Height / 2);

                    //canvas.DrawText(count.ToString(), point, lightGreyStrokePaint);

                    //canvas.RotateDegrees(-40);
                    //canvas.RotateDegrees(-45, 20, 20);

                    //canvas.DrawLine(0, -(info.Height / 2 - (info.Height * .055f)), 0, -(info.Height / 2 - (info.Height * .02f)), blueStrokePaint);

                    count++;
                }
                //else
                //{
                //canvas.DrawLine(0, -(info.Height / 2 - (info.Height * .055f)), 0, -(info.Height / 2 - (info.Height * .02f)), greyStrokePaint);
                //}

                //canvas.RotateDegrees(AngleIncrement);
            }


			// Move out half the distance of the canvas (both X and Y)
			canvas.Translate(width / 2, height / 2);

            // Draw the clock outline
			canvas.DrawCircle(0, 0, info.Height / 2, greyStrokePaint);

			// Draw the center circle
			canvas.DrawCircle(0, 0, (info.Height * .04f), new SKPaint { Color = SKColor.Parse("#3E90F4"), Style = SKPaintStyle.Fill });

            count = 0;

			// Draw the hash marks
			for (float angle = 0f; angle < 360.0; angle += AngleIncrement)
			{
				if (angle % 30 == 0)
				{ 
					canvas.DrawText(count.ToString(), new SKPoint(-(lightGreyStrokePaint.MeasureText(count.ToString()) / 2),
																  -(info.Height / 2f - (info.Height * .11f))), lightGreyStrokePaint);

					canvas.DrawLine(0, -(info.Height / 2 - (info.Height * .055f)), 0, -(info.Height / 2 - (info.Height * .02f)), blueStrokePaint);

					count++;
				}
				else
				{
					canvas.DrawLine(0, -(info.Height / 2 - (info.Height * .055f)), 0, -(info.Height / 2 - (info.Height * .02f)), greyStrokePaint);
				}            

				canvas.RotateDegrees(AngleIncrement);
			}
                     
			canvas.Save(); 

			// Rotate the canvas to the angle specified (via drag)
			canvas.RotateDegrees(CurrentAngle);    

            // Draw the clock hand
			canvas.DrawLine(0, (info.Height * .02f), 0, -(info.Height / 2 - (info.Height * .15f)), blueStrokePaint);         
			canvas.DrawCircle(0, -(info.Height / 2 - (info.Height * .15f)), (info.Height * .02f), blueStrokePaint);

            // Draw right triangle       
			DrawTriagle(canvas,
						new SKPoint((float)(info.Height * .02), (float)-(info.Height / 2 - (info.Height * .25))),
			            new SKPoint((float)(info.Height * .02), (float)-(info.Height / 2 - (info.Height * .2))),
			            new SKPoint((float)(info.Height * .045), (float)-(info.Height / 2 - (info.Height *.225))),
						greyFillPaint);

            // Draw left triangle
			DrawTriagle(canvas,
			            new SKPoint((float)-(info.Height * .02), (float)-(info.Height / 2 - (info.Height * .25))),
			            new SKPoint((float)-(info.Height * .02), (float)-(info.Height / 2 - (info.Height * .2))),
			            new SKPoint((float)-(info.Height * .045), (float)-(info.Height / 2 - (info.Height * .225))),
                        greyFillPaint);
			         
			canvas.Restore();

            count = 0;
		}
        
		void DrawTriagle(SKCanvas canvas, SKPoint point1, SKPoint point2, SKPoint point3, SKPaint paint)
		{
			using (var path = new SKPath())
			{
				path.MoveTo(point1);
				path.LineTo(point1);
				path.LineTo(point2);
				path.LineTo(point3);
				path.Close();

				canvas.DrawPath(path, paint);
			}
		}

		double AngleToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }      
      
        SKColor GetColorAtPoint(SKSurface surface, int x, int y)
		{         
            // create the 1x1 bitmap (auto allocates the pixel buffer)
            var bitmap = new SKBitmap(_sampleBitmapImageInfo);
            
            // get the pixel buffer for the bitmap
            var pixels = bitmap.GetPixels();
            
            // read the surface into the bitmap
			surface.ReadPixels(_sampleBitmapImageInfo, pixels, _sampleBitmapImageInfo.RowBytes, x, y);
                       
			return bitmap.GetPixel(0, 0);
		}
      
		public void Drag(SKPoint point)
		{
			int targetX = info.Width / 2;
			int targetY = info.Height / 2;

			double x0, y0, x, y;
                     
			if (_lastDragPoint.HasValue)
			{
				x0 = _lastDragPoint.Value.X;
                y0 = _lastDragPoint.Value.Y;
                
                x = point.X;
                y = point.Y;

                var angle2 = -Math.Atan2(targetY - y, targetX - x) - Math.Atan2(targetY - y0, targetX - x0);
                angle2 = angle2 * 360 / (2 * Math.PI);


                var angle0 = -(Math.Atan2(-targetY, 0) - Math.Atan2(y0 - targetY, x0 - targetX));
                angle0 = angle0 * (180.0 / Math.PI);

                if (angle0 < 0)
                {
                    angle0 = angle0 + 360;
                }

				var angle = -(Math.Atan2(-targetY, 0) - Math.Atan2(y - targetY, x - targetX));
                            
				angle = angle * (180.0 / Math.PI);

				if (angle < 0)
                {
                    angle = angle + 360;
                }

				var dAngle = angle - angle0;

                if (dAngle > 0)
				{
					var newAngle = CurrentAngle + AngleIncrement;

                    if (angle > newAngle)
					{
						CurrentAngle = newAngle;
					}
                    else
                    {
                        var adjustedAngle = 360 + angle;

                        if (adjustedAngle > newAngle)
                        {
                            CurrentAngle = newAngle;
                        }
                    }
				}
				else if (dAngle < 0)
				{
					var newAngle = CurrentAngle - AngleIncrement;

					if (angle < newAngle)
					{
						CurrentAngle = newAngle;
					}
                    {
                        var adjustedAngle = angle - 360;

                        if (adjustedAngle < newAngle)
                        {
                            CurrentAngle = newAngle;
                        }
                    }
				}
            
				_lastDragPoint = point;

				InvalidateSurface();
			}
			else
			{            
				_lastDragPoint = point;
			}         
            
			var timeDecimal = ((decimal)CurrentAngle / (decimal)30.0);

            var timeArr = timeDecimal.ToString().Split('.');
            
			string time, minutes;
			            
			string dec = timeArr.Length > 1 ? timeArr[1] : "0";

            if (dec == "25")
                minutes = "15";
            else if (dec == "5")
                minutes = "30";
            else if (dec == "75")
                minutes = "45";
            else
            {
                //Console.WriteLine($"DEC={dec}");
                minutes = "00";
            }
     
			time = $"{timeArr[0]}:{minutes}";

            if (DateTime.TryParse(time, out DateTime selectedTime)) //.ToString(@"hh\:mm\:ss tt");
            {
                SelectedTime = selectedTime;
                TimeChanged(SelectedTime);
            }
		}
      
        public void Released()
		{
			_lastDragPoint = null;
		}
        
        public SKColor GetColorAtPoint(SKPoint point)
		{
			_selectedPoint = point;

			InvalidateSurface();
         
			return _selectedColor;
		}      
	}
}
