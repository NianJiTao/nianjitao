namespace NJT.Core

{
    public interface I配置服务<T> : I启动
    {
        /// <summary>
        ///     读取 默认的系统配置.
        ///     路径为 程序目录下 "配置.xml"
        ///     为全局单例.
        /// </summary>
        /// <returns>T.</returns>
        T 读取();


        /// <summary>
        ///     写入 默认的系统配置.
        ///     路径为 程序目录下 "配置.xml"
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool 写入();
    }
}