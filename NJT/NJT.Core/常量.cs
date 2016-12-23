using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public static class 常量
    {

        public static string 星期名称 => "星期日;星期一;星期二;星期三;星期四;星期五;星期六";

        public static string[] 星期名称list => 星期名称.Split(';');



    }
}
