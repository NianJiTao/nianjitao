using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJT.Core;
using Prism.Events;

namespace NJT.Prism
{
    public class Event更新状态栏 : PubSubEvent<I标识Data>
    {
    }
    public class Event更新状态栏2 : PubSubEvent<string>
    {
    }
    public class Event更新主题 : PubSubEvent<string>
    {
    }

    public class Event更新时钟配置 : PubSubEvent<时钟配置>
    {
    }

    /// <summary>
    ///     参数为要更改的语言名称.如 zh-cn ; en-us
    /// </summary>
    public class Event更改语言 : PubSubEvent<string>
    {
    }

    public class Event更新配置 : PubSubEvent<object>
    {
    }


    public class EventSms通知 : PubSubEvent<Sms通知>
    {
    }

    /// <summary>
    /// 发布单行通知
    /// </summary>
    public class EventSms通知2 : PubSubEvent<string>
    {
    }


    public class Event更新日志记录 : PubSubEvent<I日志记录>
    {
    }

    /// <summary>
    /// 更新日志界面记录最大的保留长度
    /// </summary>
    public class Event更新日志记录保留长度 : PubSubEvent<int>
    {
    }
}