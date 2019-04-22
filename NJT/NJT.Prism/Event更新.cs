using NJT.Core;


namespace NJT.Prism
{
    public class Event更新状态栏 : EventArgs<I标识Data>
    {
    }

    public class Event更新状态栏2 : EventArgs<string>
    {
    }

    public class Event更新主题 : EventArgs<string>
    {
    }

    public class Event更新时钟配置 : EventArgs<时钟配置>
    {
    }

    /// <summary>
    ///     参数为要更改的语言名称.如 zh-cn ; en-us
    /// </summary>
    public class Event更改语言 : EventArgs<string>
    {
    }

    public class Event更新配置 : EventArgs<object>
    {
    }


    public class EventSms通知 : EventArgs<Sms通知>
    {
    }

    /// <summary>
    ///     发布单行通知
    /// </summary>
    public class EventSms通知2 : EventArgs<string>
    {
    }


    public class Event更新日志记录 : EventArgs<I日志记录>
    {
    }

    /// <summary>
    ///     更新日志界面记录最大的保留长度
    /// </summary>
    public class Event更新日志记录保留长度 : EventArgs<int>
    {
    }
}