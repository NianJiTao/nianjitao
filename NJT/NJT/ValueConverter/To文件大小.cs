using System;
using System.Globalization;
using System.Windows.Data;
using NJT.扩展;

namespace NJT.ValueConverter
{
    /// <summary>
    /// long 字节长度转标准表示格式,
    /// 如1024 --> 1 k
    /// </summary>
    public class LongTo文件大小 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var 大小 = (long)value;
            return 大小.To文件大小();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
