using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using NJT.Core;
using Prism.Mvvm;

namespace NJT.Prism
{
    public static partial class 扩展
    {

        /// <summary>
        /// 注册View 调用什么vm类型,vm使用IUnityContainer解析
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="container"></param>
        public static void RegVm<TView, TViewModel>(this IUnityContainer container)
        {
            ViewModelLocationProvider.Register<TView>(() => container.Resolve<TViewModel>());
        }


        /// <summary>
        ///  通过名称解析出T,使用data前检查istrue; 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container">The container.</param>
        /// <param name="name">The name.</param>
        /// <returns>T.</returns>
        public static 运行结果<T> TryResolve2<T>(this IUnityContainer container, string name)
        {
            return RunFunc.TryRun(() => container.Resolve<T>(name));
        }

        public static 运行结果<T> TryResolve2<T>(this IUnityContainer container)
        {
            return RunFunc.TryRun(() => container.Resolve<T>());
        }
    }
}
