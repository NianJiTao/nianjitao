namespace NJT.Core

{
    /// <summary>
    ///     表示方法运行的结果.
    /// </summary>
    public class 运行结果: I运行结果
    {
        public 运行结果(bool istrue)
        {
            IsTrue = istrue;
        }


        public 运行结果(bool istrue, string errorMessage)
        {
            IsTrue = istrue;
            ErrorMess = errorMessage;
        }


        /// <summary>
        ///     执行是否成功.
        /// </summary>
        public bool IsTrue { get; set; } = true;


        /// <summary>
        ///     执行错误时的信息.
        /// </summary>
        public string ErrorMess { get; set; } = string.Empty;
    }


    /// <summary>
    ///     表示方法运行的结果.T为携带数据
    /// </summary>
    public class 运行结果<T>: I运行结果<T>
    {
        public 运行结果(bool istrue)
        {
            IsTrue = istrue;
        }

        public 运行结果(bool istrue, string errorMessage)
        {
            IsTrue = istrue;
            ErrorMess = errorMessage;
        }

        /// <summary>
        ///     执行是否成功.
        /// </summary>
        public bool IsTrue { get; set; } = true;

        /// <summary>
        ///     执行错误时的信息.
        /// </summary>
        public string ErrorMess { get; set; } = string.Empty;


        public T Data { get; set; } = default(T);
    }
}