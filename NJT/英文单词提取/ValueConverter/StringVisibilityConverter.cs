using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace 英文单词提取.ValueConverter
{
    public class StringVisibilityConverter : EmptyStringToObjectConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringVisibilityConverter"/> class.
        /// </summary>
        public StringVisibilityConverter()
        {
            NotEmptyValue = Visibility.Visible;
            EmptyValue = Visibility.Collapsed;
        }
    }
}
