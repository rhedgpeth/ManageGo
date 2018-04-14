using System;
using System.Globalization;
using Xamarin.Forms;

namespace ManageGo.Converters
{
	public class BoolToStringConverter : IValueConverter
    {
        public BoolToStringConverter()
        {
        }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value as bool? ?? false)
                return "yes";

            return "no";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
