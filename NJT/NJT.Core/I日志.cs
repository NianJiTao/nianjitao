namespace NJT.Core

{
    public interface I日志
    {
        /// <summary>
        ///     正常记录信息.
        /// </summary>
        /// <param name="信息"></param>
        void Info(string 信息);


        /// <summary>
        ///     记录调试需要的信息.
        /// </summary>
        /// <param name="信息"></param>
        void Debug(string 信息);


        void Warn(string 信息);


        /// <summary>
        ///     记录出错信息
        /// </summary>
        /// <param name="信息"></param>
        void Error(string 信息);
    }


    /// <summary>
    /// 空日志实现
    /// </summary>
    public class Log1 : I日志
    {
        public void Info(string 信息)
        {
        }


        public void Debug(string 信息)
        {
        }


        public void Warn(string 信息)
        {
        }


        public void Error(string 信息)
        {
        }
    }
}