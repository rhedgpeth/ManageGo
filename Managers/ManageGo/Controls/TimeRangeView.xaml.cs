using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ManageGo.Controls
{
    public partial class TimeRangeView : Grid, IDisposable
    {      
		public event ClockEventHandler TimeUpdated;

        public TimeRangeView()
        {
            InitializeComponent();

			LeftClock.TimeChanged += LeftClock_TimeChanged;
			RightClock.TimeChanged += RightClock_TimeChanged;
        }
        
		void LeftClock_TimeChanged(object sender, ClockEventArgs e)
        {
			
        }

		void RightClock_TimeChanged(object sender, ClockEventArgs e)
        {

        }

        public void Dispose()
		{
			LeftClock.TimeChanged -= LeftClock_TimeChanged;
			RightClock.TimeChanged -= RightClock_TimeChanged;
		}
    }
}
