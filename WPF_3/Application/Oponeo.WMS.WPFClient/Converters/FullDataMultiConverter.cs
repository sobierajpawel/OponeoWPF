using System;
using System.Globalization;
using System.Windows.Data;

namespace Oponeo.WMS.WPFClient.Converters
{
    internal sealed class FullDataMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Join(";", values);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return value.ToString().Split(';');
        }
    }
}
