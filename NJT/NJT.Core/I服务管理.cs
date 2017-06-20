using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public interface I服务管理 
    {
        运行结果 启动结果 { get; }
        void 启动相关服务(object 参数);
    }
}
