using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;

namespace NJT.Ext
{


    public static partial class 扩展方法
    {

        public static void  延时运行(this Action 函数,int 延时毫秒)
        {
            var time延时 = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 延时毫秒) };
            time延时.Tick += (o, e) =>
            {
                time延时.Stop();
                函数();
            };
            time延时.Start();
            return  ;
        }

    }
}
