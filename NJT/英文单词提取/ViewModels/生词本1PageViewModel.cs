using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 英文单词提取.ViewModels
{
    public class 生词本1PageViewModel: VmBase

    {

        private string _生词本;


        public string 生词本
        {
            get { return _生词本; }
            set
            {
                _生词本 = value;
                OnPropertyChanged(nameof(生词本));
            }
        }
    }
}
