using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace 英文单词提取.ValueConverter
{
    public class BoolTo取反Converter : BoolToObjectConverter
    {
      
        public BoolTo取反Converter()
        {
            TrueValue = false;
            FalseValue = true;
        }
    }
}
