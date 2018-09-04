using System;
using System.Linq;
using System.Reflection;
using NJT.Core;

namespace NJT.Ext
{
    public static partial class 扩展
    {
        public static void 更新显示(this I按钮显示 按钮表, string 隐藏按钮字串)
        {
            var 隐藏按钮组 = 隐藏按钮字串.To分割(",+;")
                .Select(x => x.Trim())
                .ToArray();

            更新显示(按钮表, 隐藏按钮组);
        }

        public static void 更新显示(this I按钮显示 按钮表, string[] 隐藏按钮字串)
        {
            if (按钮表==null || 隐藏按钮字串==null )
            {
                return;
            }
            var t = 按钮表.GetType();
            var b = typeof(bool);
            var properties = t.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            var sel = properties
                .Where(x => x.PropertyType == b && x.CanWrite)
                .ToList();
            foreach (var item in sel)
            {
                item.SetValue(按钮表, 隐藏按钮字串.Contains(item.Name) == false);
            }
        }
    }
}