using System.Collections.Generic;
using System.Linq;
using System.Resources;
using Telerik.Windows.Controls;

namespace NJT.Common
{
    using NJT.Common;
    public static class Telerik主题
    {
        private static readonly List<Theme> _主题列表 =
            new List<Theme>
            {
                new Windows7Theme(),
                new Office_BlackTheme(),
                new Office_BlueTheme(),
                new Office_SilverTheme(),
                new SummerTheme(),
                new VistaTheme(),
                new TransparentTheme(),
                new Expression_DarkTheme(),
             
                new Windows8Theme()
            };

        /// <summary>
        ///     用于绑定属性列表显示
        /// </summary>
        /// <value>The 主题名称列表.</value>
        public static List<string> 主题名称列表
        {
            get
            {
                return 主题列表.Select(x => x.ToString()).ToList();
                //下面方法过时,准备删除
                //var r = new List<string>();
                //r.AddRange(主题列表.Select(x => x.ToString()));
                //return r;
            }
        }

        private static List<Theme> 主题列表
        {
            get { return _主题列表; }
        }

        private static Theme 当前主题
        {
            get { return StyleManager.ApplicationTheme; }
            set
            {
                if (!Equals(StyleManager.ApplicationTheme, value))
                {
                    StyleManager.ApplicationTheme = value;
                }
            }
        }

        public static void 设置资源(ResourceManager resourceManager)
        {
            LocalizationManager.Manager = new LocalizationManager {ResourceManager = resourceManager};
        }

        /// <summary>
        ///     按名称查找主题并应用.
        ///     通常是配置里面指定的名称.如果找不到,就调用Windows7Theme.
        /// </summary>
        /// <param name="主题名称">The 主题名称.</param>
        public static void 设置主题(string 主题名称)
        {
            var 新主题 = 查找(主题名称);
            当前主题 = 新主题 ?? 主题列表.First();
        }

        private static Theme 查找(string 主题名称)
        {
            var r = 主题列表.FirstOrDefault(x => x.ToString() == 主题名称);
            return r ?? 主题列表.First();
        }
    }
}