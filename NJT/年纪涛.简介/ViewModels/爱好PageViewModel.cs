using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 年纪涛.简介.ViewModels
{
    public class 爱好PageViewModel : VmBase
    {
        private string _说明 = @"
爱好编程.读书.学习.
";

        public string 说明
        {
            get { return _说明; }
            set { SetProperty(ref _说明, value); }
        }
    }
}