using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Data.Text;
using Prism.Commands;
using Prism.Events;
using Prism.Windows.Navigation;
using 英文单词提取.Models;
using 英文单词提取.Views;

namespace 英文单词提取.ViewModels
{
    public class 主页1PageViewModel : VmBase
    {
        private readonly INavigationService _navigationService;


        private bool? _排除熟词本 = true;
        private string _原文;
        //private readonly IEventAggregator _eventAggregator;


        public 主页1PageViewModel(INavigationService navigationService1)
        {
            _navigationService = navigationService1;
            提取Command = new DelegateCommand<object>(提取Action);
        }


        public bool? 排除熟词本
        {
            get { return _排除熟词本; }
            set { SetProperty(ref _排除熟词本, value); }
        }


        public string 原文
        {
            get { return _原文; }
            set { SetProperty(ref _原文, value); }
        }


        public ICommand 提取Command { get; set; }


        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            if (e.Parameter != null)
            {
                运行时.原文 = e.Parameter.ToString();
            }

            if (!string.IsNullOrEmpty(运行时.原文))
            {
                原文 = 运行时.原文;
            }
        }


        private void 提取Action(object obj)
        {
            运行时.原文 = 原文;
            var ss = 运行时.单用户.熟词本;

            var find = Find.分析单词(原文);

            var find3 = from x in find
                where !ss.Contains(x.名称)
                select x;

            运行时.提取结果 = 排除熟词本 == true
                ? find3.ToList()
                : find.ToList();

            _navigationService.Navigate((typeof(提取结果1Page).NameNavigation()), null);
        }
    }
}