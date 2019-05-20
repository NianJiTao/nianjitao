//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
////using System.Windows.Threading;

//namespace NJT.Core
//{
//    public class 定时器
//    {
//        public static IDictionary<string, DispatcherTimer> 定时列表 = new Dictionary<string, DispatcherTimer>();

//        public static void 延时运行(int 延时毫秒, Action 启动方法)
//        {
//            if (延时毫秒 <= 0 || 延时毫秒 >= 36000000 || 启动方法 == null)
//            {
//                return;
//            }

//            var time延时 = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 0, 延时毫秒)};
//            time延时.Tick += (o, e) =>
//            {
//                time延时.Stop();
//                启动方法();
//            };
//            time延时.Start();
//            return;
//        }

//        public static DispatcherTimer 循环运行(int 间隔毫秒, Action 启动方法)
//        {
//            if (间隔毫秒 <= 0 || 间隔毫秒 >= 36000000 || 启动方法 == null)
//            {
//                return null;
//            }

//            return 循环运行(TimeSpan.FromMilliseconds(间隔毫秒), 启动方法);
//        }

//        public static DispatcherTimer 循环运行(TimeSpan 间隔, Action 启动方法)
//        {
//            if (间隔 <= TimeSpan.Zero || 间隔 >= TimeSpan.FromDays(30) || 启动方法 == null)
//            {
//                return null;
//            }

//            return 循环运行(间隔, 启动方法, Guid.NewGuid().ToString());
//        }

//        public static DispatcherTimer Find定时器(string 计时器名称)
//        {
//            if (定时列表.ContainsKey(计时器名称) == false)
//                return null;
//            return 定时列表[计时器名称];
//        }

//        public static void 关闭定时器(string[] 计时器名称)
//        {
//            foreach (var name in 计时器名称)
//            {
//                if (定时列表.ContainsKey(name))
//                    定时列表[name].Stop();
//            }
//        }

//        public static DispatcherTimer 循环运行(int 间隔毫秒, Action 启动方法, string 计时器名称)
//        {
//            return 循环运行(TimeSpan.FromMilliseconds(间隔毫秒), 启动方法, 计时器名称);
//        }

//        public static DispatcherTimer 循环运行(TimeSpan 间隔, Action 启动方法, string 计时器名称x)
//        {
//            var 计时器名称 = 计时器名称x;
//            if (string.IsNullOrEmpty(计时器名称x))
//            {
//                计时器名称 = Guid.NewGuid().ToString();
//            }
//            if (间隔 <= TimeSpan.Zero || 间隔 >= TimeSpan.FromDays(30) || 启动方法 == null)
//            {
//                return null;
//            }
//            var timer = new DispatcherTimer {Interval = 间隔};
//            if (定时列表.ContainsKey(计时器名称) == false)
//            {
//                定时列表.Add(计时器名称, timer);
//            }
//            else
//            {
//                定时列表[计时器名称].Stop();
//                定时列表[计时器名称] = timer;
//            }

//            timer.Tick += (o, e) => { 启动方法(); };
//            timer.Start();
//            return timer;
//        }

//        public static void 关闭所有()
//        {
//            var find = from cs in 定时列表 where cs.Value != null select cs;
//            foreach (var timer in find)
//            {
//                timer.Value.Stop();
//            }

//            定时列表.Clear();
//        }
//    }
//}