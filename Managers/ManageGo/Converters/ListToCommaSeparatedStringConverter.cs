using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace ManageGo.Converters
{
	public class ListToCommaSeparatedStringConverter : IValueConverter
    {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var list = value as List<string>;
            
            if (list != null)
			    return string.Join(", ", list.Select(x => x.ToString()));

			return null;
		}

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
