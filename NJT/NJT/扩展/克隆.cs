using System;

namespace NJT.扩展
{
    public static partial class 扩展方法
    {
        public static T 克隆<T>(this T old) where T : new()
        {
            var r = new T();
            var type = old.GetType();
            foreach (var mInfo in type.GetProperties())
            {
                if (mInfo.CanRead && mInfo.CanWrite)
                {
                    mInfo.SetValue(r, mInfo.GetValue(old, null), null);
                }
            }
            return r;
        }


        public static T2 克隆属性<T, T2>(this T old) where T2 : class, T, new()
        {
            var r = new T2();
            var type = old.GetType();
            foreach (var mInfo in type.GetProperties())
            {
                if (mInfo.CanRead && mInfo.CanWrite)
                {
                    mInfo.SetValue(r, mInfo.GetValue(old, null), null);
                }
            }
            return r;
        }

        public static bool 设置属性值<T>(this T 源, T 目标, string 属性名)
        {
            if (源 == null || 目标 == null || string.IsNullOrEmpty(属性名)) return false;
            try
            {
                var type = 源.GetType();
                var r = type.GetProperty(属性名);
                if (r == null)
                {
                    return false;
                }
                if (r.CanRead && r.CanWrite)
                {
                    r.SetValue(目标, r.GetValue(源, null), null);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool 传递属性值<T>(this T 源, T 目标)
        {
            if (源 == null || 目标 == null) return false;
            try
            {
                var type = 源.GetType();
                var r = type.GetProperties();
                foreach (var mInfo in r)
                {
                    if (mInfo.CanRead && mInfo.CanWrite)
                    {
                        mInfo.SetValue(目标, mInfo.GetValue(源, null), null);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
