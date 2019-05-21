using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Threading;
using DevExpress.Mvvm;
using NJT.Core;

namespace NJT.Prism
{
    public class Service系统注册 : StartBase, IService系统注册
    {
        private bool _is验证中;
        private DispatcherTimer _授权监测Timer;
        public TimeSpan 验证间隔 { get; set; } = 常量.M30分;
        public TimeSpan 记录日志间隔 { get; set; } = 常量.D1天;
        public bool 记录日志 { get; set; } = false;


        public override void 启动()
        {
            if (Is启动) return;
            Is启动 = true;

            Init授权监测();

            验证授权();
        }


        public override void 停止()
        {
            if (Is启动)
            {
                Is启动 = false;
                _授权监测Timer?.Stop();
            }
        }


        private void Init授权监测()
        {
            Messenger.Default.Register<Event验证授权>(this, x => 验证授权());
            //EventAggregator宣传部?.GetEvent<Event验证授权>().Subscribe(验证授权, true);
            _授权监测Timer = new DispatcherTimer
            {
                Interval = 验证间隔
            };
            _授权监测Timer.Tick += 授权监测TimerTick;
            _授权监测Timer.Start();
        }


        private void 授权监测TimerTick(object sender, EventArgs e)
        {
            验证授权();
        }


        public void 验证授权()
        {
            if (_is验证中)
                return;
            _is验证中 = true;
            Task.Run(() => 硬件狗验证() || 软件狗验证())
                .ContinueWith(x =>
                {
                    _is验证中 = false;
                    授权结果发布(x.Result);
                });
        }


        public bool 软件狗验证()
        {
            return 注册3.验证注册(授权信息.公钥2018, 注册3.计算特征码(), 授权信息.注册码);
        }


        public virtual bool 硬件狗验证()
        {
            return false;
        }


        private void 授权结果发布(bool result)
        {
            授权信息.授权 = result;
            var str = result ? "已授权" : "未授权";
            if (result == false)
            {
                消息.更新状态栏(str, "授权");
                if (记录日志 && !超频检测.Is超频("未授权记录日志", 常量.D1天))
                    Log.Info($"软件:{str}");
            }

            Messenger.Default.Send(new Event验证授权结果() {Data = result});
        }
    }
}