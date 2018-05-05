using System;
using System.Globalization;
using ManageGo.Core.Managers.Enumerations;
using Xamarin.Forms;

namespace ManageGo.Converters
{
	public class TransactionSourceTypeToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {         
			if (value is TransactionSourceType type)
			{
				var t = (TransactionSourceType)value;

                switch (t)
				{
					case TransactionSourceType.Bank:
						return "bank_grey";
					case TransactionSourceType.Building:
						return "building_grey";
					default:
						return string.Empty;
				}
			}

			return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
