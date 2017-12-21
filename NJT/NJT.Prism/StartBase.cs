using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJT.Core;

namespace NJT.Prism
{
    public class StartBase : ViewModelBase3, I启动
    {
        public bool Is启动 { get; protected set; }
        public Guid 身份证 { get; set; } = Guid.NewGuid();

        public virtual void 启动()
        {
            if (Is启动) return;
            Is启动 = true;
        }


        public virtual void 停止()
        {
            Is启动 = false;
        }
    }
}