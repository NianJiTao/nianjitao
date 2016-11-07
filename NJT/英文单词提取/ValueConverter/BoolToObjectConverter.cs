using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace 英文单词提取.ValueConverter
{
    public class BoolToObjectConverter : IValueConverter
    {

        public object TrueValue { get; set; }

        public object FalseValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool boolValue = value is bool && (bool)value;

            return (boolValue ? TrueValue : FalseValue);
        }


        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            bool result = Equals(value, TrueValue);
            return result;
        }
    }
}
