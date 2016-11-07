using System.Collections.ObjectModel;

namespace NJT.Tree.Wpf
{
    public interface I树枝<T1,T2> : I身份证
    {
        bool Is选中 { get; set; }

        bool Is展开 { get; set; }

        bool 可展开 { get; }

        /// <summary>
        /// 当前树枝深度.
        /// </summary>
        int 深度 { get; set; }

        T1 选择项 { get; set; }

        T1 父 { get; set; }

        T2 数据 { get; set; }

        object Tag { get; set; }

        /// <summary>
        /// 刷新子列表
        /// </summary>
        void 刷新();

        ObservableCollection<T1> 子 { get; }
    }
}
