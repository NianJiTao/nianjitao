using System.Runtime.InteropServices;

namespace NJT.Core
{
    /// <summary>
    ///     表示方法运行的结果.
    /// </summary>
    public interface I运行结果
    {
        /// <summary>
        ///     执行是否成功.
        /// </summary>
        bool IsTrue { get; set; }

        ///// <summary>
        /////     执行错误时的信息.
        ///// </summary>
        //string ErrorMess { get; set; }

        string Message { get; set; }
    }

    public interface I运行结果<T> : I运行结果
    {
        T Data { get; set; }
    }
}