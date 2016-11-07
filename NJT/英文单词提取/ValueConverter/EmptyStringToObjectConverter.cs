using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace 英文单词提取.ValueConverter
{
    public class EmptyStringToObjectConverter : IValueConverter
    {
    
        public object NotEmptyValue { get; set; }

      
        public object EmptyValue { get; set; }

     
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool isEmpty = string.IsNullOrEmpty(value?.ToString()); 

            return (isEmpty ? EmptyValue : NotEmptyValue);
        }

      
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
