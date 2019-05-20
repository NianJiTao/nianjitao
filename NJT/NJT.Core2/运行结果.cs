namespace NJT.Core

{
    /// <summary>
    ///     表示方法运行的结果.
    /// </summary>
    public class 运行结果 : I运行结果
    {
        public 运行结果(bool isTrue)
        {
            IsTrue = isTrue;
        }


        public 运行结果(bool isTrue, string errorMessage)
        {
            IsTrue = isTrue;
            Message = errorMessage;
        }


        /// <summary>
        ///     执行是否成功.
        /// </summary>
        public bool IsTrue { get; set; } = true;

        /// <summary>
        ///     执行错误时的信息.
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }


    /// <summary>
    ///     表示方法运行的结果.T为携带数据
    /// </summary>
    public class 运行结果<T> : I运行结果<T>
    {
        public 运行结果(bool isTrue)
        {
            IsTrue = isTrue;
        }


        public 运行结果(bool isTrue, string errorMessage)
        {
            IsTrue = isTrue;
            Message = errorMessage;
        }


        public 运行结果(bool isTrue, string errorMessage, T data)
        {
            IsTrue = isTrue;
            Message = errorMessage;
            Data = data;
        }


        /// <summary>
        ///     执行是否成功.
        /// </summary>
        public bool IsTrue { get; set; } 

        /// <summary>
        ///     执行错误时的信息.
        /// </summary>

        public string Message { get; set; } = string.Empty;

        public T Data { get; set; } 
    }
}