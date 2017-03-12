using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJT.Core;
using NLog;

namespace NJT.Prism
{
    public class NLog日志 : I日志
    {

        private static Logger Log2 => Log4.Value;

        private static readonly Lazy<Logger> Log4 = new Lazy<Logger>(LogManager.GetCurrentClassLogger);

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
