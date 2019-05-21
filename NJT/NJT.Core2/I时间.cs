using System;
using System.Collections.Generic;
using System.Text;

namespace NJT.Core
{
    /// <summary>
    /// 包含有时间的类,方便清理过期数据
    /// </summary>
    public interface I时间
    {
        DateTime 时间 { get; set; }
    }
}
