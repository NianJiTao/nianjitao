using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using NJT.Core;

namespace NJT.Prism
{
    /// <summary>
    /// BindableBase 可以通知
    /// </summary>
    public class 时间值2 : BindableBase, I时间值
    {
        public 时间值2()
        {
            名称 = string.Empty;
            数据 = 0d;
            时间 = DateTime.Now;
        }


        public double 数据
        {
            get { return GetProperty(() => 数据); }
            set { SetProperty(() => 数据, value); }
        }

        public DateTime 时间 { get; set; }
        public string 名称 { get; set; }

        public object 值 { get; set; }
        public object Tag { get; set; }
        public string 值类型 { get; set; }
    }
}
