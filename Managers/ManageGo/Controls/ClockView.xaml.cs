using System;
using System.Collections.Generic;

using SkiaSharp;
using Xamarin.Forms;

using ManageGo.TouchTracking;

namespace ManageGo.Controls
{
    public partial class ClockView : Grid
    {
        public ClockView()
        {
            InitializeComponent();

			var touchEffect = new TouchEffect
			{
				Capture = true
			};
                     
			touchEffect.TouchAction += OnTouchEffectAction;

			Effects.Add(touchEffect);

			Clock.TimeChanged = (time) => { TimeLabel.Text = time; };
        }

		List<long> touchIds = new List<long>();
 
        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {         
            // Convert Xamarin.Forms point to pixels
            var pt = args.Location;


			var xOffset = (Width - Clock.Width) / 2;
			var yOffset = (Height - Clock.Height) / 2;

			//var x = ((Clock.CanvasSize.Width * pt.X / Width) - offset) - (550 / 2);
			//var y = ((Clock.CanvasSize.Height * pt.Y / Height) - 0) - (550 / 2);

            var point =
				new SKPoint((float)(Clock.CanvasSize.Width * ((pt.X - xOffset) / Clock.Width)),
				            (float)(Clock.CanvasSize.Height * ((pt.Y - yOffset) / Clock.Height)));
                     
            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    if (Clock.ContainsPoint(point))
					{  
					    touchIds.Add(args.Id);
						//Console.WriteLine($"PRESSED - sX={pt.X} sY={pt.Y} - X={point.X} Y={point.Y}");
                        break;
                    }
                    break;

                case TouchActionType.Moved:
                    if (touchIds.Contains(args.Id))
                    {
						//Console.WriteLine($"MOVED - sX={pt.X} sY={pt.Y} - X={point.X} Y={point.Y}");
						//Clock.InvalidateSurface();

						Clock.Drag(point);
                    }
                    break;

                case TouchActionType.Released:
                case TouchActionType.Cancelled:
                    if (touchIds.Contains(args.Id))
                    {
						//Console.WriteLine($"CANCELLED - sX={pt.X} sY={pt.Y} - X={point.X} Y={point.Y}");
						//Clock.InvalidateSurface();

						Clock.Released();
                    }
                    break;
            }
        }
    }
}
