using System;

namespace NJT.Ext
{

    /// <summary>
    /// 返回单件实例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class 单例模式<T> where T : new()
    {
        private static readonly Lazy<T> LazyT=new Lazy<T>(()=>new T()  );
        public static T 单例 => LazyT.Value;
    }


    ///// <summary>
    ///// 返回单件实例
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    //public sealed class 单例模式<T> where T : new()
    //{
    //    public static T 单例
    //    {
    //        get { return 单例生成器.实例; }
    //        set { 单例生成器.实例 = value; }
    //    }

    //    private class 单例生成器
    //    {
    //        private static T 对象;

    //        internal static T 实例
    //        {
    //            get
    //            {
    //                if (object.Equals(null, 对象))
    //                {
    //                    对象 = new T();
    //                }
    //                return 单例生成器.对象;
    //            }
    //            set { 单例生成器.对象 = value; }
    //        }
    //    }
    //}

}
