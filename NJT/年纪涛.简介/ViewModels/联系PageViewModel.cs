using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 年纪涛.简介.Models;

namespace 年纪涛.简介.ViewModels
{
    public class 联系PageViewModel : VmBase
    {

        public 联系PageViewModel()
        {
            _联系方式列表 = new 联系方式();
        }

        private 联系方式 _联系方式列表;
        public 联系方式 联系方式列表
        {
            get { return _联系方式列表; }
            set { SetProperty(ref _联系方式列表, value); }
        }
    }
}
