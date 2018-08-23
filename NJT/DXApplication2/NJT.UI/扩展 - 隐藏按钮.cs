using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Xpf.Bars;
using NJT.Ext;
using NJT.Prism;
using Unity.Interception.Utilities;

namespace NJT.UI
{
    public static partial class 扩展
    {
        /// <summary>
        /// 主菜单按钮列表,如参数为空,会尝试解析 "隐藏按钮"string
        /// </summary>
        /// <param name="barItems"></param>
        /// <param name="隐藏"></param>
        public static void 隐藏按钮(this IEnumerable<IBarItem> barItems, string 隐藏 = "")
        {
            var 隐藏按钮 = 隐藏;
            if (string.IsNullOrEmpty(隐藏按钮))
            {
                隐藏按钮 = RunUnity.Container人事部.TryResolve2<string>("隐藏按钮", string.Empty);
            }

            if (!string.IsNullOrEmpty(隐藏按钮))
            {
                var 隐藏按钮组 = 隐藏按钮.To分割(",+;");
                barItems.隐藏按钮(隐藏按钮组);
            }
        }

        /// <summary>
        /// 主菜单按钮列表
        /// </summary>
        /// <param name="barItems"></param>
        /// <param name="隐藏按钮组"></param>
        public static void 隐藏按钮(this IEnumerable<IBarItem> barItems, string[] 隐藏按钮组)
        {
            if (隐藏按钮组 == null || 隐藏按钮组.Any() == false || 隐藏按钮组.Any() == false)
            {
                return;
            }
            barItems.OfType<BarItem>()
                .Where(x => 隐藏按钮组.Contains(x.Content.ToString()))
                .ForEach(x => x.IsVisible = false);

            barItems.OfType<BarSubItem>()
                .ForEach(x => 隐藏按钮(x.Items, 隐藏按钮组));
        }
    }
}