using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace NJT.ValueConverter
{
    public class 颜色背景转换 : IValueConverter
    {
        public static Brush 原色 = Brushes.White;
        public static Brush 新色 = Brushes.Pink;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Bool转换.转换(value, 新色, 原色);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            var r = value as Brush;
            return !Equals(r, 原色);
        }
    }
}
