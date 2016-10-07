using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.扩展
{
    public static partial class 扩展方法
    {

        /// <summary>
        /// 运行方法需要的时间,返回毫秒
        /// </summary>
        /// <param name="方法"></param>
        /// <returns></returns>
        public static long 计算耗时(this Action 方法)
        {
            var sw = new Stopwatch();
            sw.Start();
            方法();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

    }
}
