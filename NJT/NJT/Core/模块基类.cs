using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.Unity;
 

namespace NJT.Common
{
    public class 模块基类 : IModule
    {
        /// <summary>
        ///     接收人事部和行政部.
        /// </summary>
        /// <param name="人事部cs">The 模块 人事部.</param>
        /// <param name="行政部cs">The 模块 行政部.</param>
        public 模块基类(IUnityContainer 人事部cs, IRegionManager 行政部cs)
        {
            人事部 = 人事部cs;
            行政部 = 行政部cs;
        }

        /// <summary>
        ///     处理程序使用哪些模块
        /// </summary>
        /// <value>The 人事部.</value>
        public IUnityContainer 人事部 { get; private set; }

        /// <summary>
        ///     决定模块在哪里工作显示
        /// </summary>
        /// <value>The 行政中心.</value>
        public IRegionManager 行政部 { get; private set; }

        public void Initialize()
        {
            初始化();
        }

        public virtual void 初始化()
        {
        }
    }
}