using System;
using System.Collections.Generic;
using System.Linq;
using SkiaSharp;

namespace CustomCalendar
{
	public class CalendarMonthControl : IDrawableControlDelegate
	{
		CalendarMonthModel Model { get; set; }

		public bool AllowMultipleSelection { get; set; }

		public DateRange SelectedDates { get; set; }

		DateTime _date;
		public DateTime Date
		{
			get => _date;
			set => _date = value.Date;
		}

		public CalendarMonthControl()
        {
            Date = DateTime.Now;
			Model = CalendarMonthModel.Create(Date.Year, Date.Month, new HighlightedDay[] { }, 0, 0);
        }

		bool TryFindDateByPoint(SKPoint point, out DateTime dateTime)
		{
			var calendarDay = Model.TryFindCalendarDayByPoint(point);

			if (calendarDay?.DateTime.Month == Date.Month)
			{
				dateTime = calendarDay.DateTime;
				return true;
			}

			dateTime = new DateTime();

			return false;
		}

		public event Action<DateTime> DatesInteracted;

		public void Draw(SKSurface surface, SKImageInfo info)
		{
			var highlightedDays = SelectedDates?.GetDateRangeDates()
                                                   .Where(hd => hd.Year == Date.Year && hd.Month == Date.Month)
			                                    .Select(d => new HighlightedDay 
			                                    {
				                                    Type = (d == SelectedDates.StartDate || 
				                                            d == SelectedDates.EndDate ) ? HighlightType.Dark : HighlightType.Light,
				                                    Day = d.Day
			                                    }).ToList();

            

            Model = CalendarMonthModel.Create(Date.Year, Date.Month, highlightedDays, info.Width, info.Height);

            CalendarMonthRenderer.Draw(surface, info, Model);
		}

		public void EndInteractions(IEnumerable<SKPoint> points)
		{
			if (points.Count() == 1)
			{
				var dateTime = new DateTime();
				if (TryFindDateByPoint(points.ElementAt(0), out dateTime))
				{
					DatesInteracted?.Invoke(dateTime);
				}
			}
		}      
	}
}
