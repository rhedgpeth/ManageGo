using System;
using System.Collections.Generic;

using SkiaSharp;
using Xamarin.Forms;

using ManageGo.TouchTracking;

namespace ManageGo.Controls
{   
	public class ClockEventArgs : EventArgs
    {      
		public DateTime SelectedTime { get; set; }
    }

	public delegate void ClockEventHandler(Object sender, ClockEventArgs e);

    public partial class ClockView : Grid
    {
		public event ClockEventHandler TimeChanged;

		List<long> touchIds = new List<long>();

        public ClockView()
        {
            InitializeComponent();

			var touchEffect = new TouchEffect
			{
				Capture = true
			};
                     
			touchEffect.TouchAction += OnTouchEffectAction;
            
			Effects.Add(touchEffect);

			Clock.TimeChanged = OnTimeChanged;
        }

        void OnTimeChanged(DateTime time)
		{
			TimeLabel.Text = time.ToString(@"h\:mm tt");

			TimeChanged?.Invoke(this, new ClockEventArgs { SelectedTime = time });
		}

        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {         
            var pt = args.Location;         

			var xOffset = (Width - Clock.Width) / 2;
			var yOffset = (Height - Clock.Height) / 2;

            var point =
				new SKPoint((float)(Clock.CanvasSize.Width * ((pt.X - xOffset) / Clock.Width)),
				            (float)(Clock.CanvasSize.Height * ((pt.Y - yOffset) / Clock.Height)));
                     
            switch (args.Type)
            {
                case TouchActionType.Pressed:

					var color = Clock.GetColorAtPoint(point);

					if (color == SKColor.Parse("#939598"))
					{
						touchIds.Add(args.Id);
					}
					else //if (color == SKColors.White)               
					{
						// Move hand the closest angle
					}

                    break;

                case TouchActionType.Moved:
                    if (touchIds.Contains(args.Id))
                    {                 
						Clock.Drag(point);
                    }
                    break;

                case TouchActionType.Released:
                case TouchActionType.Cancelled:
                    if (touchIds.Contains(args.Id))
                    {                 
						Clock.Released();
                    }
                    break;
            }
        }
    }
}
