using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{

    public interface ISql监测配置
    {
        bool Is启用Sql { get; set; }
        int 连接监测间隔秒 { get; set; }
        int 最大失联次数 { get; set; }

    }
    public class Sql监测配置1 : ISql监测配置
    {
        public bool Is启用Sql { get; set; } = true;
        public int 连接监测间隔秒 { get; set; } = 5;
        public int 最大失联次数 { get; set; } = 3;
    }

}
