using System.Collections.ObjectModel;

namespace NJT.Tree
{

    /// <summary>
    /// T:树枝,T2:果实
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public interface I树<T,T2>: I身份证
    {

        int 深度 { get; set; }

        bool Is展开 { get; set; }

        bool 可展开 { get; }

        T2 数据 { get; set; }

        T 选择项 { get; set; }

        void 刷新();

        ObservableCollection<T> 子 { get; }
    }

}
