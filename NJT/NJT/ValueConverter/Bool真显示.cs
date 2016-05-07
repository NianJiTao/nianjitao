using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NJT.ValueConverter
{
    public class Bool真显示 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            return Bool转换.转换(value, Visibility.Visible, Visibility.Collapsed);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            return Equals(value, Visibility.Visible);
        }
    }
}