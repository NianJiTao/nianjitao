using NJT.Core;
using Prism.Events;

namespace NJT.Prism
{
    public class Event关于 : PubSubEvent
    {
    }

    public class Event查看日志 : PubSubEvent
    {
    }

    public class Event帮助 : PubSubEvent
    {
    }

    public class Event保存配置 : PubSubEvent
    {
    }

    public class Event配置更新 : PubSubEvent
    {
    }

    public class Event退出 : PubSubEvent
    {
    }

    public class Event系统设置 : PubSubEvent
    {
    }

    public class Event系统注册 : PubSubEvent
    {
    }

    public class Event读取注册码 : PubSubEvent
    {
    }

    public class Event验证授权 : PubSubEvent
    {
    }

    public class Event发布授权配置 : PubSubEvent<I授权配置>
    {
    }

    public class Event保存授权配置 : PubSubEvent<I授权配置>
    {
    }
    /// <summary>
    /// 参数为返回的次数
    /// </summary>
    public class Event返回视图 : PubSubEvent<int>
    {
    }  

    /// <summary>
    ///     参数为要更改的语言名称.如 zh-cn ; en-us
    /// </summary>
    public class Event更改语言 : PubSubEvent<string>
    {
    }

    public class Event弹出消息 : PubSubEvent<I弹出消息>
    {
    }

    /// <summary>
    /// 参数为唯一视图名称
    /// </summary>
    public class Event激活视图 : PubSubEvent<string>
    {
    }  


    public class Event状态栏更新 : PubSubEvent<I标识Data>
    {
    }


    /// <summary>
    ///  参数为加载到的位置
    /// </summary>
    public class Event加载状态栏 : PubSubEvent<string>
    {
    }

    /// <summary>
    ///     参数为加载到的位置
    /// </summary>
    public class Event加载菜单栏 : PubSubEvent<string>
    {
    }

    /// <summary>
    ///     参数为加载到的位置
    /// </summary>
    public class Event加载导航栏 : PubSubEvent<string>
    {
    }


    public class PubEvent<T> : PubSubEvent<EData<T>>
    {
    }


    public class EventMenu : PubSubEvent<string>
    {
    }

    public class Event选择树 : PubSubEvent<树>
    {
    }

    /// <summary>
    ///     参数为文本内容
    /// </summary>
    public class Event朗读文本 : PubSubEvent<string>
    {
    }


    public class Event加载变量表 : PubSubEvent<string>
    {
    }


    public class Event菜单字体 : PubSubEvent<double>
    {
    }

    public class Event主题更新 : PubSubEvent<string>
    {
    }

    public class Event导出Excel文档 : PubSubEvent<string>
    {
    }

    /// <summary>
    ///     参数为tableView名称, 需要可以通过Container解析出来DataViewBase
    /// </summary>
    public class Event导出Pdf文档 : PubSubEvent<string>
    {
    }

    public class EventSql连接变化 : PubSubEvent<bool>
    {
    }

    public class Event双击时钟 : PubSubEvent
    {
    }
}