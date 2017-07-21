using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NJT.UI
{
    /// <summary>
    /// 附加属性类
    /// </summary>
    public class 选中状态 : DependencyObject
    {
        public static readonly DependencyProperty Is选中Property =
            DependencyProperty.RegisterAttached("Is选中", typeof(bool), typeof(选中状态), new PropertyMetadata(false));

        public static bool GetIs选中(DependencyObject obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return (bool)obj.GetValue(Is选中Property);
        }

        public static void SetIs选中(DependencyObject obj, bool value)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            obj.SetValue(Is选中Property, value);
        }
    }
}
