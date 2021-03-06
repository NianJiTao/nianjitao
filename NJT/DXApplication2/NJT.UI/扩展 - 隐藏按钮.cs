﻿using System.Collections.Generic;
using System.Linq;
using DevExpress.Mvvm.Native;
using DevExpress.Xpf.Bars;
using NJT.Ext;
using NJT.Ext.Core;
using NJT.Prism;

namespace NJT.UI
{
    public static class 扩展
    {
        /// <summary>
        ///     主菜单按钮列表,如参数为空,会尝试解析 "隐藏按钮"string
        /// </summary>
        /// <param name="barItems"></param>
        /// <param name="隐藏"></param>
        public static void 隐藏按钮(this IEnumerable<IBarItem> barItems, string 隐藏 = "")
        {
            var 隐藏按钮 = 隐藏;
            if (string.IsNullOrEmpty(隐藏按钮))
                隐藏按钮 = RunUnity.Container1.TryResolve2("隐藏按钮", string.Empty);

            if (string.IsNullOrEmpty(隐藏按钮))
                return;
            var 隐藏按钮组 = 隐藏按钮.To分割(",+;");
            barItems.隐藏按钮(隐藏按钮组);
        }


        /// <summary>
        ///     主菜单按钮列表
        /// </summary>
        /// <param name="barItems"></param>
        /// <param name="隐藏按钮组"></param>
        public static void 隐藏按钮(this IEnumerable<IBarItem> barItems, string[] 隐藏按钮组)
        {
            if (barItems.Is空() || 隐藏按钮组.Is空()) return;
            barItems.OfType<BarItem>()
                .Where(x => 隐藏按钮组.Contains(x.Content.ToString2()))
                .ForEach(x => x.IsVisible = false);

            barItems.OfType<BarSubItem>()
                .ForEach(x => 隐藏按钮(x.Items, 隐藏按钮组));
        }
    }
}