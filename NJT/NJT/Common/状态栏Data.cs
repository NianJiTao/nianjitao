using Microsoft.Practices.Prism.Mvvm;
using NJT.接口;

namespace NJT.Common
{
    public class 状态栏Data1 : BindableBase, I状态栏Data
    {
        private dynamic _数据;

        public 状态栏Data1(string 标识cs, dynamic 数据cs)

        {
            标识 = 标识cs;

            数据 = 数据cs;
        }

        public 状态栏Data1()
        {
        }

        public string 标识 { get; set; }

        public dynamic 数据
        {
            get { return _数据; }
            set { SetProperty(ref _数据, value); }
        }
    }



    
}