using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using NJT.Common;
using Prism.Regions;

namespace NJT.项目启动
{
    public class 启动模块 : 模块基类
    {
        public 启动模块(IUnityContainer container, IRegionManager regionRegistry)
            : base(container, regionRegistry)
        {
        }

        public override void 初始化()
        {
            时间.延时启动(100, () => 人事部.Resolve<系统初始化>().启动());
        }
    }
}
