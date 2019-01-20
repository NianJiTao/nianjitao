using System;
using NJT.Core;
using NLog;

namespace NJT.Prism
{
    public class NLog日志 : I日志
    {
        private static readonly Lazy<Logger> Log4 = new Lazy<Logger>(LogManager.GetCurrentClassLogger);
        private static Logger Log2 => Log4.Value;


        public void Info(string 信息)
        {
            Log2.Info(信息);
        }


        public void Debug(string 信息)
        {
            Log2.Debug(信息);
        }


        public void Warn(string 信息)
        {
            Log2.Warn(信息);
        }


        public void Error(string 信息)
        {
            Log2.Error(信息);
        }
    }
}