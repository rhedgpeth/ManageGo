using System;
using System.Globalization;
using Xamarin.Forms;

namespace ManageGo.Converters
{
    public class ReplyCountToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int replyCount && replyCount > 0)
            {
                return "chat_green";
            }

            return "chat_red";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
