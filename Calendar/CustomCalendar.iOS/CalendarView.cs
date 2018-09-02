using System;
using CoreGraphics;
using UIKit;

namespace CustomCalendar.iOS
{
	public class CalendarView : UIView
	{
        public event CurrentMonthYearHandler OnCurrentMonthYearChange;
        public event DateRangeHandler OnSelectedDatesChange;

		internal bool AllowMultipleSelection { get; set; }

		DateRange _selectedDates;
        public DateRange SelectedDates
        {
            get
            {
                if (_selectedDates == null)
                    _selectedDates = new DateRange(DateTime.Now.Date);

                return _selectedDates;
            }
            set => _selectedDates = value;
        }

		class CalendarViewDelegate : IInfiniteScrollViewDelegate<CalendarViewCell>
		{
			WeakReference<CalendarView> _weakView;

			public CalendarViewDelegate(WeakReference<CalendarView> weakView)
			{
				_weakView = weakView;
			}

			public void InitializeCell(InfiniteScrollView<CalendarViewCell> infiniteScrollView, CalendarViewCell cell, int index)
			{
				cell.ControlDelegate.DatesInteracted += selectedDate =>
				{
                    if (_weakView.TryGetTarget(out CalendarView v))
                    {
                        if (v.AllowMultipleSelection)
                            v.SelectedDates.AddDate(selectedDate);
                        else
                            v.SelectedDates.SetStartDate(selectedDate);

                        cell.ControlDelegate.AllowMultipleSelection = v.AllowMultipleSelection;
                        cell.ControlDelegate.SelectedDates = v.SelectedDates;

                        v.OnSelectedDatesChange?.Invoke(v.SelectedDates);

                        cell.SetNeedsDisplay();
                    }
                };           
			}

			public void UpdateCell(InfiniteScrollView<CalendarViewCell> infiniteScrollView, CalendarViewCell cell, int index)
			{
                if (_weakView.TryGetTarget(out CalendarView view))
                {
                    if (infiniteScrollView.CurrentIndex < index) // right
                    {
                        cell.ControlDelegate.Date = view.Month.AddMonths(1);
                    }
                    else if (infiniteScrollView.CurrentIndex == index) // middle
                    {
                        cell.ControlDelegate.Date = view.Month;
                        view.OnCurrentMonthYearChange?.Invoke(view.Month);
                    }
                    else // left
                    {
                        cell.ControlDelegate.Date = view.Month.AddMonths(-1);
                    }

                    cell.ControlDelegate.AllowMultipleSelection = view.AllowMultipleSelection;
                    cell.ControlDelegate.SelectedDates = view.SelectedDates;

                    cell.SetNeedsDisplay();
                }
            }

			public void OnCurrentIndexChanged(InfiniteScrollView<CalendarViewCell> infiniteScrollView, int currentIndex)
			{
                if (_weakView.TryGetTarget(out CalendarView view))
                {
                    if (view.CurrentIndex > infiniteScrollView.CurrentIndex) // left
                    {
                        view.Month = view.Month.AddMonths(-1);
                    }
                    else if (view.CurrentIndex < infiniteScrollView.CurrentIndex) // right
                    {
                        view.Month = view.Month.AddMonths(1);
                    }

                    view.CurrentIndex = infiniteScrollView.CurrentIndex;
                }
            }
		}

		DateTime Month { get; set; }
        
		public CalendarView(CGRect frame, bool allowMultipleSelection, DateTime selectedDate) : base(frame)
		{
			AllowMultipleSelection = allowMultipleSelection;

			var del = new CalendarViewDelegate(new WeakReference<CalendarView>(this));
			var infiniteScrollView = new InfiniteScrollView<CalendarViewCell>(del, frame);

			AddSubview(infiniteScrollView);

			// Default starting month is the current month
			Month = selectedDate.Date; 
		}

		public event Action<DateTime> DateSelected;

		internal event Action<DateTime?> SelectedDateChanged;

		internal int CurrentIndex { get; set; }
	}
}
