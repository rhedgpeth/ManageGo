using System;
using System.Collections.Generic;
using SkiaSharp;

namespace CustomCalendar
{
	public class CalendarDayModel
	{
		public string Description { get; private set; }

		public DateTime DateTime { get; private set; }

		public SKRect Rectangle { get; private set; }

		public bool IsHighlighted { get; internal set; }

		internal CalendarDayModel(int year, int month, int day, float x, float y, float width, float height)
		{
			DateTime = new DateTime(year, month, day);
			IsHighlighted = false;
			Rectangle = new SKRect(x, y, x + width, y + height);
		}

		internal CalendarDayModel(string text, float x, float y, float width, float height)
        {
            Description = text;
            IsHighlighted = false;
            Rectangle = new SKRect(x, y, x + width, y + height);
        }
	}
}
