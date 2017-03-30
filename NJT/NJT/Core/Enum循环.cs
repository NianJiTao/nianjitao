using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Common
{
    /// <summary>
    ///     工作日:周1-周5 ;
    /// </summary>
    [Serializable]
    public enum Enum循环
    {
        一次 = 0,
        每日 = 1,
        每周 = 2,
        每月 = 3,
        每年 = 4,
        工作日 = 5,
        周末 = 6,
        间隔 = 7,
    }
}
