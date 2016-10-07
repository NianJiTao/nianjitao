using Prism.Logging;
using NLog;

namespace NJT.Common
{
    public class NLog日志 : ILoggerFacade
    {
        private Logger _log3;

        private Logger Log2 => _log3 ?? (_log3 = LogManager.GetCurrentClassLogger());

        public void Log(string message, Category category, Priority priority)
        {

            switch (category)
            {
                case Category.Debug:
                    Log2.Debug(message, priority);
                    break;
                case Category.Exception:
                    Log2.Error(message, priority);
                    break;
                case Category.Info:
                    Log2.Info(message, priority);
                    break;
                case Category.Warn:
                    Log2.Warn(message, priority);
                    break;
                default:
                    Log2.Info(message, priority);
                    break;
            }
        }
    }
}
