using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJT.Core;
using Prism.Logging;

namespace NJT.Prism
{
    public class Nlog2 : ILoggerFacade
    {
        public I日志 日志 { get; set; }

        public Nlog2(I日志 日志1)
        {
            日志 = 日志1;
        }

        public void Log(string message, Category category, Priority priority)
        {

            if (日志 == null)
            {
                return;
            }
            switch (category)
            {
                case Category.Debug:
                    日志.Debug(message);
                    break;
                case Category.Exception:
                    日志.Error(message);
                    break;
                case Category.Info:
                    日志.Info(message);
                    break;
                case Category.Warn:
                    日志.Warn(message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
        }
    }
}
