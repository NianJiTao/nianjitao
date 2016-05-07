using System;

namespace NJT.接口
{
    public interface I定时器
    {
        TimeSpan 间隔 { get; set; }
        bool Is启动 { get; set; }
        event EventHandler 事件;
    }
}