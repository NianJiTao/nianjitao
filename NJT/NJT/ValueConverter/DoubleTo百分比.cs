using System;
using System.Globalization;
using System.Windows.Data;

namespace NJT.ValueConverter
{


    /// <summary>
    ///  0.15 To 15%
    /// </summary>
    public class DoubleTo百分比 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var 大小 = (double)value;
            return 大小.ToString("p");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
