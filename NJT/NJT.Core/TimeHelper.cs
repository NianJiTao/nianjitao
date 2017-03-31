using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;

namespace NJT.Core

{
    //public static class TimeHelper
    //{
    //    private static readonly Dictionary<string, DispatcherTimer> Timer = new Dictionary<string, DispatcherTimer>();


    //    public static void 延时启动(int 延时毫秒, Action 启动方法)
    //    {
    //        var time延时 = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 0, 延时毫秒)};
    //        time延时.Tick += (o, e) =>
    //        {
    //            time延时.Stop();
    //            启动方法();
    //        };
    //        time延时.Start();
    //    }


    //    public static void 循环(TimeSpan 间隔, Action<object, EventArgs> 启动方法, string 名称 = "")
    //    {
    //        var timer = new DispatcherTimer {Interval = 间隔};
    //        timer.Tick += (o, e) => 启动方法(o, e);
    //        timer.Start();

    //        if (string.IsNullOrEmpty(名称) || Timer.ContainsKey(名称))
    //            Timer.Add(名称 + DateTime.Now.Ticks, timer);
    //        else
    //            Timer.Add(名称, timer);
    //    }


    //    public static void 关闭()
    //    {
    //        var notNull = Timer.Where(x => x.Value != null);
    //        foreach (var item in notNull)
    //        {
    //            item.Value.Stop();
    //            Timer.Clear();
    //        }
    //    }
    //}
}