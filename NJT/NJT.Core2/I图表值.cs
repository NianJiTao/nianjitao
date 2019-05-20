using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    /// <summary>
    /// 名称,时间,数据double
    /// </summary>
    public interface I图表值 : I名称, I树枝<double>
    {
        DateTime 时间 { get; set; }
    }

}
