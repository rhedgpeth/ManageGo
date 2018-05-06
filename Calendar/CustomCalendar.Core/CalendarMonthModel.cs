﻿using System;
using System.Collections.Generic;
using System.Linq;
using SkiaSharp;

namespace CustomCalendar
{
	public class CalendarMonthModel
	{
		public int Year { get; private set; }

		public int Month { get; private set; }

		public IEnumerable<CalendarDayModel> Days { get; private set; }

		public int GridSize { get; private set; }

		public IEnumerable<int> HighlightedDays { get; private set; }

		CalendarMonthModel(int year, int month, IEnumerable<CalendarDayModel> calendarDays, int gridSize, IEnumerable<int> highlightedDays)
		{
			Year = year;
			Month = month;
			Days = calendarDays;
			GridSize = gridSize;
			HighlightedDays = highlightedDays;
		}

		public CalendarDayModel TryFindCalendarDayByPoint(SKPoint point)
		{
			return this.Days.FirstOrDefault(day => day.Rectangle.Contains(point));
		}
        
		public static CalendarMonthModel Create(int year, int month, IEnumerable<int> highlightedDays, int width, int height)
		{
			var monthDate = new DateTime(year, month, 1);

			var calendarDays = new List<CalendarDayModel>();

			var rows = Math.Ceiling((DateTime.DaysInMonth(year, month) / 7f)) + 1;
			var columns = 7;
           
			var date = monthDate.AddDays(0 - int.Parse(monthDate.DayOfWeek.ToString("D")));

			var gridSize = 0;
			int offset_x = 0;
            int offset_y = 0;

			if (width > height)
            {
				//gridSize = height / columns;

				gridSize = (int)((.85 * width) / columns);

                offset_x = (width - (columns * gridSize)) / 2;
            }
            else
            {
                gridSize = width / columns;
                offset_y = (height - (columns * gridSize)) / 2;
            }         
            
			string[] days = { "S", "M", "T", "W", "T", "F", "S" };

			for (int i = 0; i < days.Length; i++)
			{
				var x = (float)((gridSize * i)) + offset_x;
				var y = 0f;

                calendarDays.Add(new CalendarDayModel(days[i], x, y, gridSize, gridSize));
			}

			for (int i = 1; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					var x = (float)((gridSize * j)) + offset_x;
					var y = (float)((((gridSize / 1.25 )) * i)) + offset_y;

					calendarDays.Add(new CalendarDayModel(date.Year, date.Month, date.Day, x, y, gridSize, gridSize));
					date = date.AddDays(1);
				}
			}

			return new CalendarMonthModel(year, month, calendarDays, gridSize, highlightedDays);
		}
	}
}
