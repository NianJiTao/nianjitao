using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public interface I标识Data<T>
    {

        string 标识 { get; set; }
        T 数据 { get; set; }

        /// <summary>
        /// 显示的标签
        /// </summary>
        /// <value>The 标签.</value>
        string 标签 { get; set; }


        string 提示 { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        /// <value><c>true</c> if 显示; otherwise, <c>false</c>.</value>
        bool 显示 { get; set; }
    }

    public interface I标识Data : I标识Data<string>
    {

    }

    /// <summary>
    /// 简易版,不带数据变化自动通知
    /// </summary>
    public class 标识Data1 : I标识Data
    {
        public string 标识 { get; set; } = "操作";
        public string 数据 { get; set; } = "当前操作";
        public string 标签 { get; set; } = "操作:";
        public string 提示 { get; set; } = string.Empty;
        public bool 显示 { get; set; } = true;
    }
}
