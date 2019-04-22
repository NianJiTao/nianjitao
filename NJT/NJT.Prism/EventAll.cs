using System;
using NJT.Core;


namespace NJT.Prism
{
    /// <summary>
    ///     收到此事件.就打开日志视图.或者日志目录
    /// </summary>
    public class Event查看日志 : EventArgs
    {
    }


    public class Event保存配置 : EventArgs
    {
    }


    public class Event退出 : EventArgs
    {
    }

    /// <summary>
    ///     收到此事件.就打开系统设置视图.
    /// </summary>
    public class Event系统设置 : EventArgs
    {
    }


    public class Event读取注册码 : EventArgs
    {
    }

    public class Event验证授权 : EventArgs
    {
    }

    public class Event验证授权结果 : EventArgs<bool>
    {
    }

    public class Event发布授权配置 : EventArgs<I授权配置>
    {
    }

    public class Event保存授权配置 : EventArgs<I授权配置>
    {
    }

    /// <summary>
    ///     参数为返回的次数
    /// </summary>
    public class Event视图返回 : EventArgs<int>
    {
    }

    public class Event弹出消息 : EventArgs<I弹出消息>
    {
    }

    public class Event弹出警告 : EventArgs<I弹出消息>
    {
    }

    /// <summary>
    ///     参数为唯一视图名称
    /// </summary>
    public class Event激活视图 : EventArgs<string>
    {
    }


    /// <summary>
    ///     参数为加载到的位置
    /// </summary>
    public class Event加载状态栏 : EventArgs<string>
    {
    }

    /// <summary>
    ///     参数为加载到的位置
    /// </summary>
    public class Event加载菜单栏 : EventArgs<string>
    {
    }

    /// <summary>
    ///     参数为加载到的位置
    /// </summary>
    public class Event加载导航栏 : EventArgs<string>
    {
    }


    public class PubEvent<T> : EventArgs<EData<T>>
    {
    }


    public class EventMenu : EventArgs<string>
    {
    }


    /// <summary>
    ///     参数为文本内容
    /// </summary>
    public class Event朗读文本 : EventArgs<string>
    {
    }


    public class Event加载变量表 : EventArgs<string>
    {
    }


    public class Event菜单字体 : EventArgs<double>
    {
    }


    /// <summary>
    ///     参数为tableView名称, 需要可以通过Container解析出来DataViewBase
    /// </summary>
    public class Event导出Excel文档 : EventArgs<string>
    {
    }

    /// <summary>
    ///     参数为tableView名称, 需要可以通过Container解析出来DataViewBase
    /// </summary>
    public class Event导出Pdf文档 : EventArgs<string>
    {
    }

    /// <summary>
    ///     报告当前sql连接状态.是正常还是断开.
    /// </summary>
    public class EventSql连接变化 : EventArgs<bool>
    {
    }

    public class Event双击时钟 : EventArgs<object>
    {
    }

    //public class Event双击状态栏 : EventArgs<object>
    //{
    //}
    public class Event双击关于 : EventArgs<object>
    {
    }

    public class EventSql连接测试 : EventArgs
    {
    }

    public class EventSql连接状态查询 : EventArgs
    {
    }

    public class Event日志记录 : EventArgs<I日志记录>
    {
    }

    /// <summary>
    ///     收到此事件.立即清理过期数据
    /// </summary>
    public class Event过期数据清理 : EventArgs
    {
    }

    public class Event关闭弹出窗口 : EventArgs
    {
    }
}