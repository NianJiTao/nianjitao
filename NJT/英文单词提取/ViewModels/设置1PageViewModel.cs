namespace 英文单词提取.ViewModels
{
    public class 设置1PageViewModel : VmBase
    {

        private bool? _排除熟词本 = true;

        public bool? 排除熟词本
        {
            get { return _排除熟词本; }
            set
            {
                SetProperty(ref _排除熟词本, value);
            }
        }



        private bool? _区分大小写=true ;

        public bool? 区分大小写
        {
            get { return _区分大小写; }
            set
            {
                SetProperty(ref _区分大小写, value);
            }
        }

        private bool? _长单词分离 =false;

        public bool? 长单词分离
        {
            get { return _长单词分离; }
            set
            {
                SetProperty(ref _长单词分离, value);
            }
        }


        private int _单词最小长度=2;

        public int 单词最小长度
        {
            get { return _单词最小长度; }
            set
            {
                var m = 2;
                var cov = int.TryParse(value.ToString(), out m);
                if (!cov)
                {
                    m = 2;
                }
                SetProperty(ref _单词最小长度, m);

            }
        }



    }
}
