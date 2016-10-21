using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Prism.Commands;
using Prism.Windows.Mvvm;

namespace 年纪涛.简介.ViewModels
{
    public class 测试PageViewModel : VmBase
    {
        private string fieldName = "年纪涛";
        public string 姓名
        {
            get { return fieldName; }
            set { SetProperty(ref fieldName, value); }
        }


        public 测试PageViewModel()
        {
            菜单Command = new DelegateCommand<object>(菜单Action);

        }


        public ObservableCollection<string> 变化带通知数组 { get; set; }

        private void 菜单Action(object obj)
        {
            var k = obj as SplitView;

            if (k != null)
                k.IsPaneOpen = !k.IsPaneOpen;
        }

        public ICommand 干活Command { get; set; }

        public DelegateCommand<object> 菜单Command { get; set; }
    }
}
