using System;
using DevExpress.Mvvm.Native;
using NJT.Core;
using NJT.Prism;

namespace NJT.UI.ViewModels
{
    public class View时钟1ViewModel : ViewModelBase3
    {
        public View时钟1ViewModel()
        {
            if (IsInDesignMode)
                return;
            Model = new 时钟配置();
            EventAggregator宣传部.GetEvent<Event更新时钟配置>().Subscribe(更新时钟配置Action, true);
            启动();
        }


        public 时钟配置 Model
        {
            get { return GetProperty(() => Model); }
            set { SetProperty(() => Model, value); }
        }

        public IDelegateCommand 双击Command => this.GetCom(nameof(双击Command), 双击Action);

        public string 当前时间
        {
            get { return GetProperty(() => 当前时间); }
            set { SetProperty(() => 当前时间, value); }
        }

        public string 当前日期
        {
            get { return GetProperty(() => 当前日期); }
            set { SetProperty(() => 当前日期, value); }
        }

        public string 当前星期
        {
            get { return GetProperty(() => 当前星期); }
            set { SetProperty(() => 当前星期, value); }
        }

        public bool Is启动 { get; private set; }


        private void 更新时钟配置Action(时钟配置 obj)
        {
            Model = obj;
        }


        public void 启动()
        {
            if (Is启动)
                return;
            Is启动 = true;
            定时器.循环运行(1000, 时间更新);
        }


        private void 时间更新()
        {
            if (Model.显示时间)
                当前时间 = DateTime.Now.ToString(Model.时间显示格式);
            if (Model.显示日期)
                当前日期 = DateTime.Now.ToString(Model.日期显示格式);
            if (Model.显示星期)
                当前星期 = DateTime.Now.ToString(Model.星期显示格式);
        }


        private void 双击Action(object obj)
        {
            EventAggregator宣传部.GetEvent<Event双击时钟>().Publish(obj);
        }
    }
}