using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Text;
using Prism.Commands;

namespace 年纪涛.简介.ViewModels
{
    public class 技能PageViewModel : VmBase
    {
        private string _技能Document = @"
	精通C#,WPF语言,10年以上相关工作经验
	精通MVVM，MVC，面向对象等开发方式。
	熟悉LINQ，EF，SQL等。
	熟悉常见的开发框架，设计模式。
	熟悉版本控制，测试驱动，团队合作等。
	熟悉C/S,B/S架构开发，串口通讯等,有相关实施项目。
	熟练使用VS开发工具，可以完成企业级应用开发。
	热爱编程，对技术实时更新学习。
	作品有自动播音系统，矩阵控制系统，校时系统等在全国各地使用。
";


        public 技能PageViewModel()
        {
            复制Command = new DelegateCommand<string>(复制Action, x => true);
        }


        public string 技能Document
        {
            get { return _技能Document; }
            set { SetProperty(ref _技能Document, value); }
        }


        public DelegateCommand<string> 复制Command { get; set; }


        private void 复制Action(string obj)
        {
            if (string.IsNullOrEmpty(obj))
            {
                return;
            }
            var text = new DataPackage();
            text.SetText(obj);
            Clipboard.SetContent(text);
        }
    }
}