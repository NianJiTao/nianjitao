using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public interface I按钮显示
    {
    }

    public static partial class 扩展
    {
        public static void 更新显示(this I按钮显示 按钮表, string[] 隐藏按钮字串)
        {
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
