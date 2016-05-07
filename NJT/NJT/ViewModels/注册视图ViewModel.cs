using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using NJT.Common;
using NJT.Events;
using NJT.Model;
using NJT.接口;
using Prism.Commands;

namespace NJT.ViewModels
{
    public class 注册视图ViewModel : Vm基类<授权配置>, I授权配置ViewModel
    {
        private bool _is验证成功;
        private bool _is验证中;
        private string _验证结果;
        private string _硬件码;

        public 注册视图ViewModel()
        {
            Model = new 授权配置();

            验证Command = new DelegateCommand<object>(验证Action, can => true);
            复制Command = new DelegateCommand<object>(复制Action, can => true);
            粘贴Command = new DelegateCommand<object>(粘贴Action, can => true);
            保存Command = new DelegateCommand<object>(保存Action, can => true);
            确定Command = new DelegateCommand<object>(确定Action, can => true);

            取消Command = new DelegateCommand<object>(取消Action, can => true);

            新闻部.GetEvent<更新公钥Event>().Subscribe(更新公钥Action, true);

            读取特征码();
        }


        public ICommand 确定Command { get; set; }
        public ICommand 取消Command { get; set; }

        public string 验证结果
        {
            get { return _验证结果; }
            set { SetProperty(ref _验证结果, value); }
        }

        public ICommand 验证Command { get; set; }
        public ICommand 复制Command { get; set; }
        public ICommand 粘贴Command { get; set; }
        public ICommand 保存Command { get; set; }

        public bool Is验证中
        {
            get { return _is验证中; }
            private set { SetProperty(ref _is验证中, value); }
        }

        public bool Is验证成功
        {
            get { return _is验证成功; }
            private set { SetProperty(ref _is验证成功, value); }
        }

        public string 硬件码
        {
            get { return _硬件码; }
            set { SetProperty(ref _硬件码, value); }
        }

        public string 公钥 { get; set; }

        public string 客户名称
        {
            get { return Model.客户名称; }
            set
            {
                if (value == Model.客户名称) return;
                Model.客户名称 = value;
                OnPropertyChanged(nameof(客户名称));
            }
        }


        public string 注册码
        {
            get { return Model.注册码; }
            set
            {
                if (value == Model.注册码) return;
                Model.注册码 = value;
                OnPropertyChanged(nameof(注册码));
            }
        }


        private void 更新公钥Action(string obj)
        {
            公钥 = obj;
        }

        private void 确定Action(object obj)
        {
            新闻部.GetEvent<保存授权配置Event>().Publish(Model);
        }

        private void 取消Action(object obj)
        {
            新闻部.GetEvent<取消授权Event>().Publish(Model);
        }

        private void 保存Action(object obj)
        {
            新闻部.GetEvent<保存授权配置Event>().Publish(Model);
        }

        private void 读取特征码()
        {
            Task.Factory.StartNew(注册.计算特征码)
                .ContinueWith(x => { 硬件码 = x.Result; })
                .ContinueWith(验证Action);
        }

        private void 粘贴Action(object obj)
        {
            注册码 = Clipboard.GetText();
        }

        private void 复制Action(object obj)
        {
            Clipboard.SetText(_硬件码);
        }

        private void 验证Action(object obj)
        {
            if (Is验证中)
            {
                return;
            }
            Is验证中 = true;
            Task.Factory.StartNew(() => 注册.验证注册(公钥, 注册.计算特征码(), 注册码))
                .ContinueWith(x =>
                {
                    Is验证成功 = x.Result;
                    Is验证中 = false;
                    验证结果 = Is验证成功 ? "注册通过" : "注册失败";
                    小冰.弹出消息(验证结果);
                });
        }
    }
}