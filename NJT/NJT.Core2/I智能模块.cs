//using System;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NJT.Core
//{
//    //public interface I智能模块
//    //{
//    //    I智能 智能 { get; set; }
//    //}

//    //public interface I智能模块<T>
//    //{
//    //    //I智能 Ai { get; set; }
//    //    T Data { get; set; }
//    //}

//    public class 智能模块1<T> : I智能模块<T>
//    {
//        public 智能模块1(T obj)
//        {
//            Ai = new 智能1(obj);
//        }

//        public I智能 Ai { get; set; }
//        public T Data { get; set; }
//    }

//    public static partial class 扩展
//    {
//        public static I智能模块<T> ToAi<T>(this T obj)
//        {
//            var r = new 智能模块1<T>(obj);
//            return r;
//        }

//        public static I智能模块<T> ToAiTry<T>(this object obj)
//        {
//            if (obj is I智能模块<T> a)
//            {
//                return a;
//            }

//            if (obj is T b)
//            {
//                return new 智能模块1<T>(b);
//            }

//            var r = new 智能模块1<T>(default(T));
//            return r;
//        }
//    }
//}