using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NJT.Convert
{
    /// <summary>
    ///  秒单位:double
    /// </summary>
    public class 秒ToTimeSpan : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value==null)
            {
                return TimeSpan.Zero;
            }
            var 时长2 = double.TryParse(value.ToString(), out var 时长);
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
