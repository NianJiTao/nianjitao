using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 年纪涛.简介.Core
{
    public static class 扩展
    {

        public static object ToObject(this bool b, object trueValue, object falseValue)
        {
            return b ? trueValue : falseValue;
        }


        public static string ToYear(this TimeSpan b )
        {
            return b.ToString("G");
        }
    }
}
