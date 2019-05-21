using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using NJT.Core;

namespace NJT.Core2
{
    public interface I图表字段值
    {
        /// <summary>
        /// 记录的当前字段名
        /// </summary>
        string 字段名称 { get; set; }

        ObservableCollection<I图表值> 数据列表 { get; set; }
    }
}