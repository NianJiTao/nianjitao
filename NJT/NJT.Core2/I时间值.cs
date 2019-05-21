using System;
using System.Collections.Generic;
using System.Text;

namespace NJT.Core
{
    /// <summary>
    /// 时间和值
    /// </summary>
    public interface I时间值 : I名称值, I时间
    {
        string 值类型 { get; set; }
        double 数据 { get; set; }

        object Tag { get; set; }
    }


    /// <summary>
    /// 简单实现,无通知
    /// </summary>
    public class 时间值1 : I时间值
    {
        public string 值类型 { get; set; } = "Double";

        public double 数据 { get; set; } = 0d;
        public DateTime 时间 { get; set; } = DateTime.Now;
        public string 名称 { get; set; } = string.Empty;
        public object 值 { get; set; } = 0d;
        public object Tag { get; set; }


        public 时间值1()
        {
        }

        public 时间值1(string 名称, object 值, double 数据, DateTime 时间)
        {
            this.名称 = 名称;
            this.值 = 值;
            this.数据 = 数据;
            this.时间 = 时间;
        }

        public 时间值1(string 名称, double 数据, DateTime 时间)
        {
            this.名称 = 名称;
            this.值 = 数据;
            this.数据 = 数据;
            this.时间 = 时间;
        }
    }
}
