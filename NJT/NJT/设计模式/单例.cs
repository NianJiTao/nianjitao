using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.设计模式
{
    /// <summary>
    /// 返回单件实例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class 单例模式<T> where T : new()
    {
        public static T 单例
        {
            get { return SingletonCreator.instance; }
            set { SingletonCreator.instance = value; }
        }

        private class SingletonCreator
        {
            private static T a;

            internal static T instance
            {
                get
                {
                    if (object.Equals(null, a))
                    {
                        a = new T();
                    }
                    return SingletonCreator.a;
                }
                set { SingletonCreator.a = value; }
            }
        }
    }

}
