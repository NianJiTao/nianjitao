//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Practices.Unity;
//using NJT.Common;
//using NJT.Events;
//using NJT.接口;
//using Prism.Events;
//using Prism.Regions;

//namespace NJT.Services
//{
//    public class 授权服务1 : 启动基类, I授权服务
//    {
//        private string _公钥;
//        private I授权配置 _配置1;

//        public 授权服务1(IUnityContainer 人事部cs, IEventAggregator 宣传部cs, IRegionManager 模块cs)
//            : base(人事部cs, 宣传部cs, 模块cs)
//        {
//        }

//        public bool Is已验证 { get; private set; }

//        public override void 启动()
//        {
//            if (Is启动) return;
//            base.启动();
//            新闻部.GetEvent<授权验证Event>().Subscribe(授权检测, true);
//        }


//        public bool Is已注册 { get; private set; }

//        public void 授权检测()
//        {
//            Is已注册 = false;
//            Debug.Assert(_公钥 != null, "公钥 != null");
//            Debug.Assert(_配置1 != null, "授权配置 != null");

//            Is已注册 = 注册.验证注册(_公钥, 注册.计算特征码(), _配置1.注册码);
//            Is已验证 = true;
//            小冰.已注册 = Is已注册;
//            小冰.状态栏更新("授权", Is已注册 ? " 已注册" : " 未注册");
//            新闻部.GetEvent<授权状态更新Event>().Publish(Is已注册);
//        }

//        private void 授权检测(Tuple<string, I授权配置> x)
//        {
//            Debug.Assert(x != null, "授权验证参数 != null");
//            _公钥 = x.Item1;
//            _配置1 = x.Item2;

//            授权检测();
//        }
//    }
//}
