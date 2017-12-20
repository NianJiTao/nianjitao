//using NJT.Core;

//namespace NJT.Prism
//{
//    public class 状态栏Data2 : BindableBase2, I标识Data
//    {
//        private string _标签;
//        private string _数据;
//        private string _提示;
//        private bool _显示 = true;


//        public 状态栏Data2(string 数据cs, string 标识cs)
//        {
//            标识 = 标识cs;
//            数据 = 数据cs;
//        }

//        public 状态栏Data2(string 数据cs)
//        {
//            标识 = "提示";
//            数据 = 数据cs;
//        }


//        public 状态栏Data2()
//        {
//        }

//        /// <summary>
//        ///     用来区分数据大类别
//        /// </summary>
//        /// <value>The 标识.</value>
//        public string 标识 { get; set; }


//        public string 数据
//        {
//            get => _数据;
//            set => SetProperty(ref _数据, value);
//        }


//        public string 标签
//        {
//            get => _标签;
//            set => SetProperty(ref _标签, value);
//        }

//        public string 提示
//        {
//            get => _提示;
//            set => SetProperty(ref _提示, value);
//        }

//        public bool 显示
//        {
//            get => _显示;
//            set => SetProperty(ref _显示, value);
//        }
//    }
//}