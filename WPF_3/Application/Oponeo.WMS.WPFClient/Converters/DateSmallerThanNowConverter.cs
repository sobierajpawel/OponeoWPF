using System;
using System.Globalization;
using System.Windows.Data;

namespace Oponeo.WMS.WPFClient.Converters
{
    internal sealed class DateSmallerThanNowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTimeValue)
            {
                return dateTimeValue < DateTime.Now;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
