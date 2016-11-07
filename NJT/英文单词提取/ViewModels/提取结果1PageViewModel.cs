using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Windows.Navigation;

namespace 英文单词提取.ViewModels
{
    public class 提取结果1PageViewModel : VmBase
    {
        private string _提取结果;

        private bool? _显示频率 = false;

        private bool? _显示长度 = false;


        排序方式 排序方式1 = 排序方式.字母;


        public 提取结果1PageViewModel()
        {
            长度排序Command = new DelegateCommand<object>(长度排序Action);
            频率排序Command = new DelegateCommand<object>(频率排序Action);
            字母排序Command = new DelegateCommand<object>(字母排序Action);
        }


        public string 提取结果
        {
            get { return _提取结果; }
            set { SetProperty(ref _提取结果, value); }
        }


        public bool? 显示长度
        {
            get { return _显示长度; }
            set
            {
                SetProperty(ref _显示长度, value);
                刷新结果();
            }
        }


        public bool? 显示频率
        {
            get { return _显示频率; }
            set
            {
                SetProperty(ref _显示频率, value);
                刷新结果();
            }
        }


        public ICommand 字母排序Command { get; set; }

        public ICommand 频率排序Command { get; set; }

        public ICommand 长度排序Command { get; set; }


        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            if (e.Parameter != null && e.Parameter is List<单词>)
            {
                运行时.提取结果 = (List<单词>) e.Parameter;
            }

            if ((运行时.提取结果.Count <= 0)) return;

            字母排序Action(null);
        }


        void 刷新结果()
        {
            switch (排序方式1)
            {
                case 排序方式.字母:
                    字母排序Action(null);
                    break;
                case 排序方式.长度:
                    长度排序Action(null);
                    break;
                case 排序方式.频率:
                    频率排序Action(null);
                    break;
                default:
                    字母排序Action(null);
                    break;
            }
        }


        string 行计算(单词 x)
        {
            var name =
                x.名称 + (显示长度 == true ? $"\t{x.长度}" : string.Empty) + (显示频率 == true ? $"\t{x.频率}" : string.Empty);

            return name.Trim();
        }


        private void 字母排序Action(object obj)
        {
            排序方式1 = 排序方式.字母;
            if ((运行时.提取结果.Count <= 0)) return;
            提取结果 = string.Join("\r\n", 运行时.提取结果.OrderBy(x => x.首字母).Select(行计算));
        }


        private void 频率排序Action(object obj)
        {
            排序方式1 = 排序方式.频率;
            if ((运行时.提取结果.Count <= 0)) return;
            提取结果 = string.Join("\r\n", 运行时.提取结果.OrderByDescending(x => x.频率).Select(行计算));
        }


        private void 长度排序Action(object obj)
        {
            排序方式1 = 排序方式.长度;
            if ((运行时.提取结果.Count <= 0)) return;
            提取结果 = string.Join("\r\n", 运行时.提取结果.OrderBy(x => x.长度).Select(行计算));
        }
    }

    public enum 排序方式
    {
        字母,
        长度,
        频率
    }
}