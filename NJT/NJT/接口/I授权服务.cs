using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.接口
{
    public interface I授权服务 : I启动
    {

        bool Is已注册 { get; }

        void 授权检测();
    }
}
