using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace 年纪涛.简介.ValueConverter
{
    public class NullToCollapsed: NullToObjectConverter
    {

        public NullToCollapsed()
        {
            NotNullValue = Visibility.Visible;
            NullValue = Visibility.Collapsed;
        }
    }
}
