using DevExpress.Mvvm.Native;
using NJT.Prism;

namespace NJT.UI.ViewModels
{
    public class 关于1ViewModel : ViewModelBase3
    {
        public 关于1ViewModel()
        {
            版权所有 = "年纪涛";
            程序名 = "通用程序2018";
            技术支持 = @"年纪涛 13913140677 NianJiTao@OutLook.com";
        }


        public IDelegateCommand 双击Command => this.GetCom(nameof(双击Command), 双击Action);

        public string 技术支持
        {
            get { return GetProperty(() => 技术支持); }
            set { SetProperty(() => 技术支持, value); }
        }


        public string 版权所有
        {
            get { return GetProperty(() => 版权所有); }
            set { SetProperty(() => 版权所有, value); }
        }

        public string 程序名
        {
            get { return GetProperty(() => 程序名); }
            set { SetProperty(() => 程序名, value); }
        }


        private void 双击Action(object obj)
        {
            EventAggregator宣传部.GetEvent<Event双击关于>().Publish(obj);
        }
    }
}