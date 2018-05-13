using System;
using System.Globalization;
using ManageGo.Core.Managers.Enumerations;
using Xamarin.Forms;

namespace ManageGo.Converters
{
	public class NotificationTypeToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is NotificationType type)
            {
                var t = (NotificationType)value;

                switch (t)
                {
                    case NotificationType.Tenant:
                        return "profile_red";
                    case NotificationType.Unit:
                        return "building_red";
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
