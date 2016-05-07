using System;
using System.Windows.Input;

namespace NJT.接口
{
    public interface I定时任务 : I启用, I名称
    {
        Guid 唯一编号 { get; set; }
        DateTime 启动时间 { get; set; }
        ICommand 命令 { get; set; }
        bool Is已执行 { get; set; }
        bool Is倒计时 { get; set; }
        bool Is已公告 { get; set; }
    }

    public class 定时任务 : I定时任务
    {
        public 定时任务()
        {
            唯一编号 = Guid.NewGuid();
        }

        public Guid 唯一编号 { get; set; }
        public DateTime 启动时间 { get; set; }
        public ICommand 命令 { get; set; }
        public string 名称 { get; set; }
        public bool Is启用 { get; set; }
        public bool Is倒计时 { get; set; }
        public bool Is已执行 { get; set; }
        public bool Is已公告 { get; set; }
    }
}