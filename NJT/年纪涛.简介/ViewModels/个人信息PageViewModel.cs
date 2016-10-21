using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Windows.Mvvm;
using 年纪涛.简介.Models;

namespace 年纪涛.简介.ViewModels
{
    public class 个人信息PageViewModel : VmBase
    {

        private 基本信息 _信息 = new 基本信息();
        public 基本信息 信息
        {
            get { return _信息; }
            set { SetProperty(ref _信息, value); }
        }


        public 个人信息PageViewModel()
        {
            _说明 += string.Format("更新于:2016年10月21日");
        }

        private string _说明 = @"
姓名:年纪涛 男 34岁 大专学历 待业中.
想找一份软件开发相关工作.
工作地址在南京.雨花台区,建邺区,优先.
期望月薪10k+.
熟悉.net平台.相关技术开发类都可以考虑.
另外精通音频设备,熟悉各种调音台,广电设备.有相关工作也会考虑.


爱好编程.读书.学习.
喜欢科技,智能等能提高效率的设备.
不抽烟,偶尔喝酒,很少玩游戏,喜欢安静.




";
        public string 说明
        {
            get { return _说明; }
            set { SetProperty(ref _说明, value); }
        }
    }
}
