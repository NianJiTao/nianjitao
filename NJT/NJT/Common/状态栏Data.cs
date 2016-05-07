using Microsoft.Practices.Prism.Mvvm;
using NJT.接口;

namespace NJT.Common
{
    public class 状态栏Data1 : BindableBase, I状态栏Data<Enum状态栏>
    {
        private dynamic _数据;

        public 状态栏Data1(Enum状态栏 标识cs, dynamic 数据cs)

        {
            标识 = 标识cs;

            数据 = 数据cs;
        }

        public 状态栏Data1()
        {
        }

        public Enum状态栏 标识 { get; set; }

        public dynamic 数据
        {
            get { return _数据; }
            set { SetProperty(ref _数据, value); }
        }
    }



    public enum Enum状态栏
    {
        提示,
        网络,
        数据库,
        授权,
        录音状态
    }
}