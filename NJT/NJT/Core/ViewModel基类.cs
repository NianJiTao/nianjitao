using NJT;
using Prism.Logging;
using Prism.Mvvm;
using Prism.Events;
using Prism.Regions;
using Unity;


namespace NJT.Common
{
    /// <summary>
    ///     可更新界面的,T为Model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Vm基类<T> : BindableBase
    {
        private T _model;
        private ILoggerFacade _log;
        private IEventAggregator _新闻部;
        private IUnityContainer _人事部;
        private IRegionManager _行政部;

        public T Model
        {
            get { return _model; }
            set { SetProperty(ref _model, value); }
        }

        public Vm基类()
        {
            _model = default(T);
        }

        public ILoggerFacade Log
        {
            get
            {
                if (_log == null)
                    Log = 人事部.Resolve<ILoggerFacade>();
                return _log;
            }

            set { _log = value; }
        }

        public IEventAggregator 新闻部
        {
            get { return _新闻部 ?? (_新闻部 = 小冰.宣传部); }
            set { _新闻部 = value; }
        }

        public IUnityContainer 人事部
        {
            get { return _人事部 ?? (_人事部 = 小冰.人事部); }
            set { _人事部 = value; }
        }

        public IRegionManager 行政部
        {
            get { return _行政部 ?? (_行政部 = 小冰.行政部); }

            set { _行政部 = value; }
        }
    }
}