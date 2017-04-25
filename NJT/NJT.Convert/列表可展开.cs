using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NJT.Convert
{
    /// <summary>
    /// 对象可以转换为IList 返回真.用于视图列表前面是否显示展开图标
    /// </summary>
    public class 可展开 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            if (value == null)
            {
                return Binding.DoNothing;
            }
            var r = value as IList;
            return r != null && r.Count > 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}
