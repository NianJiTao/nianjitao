using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace NJT.Core
{
    public class 定时器
    {

        static List<DispatcherTimer> 定时列表 = new List<DispatcherTimer>();

        public static void 延时运行(int 延时毫秒, Action 启动方法)
        {
            var time延时 = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 延时毫秒) };
            time延时.Tick += (o, e) =>
            {
                time延时.Stop();
                启动方法();
            };
            time延时.Start();
            return;
        }

        public static void 循环运行(int 间隔毫秒, Action 启动方法)
        {
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(间隔毫秒)
            };
            定时列表.Add(timer);
            timer.Tick += (o, e) => { 启动方法(); };
            timer.Start();
        }
        public static void 关闭所有()
        {
            var find = from cs in 定时列表 where cs != null select cs;
            foreach (var timer in find)
            {
                timer.Stop();
            }
            定时列表.Clear();
        }
    }
}
