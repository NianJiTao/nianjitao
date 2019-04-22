using DevExpress.Mvvm;
using NJT.Core;
using Prism.Regions;
using Unity;

namespace NJT.Prism
{
    /// <summary>
    ///     继承: DevExpress.Mvvm.ViewModelBase
    /// </summary>
    public class ViewModelBase3 : ViewModelBase
    {
        protected IUnityContainer Container人事部 => RunUnity.Container1;
        protected IUnityContainer Container1 => RunUnity.Container1;
        protected IRegionManager RegionManager行政部 => RunUnity.RegionManager行政部;
        protected I日志 Log => RunUnity.Log;


        public string 名称
        {
            get { return GetProperty(() => 名称); }
            set { SetProperty(() => 名称, value); }
        }
    }
}