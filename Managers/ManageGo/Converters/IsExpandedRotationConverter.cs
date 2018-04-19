using System;
using System.Globalization;
using Xamarin.Forms;

namespace ManageGo.Converters
{
	public class IsExpandedRotationConverter : IValueConverter
    {
        public IsExpandedRotationConverter()
        { }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value as bool? ?? false)
                return 180;

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
