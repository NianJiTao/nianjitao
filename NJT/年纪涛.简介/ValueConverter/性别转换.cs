using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.UI.Converters;

namespace 年纪涛.简介.ValueConverter
{
    public class 性别转换 : BoolToObjectConverter
    {
        public 性别转换()
        {
            TrueValue = "男";
            FalseValue = "女";
        }
    }
}
