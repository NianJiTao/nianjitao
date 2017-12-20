using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using NJT.Core;
using Prism.Events;
using Unity;

namespace NJT.Prism
{
    /// <summary>
    /// 继承: DevExpress.Mvvm.ViewModelBase 
    /// </summary>
    public class ViewModelBase3 : ViewModelBase
    {
        protected IEventAggregator EventAggregator宣传部 => RunUnity.EventAggregator宣传部;
        protected IUnityContainer Container人事部 => RunUnity.Container人事部;
        protected I日志 Log => RunUnity.Log;


        public string 名称
        {
            get { return GetProperty(() => 名称); }
            set { SetProperty(() => 名称, value); }
        }

    }
}
