using System;
using Prism.Mvvm;
using Unity;

namespace NJT.Prism
{
    public static partial class 扩展
    {
        /// <summary>
        ///     注册View 调用什么vm类型,vm使用IUnityContainer解析
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="container"></param>
        public static void RegVm<TView, TViewModel>(this IUnityContainer container)
        {
            ViewModelLocationProvider.Register<TView>(() => container.Resolve<TViewModel>());
        }

        /// <summary>
        /// 尝试解析类型,错误时返回默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T TryResolve5<T>(this IUnityContainer obj)
        {
            if (obj == null) return default(T);
            try
            {
                return obj.Resolve<T>();
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}