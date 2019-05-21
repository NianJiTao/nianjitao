using System.Threading.Tasks;
using System.Windows;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using NJT.Core;
using NJT.Prism;

namespace NJT.UI.ViewModels
{
    public class View注册1ViewModel : ViewModelBase3
    {
        private string _历史客户名称;

        private string _历史注册码;


        public View注册1ViewModel()
        {
            名称 = "授权配置";
            if (IsInDesignMode) return;
            Messenger.Default.Register<Event发布授权配置>(this, x => 收到注册码Action(x.Data));
            Messenger.Default.Register<Event激活视图>(this, x => 激活视图Action(x.Data));
            //EventAggregator宣传部.GetEvent<Event发布授权配置>().Subscribe(收到注册码Action, true);
            //EventAggregator宣传部.GetEvent<Event激活视图>().Subscribe(激活视图Action, true);
            读取特征码();
            读取注册码();
        }


        public IDelegateCommand 验证Command => this.GetCom(nameof(验证Command), 验证Action);


        public IDelegateCommand 复制Command => this.GetCom(nameof(复制Command), 复制Action);


        public IDelegateCommand 粘贴Command => this.GetCom(nameof(粘贴Command), 粘贴Action);


        public IDelegateCommand 保存Command => this.GetCom(nameof(保存Command), 保存Action);


        public IDelegateCommand 确定Command => this.GetCom(nameof(确定Command), 确定Action);


        public IDelegateCommand 取消Command => this.GetCom(nameof(取消Command), 取消Action);

        public string 验证结果
        {
            get { return GetProperty(() => 验证结果); }
            set { SetProperty(() => 验证结果, value); }
        }


        public bool Is验证中
        {
            get { return GetProperty(() => Is验证中); }
            set { SetProperty(() => Is验证中, value); }
        }

        public bool Is验证成功
        {
            get { return GetProperty(() => Is验证成功); }
            set { SetProperty(() => Is验证成功, value); }
        }


        public string 硬件码
        {
            get { return GetProperty(() => 硬件码); }
            set { SetProperty(() => 硬件码, value); }
        }

        public string 客户名称
        {
            get { return GetProperty(() => 客户名称); }
            set { SetProperty(() => 客户名称, value); }
        }

        public string 注册码
        {
            get { return GetProperty(() => 注册码); }
            set { SetProperty(() => 注册码, value); }
        }


        private void 激活视图Action(string obj)
        {
            //if (obj != StrName.View.系统注册视图)
            //    return;
            //读取注册码();
            //读取特征码();
        }


        private void 收到注册码Action(I授权配置 obj)
        {
            客户名称 = obj.客户名称;
            注册码 = obj.注册码;

            _历史客户名称 = obj.客户名称;
            _历史注册码 = obj.注册码;
        }


        public void 读取注册码()
        {
            var 配置1 = Container人事部.TryResolve2<I授权配置>(名称);
            if (配置1 != null)
            {
                收到注册码Action(配置1);
                return;
            }

            配置1 = Container人事部.TryResolve2<I授权配置>("");
            if (配置1 != null)
            {
                收到注册码Action(配置1);
            }

            //EventAggregator宣传部.GetEvent<Event读取注册码>().Publish();
        }


        private void 确定Action()
        {
            保存Action();
        }


        private void 取消Action()
        {
            客户名称 = _历史客户名称;
            注册码 = _历史注册码;
            Messenger.Default.Send(new Event视图返回() {Data = 1});
        }


        private void 保存Action()
        {
            Messenger.Default.Send(new Event保存授权配置()
            {
                Data = new 授权配置
                {
                    客户名称 = 客户名称,
                    注册码 = 注册码,
                    硬件码 = 硬件码
                }
            });
        }


        private void 读取特征码()
        {
            Task.Factory.StartNew(注册3.计算特征码)
                .ContinueWith(x => { 硬件码 = x.Result; })
                .ContinueWith(x => 验证Action());
        }


        private void 粘贴Action()
        {
            RunFunc.TryRun(() => 注册码 = Clipboard.GetText());
        }


        private void 复制Action()
        {
            RunFunc.TryRun(() => Clipboard.SetText(硬件码));
        }


        private void 验证Action()
        {
            if (Is验证中)
                return;
            Is验证中 = true;
            Task.Factory.StartNew(() => 注册3.验证注册(授权信息.公钥2018, 注册3.计算特征码(), 注册码))
                .ContinueWith(x =>
                {
                    Is验证成功 = x.Result;
                    Is验证中 = false;
                    验证结果 = Is验证成功 ? "注册通过" : "注册失败";
                    授权结果发布(Is验证成功);
                });
        }


        private void 授权结果发布(bool result)
        {
            var 消息内容 = result ? "已授权" : "未授权";
            消息.更新状态栏(消息内容, "授权");
            Log.Info($"软件:{消息内容}");
        }
    }
}