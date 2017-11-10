using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using DevExpress.Xpf.Bars;

namespace NJT.UI
{
    public static partial class 扩展
    {
       
        public static void 隐藏按钮Action(this IEnumerable<IBarItem> barItems, string[] 隐藏按钮组)
        {
            barItems.OfType<BarItem>()
                .Where(x => 隐藏按钮组.Contains(x.Content.ToString()))
                .ForEach(x => x.IsVisible = false);

            barItems.OfType<BarSubItem>()
                .ForEach(x => 隐藏按钮Action(x.Items, 隐藏按钮组));

        }

    }
}