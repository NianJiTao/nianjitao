using System;
using System.Globalization;
using System.Windows.Data;

namespace NJT.ValueConverter
{
    /// <summary>
    ///  秒单位:double
    /// </summary>
    public class 秒ToTimeSpan : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double 时长;
            var 时长2 = double.TryParse(value.ToString(), out 时长);
            var r = TimeSpan.FromSeconds(时长);
            return r;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 0;
            var 时长 = (TimeSpan)value;
            var r = 时长.TotalSeconds;
            return r;
        }
    }
}
