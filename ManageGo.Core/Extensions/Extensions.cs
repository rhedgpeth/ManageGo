using System;
using System.Globalization;

namespace ManageGo.Core
{
    public static class Extensions
    {
        public static string ToShortDateTimeString(this DateTime date)
        {
            return $"{CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(date.Month)} {date.Day} - {date.ToShortTimeString()}";
        }
    }
}
