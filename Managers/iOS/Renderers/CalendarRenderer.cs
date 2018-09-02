using System;
using CoreGraphics;
using CustomCalendar;
using Foundation;
using ManageGo.Controls;
using ManageGo.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Calendar), typeof(CalendarRenderer))]
namespace ManageGo.iOS.Renderers
{
    [Preserve(AllMembers = true)]
    public class CalendarRenderer : ViewRenderer<Calendar, CustomCalendar.iOS.CalendarView>
    {
		CustomCalendar.iOS.CalendarView _calendarView;

        double elementWidth;
        double elementHeight;

        bool disposed;

        protected override void OnElementChanged(ElementChangedEventArgs<Calendar> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                if (Element == null)
                {
                    return;
                }

                Element.SizeChanged -= ElementSizeChanged;
            }

            if (e.NewElement != null)
            {
                Element.SizeChanged += ElementSizeChanged;
            }

            InitializeNativeView();
        }

        void InitializeNativeView()
        {
            if (elementWidth <= 0 || elementHeight <= 0)
            {
                return;
            }

            ResetNativeView();

			_calendarView = new CustomCalendar.iOS.CalendarView(new CGRect(0, 0, elementWidth, elementHeight), Element.AllowMultipleSelection, DateTime.Now);

            _calendarView.OnCurrentMonthYearChange += Element.OnCurrentMonthYearChanged;
            _calendarView.OnSelectedDatesChange += Element.OnDatesChanged;

            SetNativeControl(_calendarView);
        }
        
        void ResetNativeView()
        {
            if (_calendarView != null)
            {
				_calendarView.OnCurrentMonthYearChange -= Element.OnCurrentMonthYearChanged;
                _calendarView.OnSelectedDatesChange -= Element.OnDatesChanged;
                _calendarView.RemoveFromSuperview();
                _calendarView.Dispose();
                _calendarView = null;
            }
        }

        void ElementSizeChanged(object sender, EventArgs e)
        {
            if (Element == null)
            {
                return;
            }

            var rect = this.Element.Bounds;

            if (rect.Height > 0)
            {
                elementWidth = rect.Width;
                elementHeight = rect.Height;

                InitializeNativeView();
            }
        }

        public override void MovedToSuperview()
        {
            if (Control == null)
            {
                ElementSizeChanged(Element, null);
            }

            base.MovedToSuperview();
        }

        public override void MovedToWindow()
        {
            if (Control == null)
            {
                ElementSizeChanged(Element, null);
            }

            base.MovedToWindow();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && !disposed)
            {
                disposed = true;

                if (Element != null)
                {
                    ResetNativeView();

                    Element.SizeChanged -= ElementSizeChanged;
                }

				if (_calendarView != null)
				{
                    _calendarView.OnCurrentMonthYearChange -= Element.OnCurrentMonthYearChanged;
                    _calendarView.OnSelectedDatesChange -= Element.OnDatesChanged;
				}
            }

            base.Dispose(disposing);
        }
    }
}
