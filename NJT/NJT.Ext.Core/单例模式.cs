using System;
using System.Collections.Generic;
using System.Text;

namespace NJT.Ext.Core
{
    /// <summary>
    /// 返回单件实例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class 单例模式<T> where T : new()
    {
        private static readonly Lazy<T> LazyT = new Lazy<T>(() => new T());
        public static T 单例 => LazyT.Value;
    }
}
