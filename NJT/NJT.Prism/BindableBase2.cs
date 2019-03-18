//using System;
//using System.Xml.Serialization;
//using NJT.Core;
//using Prism.Events;
//using Prism.Mvvm;
//using Prism.Regions;
//using Unity;

//namespace NJT.Prism
//{
//    public class BindableBase2 : BindableBase, I身份证
//    {
//        private string _名称 = string.Empty;

//        /// <summary>
//        ///     存放视图对象,以方便调用.
//        /// </summary>
//        /// <value>The view.</value>
//        public object View { get; set; }


//        protected I日志 Log => RunUnity.Log;

//        protected IUnityContainer Container人事部 => RunUnity.Container人事部;

//        protected IEventAggregator EventAggregator宣传部 => RunUnity.EventAggregator宣传部;

//        protected IRegionManager RegionManager行政部 => RunUnity.RegionManager行政部;

//        [XmlIgnore] public Guid 身份证 { get; set; } = Guid.NewGuid();

//        [XmlIgnore]
//        public string 名称
//        {
//            get => _名称;
//            set => SetProperty(ref _名称, value);
//        }
//    }
//}