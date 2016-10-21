using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace 年纪涛.简介.ValueConverter
{
    public class NullToObjectConverter:IValueConverter
    {
        public object NullValue { get; set; }
        public object NotNullValue { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return null ==value ? NullValue : NotNullValue;
        }


        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
