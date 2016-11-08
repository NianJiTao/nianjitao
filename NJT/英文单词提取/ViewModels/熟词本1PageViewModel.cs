using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Windows.Navigation;
using 英文单词提取.Models;

namespace 英文单词提取.ViewModels
{
    public class 熟词本1PageViewModel : VmBase
    {
        private string _熟词本=string.Empty;


        public 熟词本1PageViewModel()
        {
            刷新Command = new DelegateCommand<object>(刷新Action);
        }


        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            if (运行时.单用户.熟词本.Count > 0)
            {
                熟词本 = string.Join("\r\n", 运行时.单用户.熟词本);
            }
        }
        private void 刷新Action(object obj)
        {

            var find = Find.分析单词(熟词本,运行时.公式);

            运行时.单用户.熟词本.Clear();
            foreach (var item in find)
            {
                运行时.单用户.熟词本.Add(item.名称);
            }

            熟词本 = string.Join("\r\n", find.Select(x => x.名称));
        }


        public string 熟词本
        {
            get { return _熟词本; }
            set
            {
                _熟词本 = value;
                OnPropertyChanged(nameof(熟词本));
            }
        }


        public ICommand 刷新Command { get; set; }
    }
}
