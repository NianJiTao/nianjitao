using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJT.Core;
using NJT.Prism;
using Prism.Events;

namespace NJT.UI
{
    //public static class 消息
    //{
    //    static IEventAggregator EventAggregator宣传部 => RunUnity.EventAggregator宣传部;

    //    /// <summary>
    //    ///     快速发布状态栏通知消息
    //    /// </summary>
    //    /// <param name="消息内容">The 消息内容.</param>
    //    public static void 更新状态栏(string 消息内容)
    //    {
    //        EventAggregator宣传部.GetEvent<Event更新状态栏2>().Publish(消息内容);
    //    }

    //    /// <summary>
    //    ///     快速发布状态栏通知消息 ,并根据类别传送
    //    /// </summary>
    //    /// <param name="消息内容">The 消息内容.</param>
    //    /// <param name="类别">The 类别.</param>
    //    public static void 更新状态栏(string 消息内容, string 类别)
    //    {
    //        EventAggregator宣传部.GetEvent<Event更新状态栏>().Publish(new 状态栏Data2(消息内容, 类别));
    //    }

    //    public static void 发布消息(string 消息内容)
    //    {
    //        EventAggregator宣传部.GetEvent<EventSms通知2>().Publish(消息内容);
    //    }

    //    public static void 发布消息(string 消息内容, string 标题)
    //    {
    //        EventAggregator宣传部.GetEvent<EventSms通知>().Publish(new Sms通知(标题, 消息内容));
    //    }
    //}
}