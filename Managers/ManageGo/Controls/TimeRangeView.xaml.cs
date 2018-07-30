using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ManageGo.Controls
{
    public partial class TimeRangeView : Grid, IDisposable
    {
        void Handle_Left_Tapped(object sender, System.EventArgs e)
        {
            
        }

        void Handle_Right_Tapped(object sender, System.EventArgs e)
        {
            
        }
      
		public event ClockEventHandler TimeUpdated;

        public TimeRangeView()
        {
            InitializeComponent();

			LeftClock.TimeChanged += LeftClock_TimeChanged;
			RightClock.TimeChanged += RightClock_TimeChanged;
        }
        
		void LeftClock_TimeChanged(object sender, ClockEventArgs e)
        {
            leftTimeLabel.Text = e.SelectedTime.ToShortTimeString();
        }

        void RightClock_TimeChanged(object sender, ClockEventArgs e)
        {
            rightTimeLabel.Text = e.SelectedTime.ToShortTimeString();
        }

        public void Dispose()
		{
			LeftClock.TimeChanged -= LeftClock_TimeChanged;
			RightClock.TimeChanged -= RightClock_TimeChanged;
		}
    }
}
