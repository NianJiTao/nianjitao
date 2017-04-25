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
    ///  0.15 To 15.00%
    /// </summary>
    public class DoubleTo百分比 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double)
            {
                var 大小 = (double)value;
                return 大小.ToString("p");
            }
            else
            {
                return Binding.DoNothing;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
