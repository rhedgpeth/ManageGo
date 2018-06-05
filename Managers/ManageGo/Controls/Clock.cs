using System;
using System.Runtime.InteropServices;
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

		SKPaint greyStrokePaint = new SKPaint
        {
            Style = SKPaintStyle.StrokeAndFill,
			Color = SKColor.Parse("#939598"),
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

		SKImageInfo _sampleBitmapImageInfo;

		protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
		{
			SKImageInfo info = e.Info;
			SKSurface surface = e.Surface;
			SKCanvas canvas = surface.Canvas;

			_sampleBitmapImageInfo = new SKImageInfo
			{
				ColorType = info.ColorType,
    			AlphaType = info.AlphaType,
    			Width = 1,
    			Height = 1
		    };

			//surface.ReadPixels()

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

				canvas.DrawLine(0, -(info.Height / 2 - 30), 0, -(info.Height / 2 - 10), paint);

				canvas.RotateDegrees(7.5f);
			}
                     
			// Second hand
			canvas.Save();   

            /*
			if (_rotate)
			{
				var newAngle = CurrentAngle + 7.5f;

				canvas.RotateDegrees(newAngle);

				CurrentAngle = newAngle;

				Console.WriteLine($"ANGLE = {newAngle}");

				_rotate = false;
			}*/
                 
			canvas.RotateDegrees(CurrentAngle);

			canvas.DrawLine(0, 10, 0, -(info.Height / 2 - 70), blueStrokePaint);
            
			// Draw Arc
			SKPaint skPaint = new SKPaint()
			{
				Style = SKPaintStyle.StrokeAndFill,
				Color = SKColor.Parse("#3E90F4"),
				StrokeWidth = 10,
				IsAntialias = true,
			};

			_draggableEndCircle = new SKRect();
			_draggableEndCircle.Size = new SKSize(10, 10);
			_draggableEndCircle.Location = new SKPoint(-5, -(info.Height / 2 - 70));

			float startAngle = -90;
			float sweepAngle = 360; // (75 / 100) * 360

			SKPath skPath = new SKPath();
			skPath.AddArc(_draggableEndCircle, startAngle, sweepAngle);         
			canvas.DrawPath(skPath, skPaint);
            
            
			var tp1 = new SKPath();
            tp1.MoveTo(10f, -(info.Height / 2 - 130));
            tp1.LineTo(10f, -(info.Height / 2 - 110));
            tp1.LineTo(25f, -(info.Height / 2 - 120));
            tp1.LineTo(10f, -(info.Height / 2 - 130));
            tp1.Close();

            var tp2 = new SKPath();
            tp2.MoveTo(-10f, -(info.Height / 2 - 130));
            tp2.LineTo(-10f, -(info.Height / 2 - 110));
            tp2.LineTo(-25f, -(info.Height / 2 - 120));
            tp2.LineTo(-10f, -(info.Height / 2 - 130));
            tp2.Close();
            
            
            /*
			var tp1 = new SKPath();
			tp1.MoveTo(10f, -(info.Height / 2 - 190));
			tp1.LineTo(10f, -(info.Height / 2 - 110));
			tp1.LineTo(50f, -(info.Height / 2 - 150));
			tp1.LineTo(10f, -(info.Height / 2 - 190));
			tp1.Close();

			var tp2 = new SKPath();
			tp2.MoveTo(-10f, -(info.Height / 2 - 190));
			tp2.LineTo(-10f, -(info.Height / 2 - 110));
			tp2.LineTo(-50f, -(info.Height / 2 - 150));
			tp2.LineTo(-10f, -(info.Height / 2 - 190));
			tp2.Close();
			*/

			canvas.DrawPath(tp1, greyStrokePaint);
			canvas.DrawPath(tp2, greyStrokePaint);

			canvas.Restore(); 
           
			if (_selectedPoint.HasValue)
            {            
                _selectedColor = GetColorAtPoint(surface, (int)_selectedPoint.Value.X, (int)_selectedPoint.Value.Y);

				if (_selectedColor == SKColor.Parse("#939598"))
                {               
					InvalidateSurface();
                }

                _selectedPoint = null;
            }

            /*
            if (_arcPoint.HasValue)
			{
				canvas.DrawCircle(_arcPoint.Value, 10, blackStrokePaint);
			}
			*/
           
            /*
            double x0 = 0;
            double y0 = 0;
            var dist = -(info.Width / 2 - 70);
            var angle1 = 360;
            
            var radians = AngleToRadians(angle1);

            double x = x0 + dist * Math.Cos(radians);
            double y = y0 + dist * Math.Sin(radians);

            canvas.DrawLine(0, 10, (float)x, (float)y, blueStrokePaint);
            */
		}

		bool _rotate;

		double AngleToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }      
      
		SKRect _draggableEndCircle;
		SKPoint? _selectedPoint = null;
		SKColor _selectedColor;

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
			//Console.WriteLine($"Dragging - X={point.X} Y={point.Y}");
                   
			double x0 = 0;
            double y0 = 0;
            var dist = -(550 / 2 - 70);

            //var angle1 = 360;

            var radians = AngleToRadians(CurrentAngle + 90);

            double x = x0 + dist * Math.Cos(radians);
            double y = y0 + dist * Math.Sin(radians);

            _arcPoint = new SKPoint((float)x, (float)y);


			if (_lastDragPoint.HasValue)
			{
				x0 = _lastDragPoint.Value.X;
                y0 = _lastDragPoint.Value.Y;
                
                x = point.X;
                y = point.Y;
                   

				var angle0 = -(Math.Atan2(-275, 0) - Math.Atan2(y0 - 275, x0 - 275));

                angle0 = angle0 * (180.0 / Math.PI);

                if (angle0 < 0)
                {
                    angle0 = angle0 + 360;
                }

				var angle = -(Math.Atan2(-275, 0) - Math.Atan2(y - 275, x - 275));
                            
				angle = angle * (180.0 / Math.PI);

				if (angle < 0)
                {
                    angle = angle + 360;
                }

				var dAngle = angle - angle0;
            
                if (dAngle > 0)
				{
					var newAngle = CurrentAngle + 7.5f;

                    if (angle > newAngle)
					{
						CurrentAngle = newAngle;
					}
				}
				else if (dAngle < 0)
				{
					var newAngle = CurrentAngle - 7.5f;

					if (angle < newAngle)
					{
						CurrentAngle = newAngle;
					}
				}
             
            
                //var distance = Math.Sqrt(Math.Pow(x - x0, 2) + Math.Pow(y - y0, 2));            
				//Console.WriteLine($"DISTANCE={distance}");
            
                /*
				if (((point.Y > _lastDragPoint.Value.Y) ||
				    (point.X > _lastDragPoint.Value.X)) && distance > 2)
				{
					CurrentAngle = CurrentAngle + 7.5f;
				}
				else if (((_lastDragPoint.Value.Y > point.Y) ||
				          (_lastDragPoint.Value.X > point.X)) && distance > 2)
				{
					CurrentAngle = CurrentAngle - 7.5f;
				}*/

				_lastDragPoint = point;

				InvalidateSurface();
			}
			else
			{
				

				_lastDragPoint = point;
			}         
            
           
			var timeDecimal = ((decimal)CurrentAngle / (decimal)30.0);

            var timeArr = timeDecimal.ToString().Split('.');
            
			string time;
			            
			string dec = timeArr.Length > 1 ? timeArr[1].ToString() : "0";
		    string minutes;

			if (dec == "25")
				minutes = "15";
			else if (dec == "5")
				minutes = "30";         
			else if (dec == "75")
				minutes = "45";      
			else
				minutes = "00";
     
			time = $"{timeArr[0]}:{minutes}";
                     
			SelectedTime = DateTime.Parse(time).ToString(@"hh\:mm\:ss tt");

			TimeChanged(SelectedTime);
		}
           
		public Action<string> TimeChanged { get; set; }
		public string SelectedTime { get; set; }

		SKPoint? _arcPoint;

		SKPoint? _lastDragPoint;

        public void Released()
		{
			_arcPoint = null;
			_lastDragPoint = null;
		}

        public bool ContainsPoint(SKPoint point)
		{
			_selectedPoint = point;

			InvalidateSurface();

			var color = _selectedColor;
            
            if (color == SKColors.BlueViolet)
			{
				//Console.WriteLine($"COLOR={color.ToString()}");
			}

			return color == SKColor.Parse("#939598");
		}
      
		float _currentAngle;
        float CurrentAngle
		{
			get
			{            
				return _currentAngle;
			}
			set  
			{
				if (value >= 720 || value < 0 )
					return;

				_currentAngle = value;
			}
		}
	}
}
