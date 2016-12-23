using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NJT.Convert
{
    /// <summary>
    /// Class Bool转换.参数为至少2个.
    /// </summary>
    public static class Bool转换
    {
        /// <summary>
        /// true,真,假
        /// 值为真,返回参数1,为假,返回参数2
        /// </summary>
        /// <param name="value">bool判断</param>
        /// <param name="值">2个候选值.</param>
        /// <returns>值为真,返回参数1,为假,返回参数2</returns>
        public static object 转换(object value, params object[] 值)
        {
            var r = value is bool;
            if (!r) return Binding.DoNothing;

            if (值 == null) return Binding.DoNothing;

            return (bool)value
                ? (值.Any()
                    ? 值[0]
                    : Binding.DoNothing)
                : (值.Length > 1
                    ? 值[1]
                    : Binding.DoNothing);
        }
    }
}
