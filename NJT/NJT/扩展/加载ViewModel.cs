using Microsoft.Practices.Prism.Mvvm;

namespace NJT.扩展
{
    public static partial class 扩展方法
    {
        /// <summary>
        /// 自动加载ViewModel,
        /// View路径为  ./Views/视图.
        /// ViewModel路径为  ./ViewModels/视图ViewModel.
        /// </summary>
        /// <param name="视图1"></param>
        /// <returns></returns>
        public static IView LoadViewModel(this IView 视图1)
        {
            ViewModelLocationProvider.AutoWireViewModelChanged(视图1);
            return 视图1;
        }

    }
}
