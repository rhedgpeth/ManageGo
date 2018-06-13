using System;
using System.Linq;
using CoreGraphics;
using Foundation;
using UIKit;

namespace CustomCalendar.iOS
{
	public class CalendarView : UIView
	{
		public delegate void CurrentMonthYearHandler(DateTime date);
        public event CurrentMonthYearHandler OnCurrentMonthYearChange; 

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

            /*
			void SelectDate(CalendarViewCell cell, DateTime? date)
			{
				if (date != null)
				{
					cell.ControlDelegate.HighlightedDates = new DateTime[] { date.Value };
				}
				else
				{
					cell.ControlDelegate.HighlightedDates = new DateTime[] { };
				}
			}*/

			public CalendarViewDelegate(WeakReference<CalendarView> weakView)
			{
				_weakView = weakView;
			}

			public void InitializeCell(InfiniteScrollView<CalendarViewCell> infiniteScrollView, CalendarViewCell cell, int index)
			{
				cell.ControlDelegate.DatesInteracted += selectedDate =>
				{
					CalendarView v;

					if (_weakView.TryGetTarget(out v))
					{                  
						//cell.ControlDelegate.HighlightedDates = new DateTime[] { date };

						if (v.AllowMultipleSelection)
                            v.SelectedDates.AddDate(selectedDate);
                        else
                            v.SelectedDates.SetStartDate(selectedDate);

						cell.ControlDelegate.AllowMultipleSelection = v.AllowMultipleSelection;
                        cell.ControlDelegate.SelectedDates = v.SelectedDates;

                        cell.SetNeedsDisplay();
					}
				};           
			}

			public void UpdateCell(InfiniteScrollView<CalendarViewCell> infiniteScrollView, CalendarViewCell cell, int index)
			{
				CalendarView view;

				if (_weakView.TryGetTarget(out view))
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

					//SelectDate(cell, view.SelectedDate);

					cell.ControlDelegate.AllowMultipleSelection = view.AllowMultipleSelection;
                    cell.ControlDelegate.SelectedDates = view.SelectedDates;

					cell.SetNeedsDisplay();
				}
			}

			public void OnCurrentIndexChanged(InfiniteScrollView<CalendarViewCell> infiniteScrollView, int currentIndex)
			{
				CalendarView view;

				if (_weakView.TryGetTarget(out view))
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

		DateTime? _selectedDate;
		public DateTime? SelectedDate
		{
			get
			{
				return _selectedDate;
			}
			set
			{
				_selectedDate = value;
				SelectedDateChanged?.Invoke(value);
			}
		}
	}
}
