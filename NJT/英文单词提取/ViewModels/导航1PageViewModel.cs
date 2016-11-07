using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Prism.Windows.Navigation;

namespace 英文单词提取.ViewModels
{
    public class 导航1PageViewModel: VmBase
    {


        private bool _is左侧打开=true;

        private readonly INavigationService _navigationService;
        public 导航1PageViewModel(INavigationService navigationService1)
        {
            _navigationService = navigationService1;
        }
        public bool Is左侧打开
        {
            get { return _is左侧打开; }
            set { SetProperty(ref _is左侧打开, value); }
        }


        public void HamburgerMenu_OnItemClick(object sender, ItemClickEventArgs e)
        {
            导航到页(e.ClickedItem);
        }

        public void HamburgerMenu_OnOptionsItemClick(object sender, ItemClickEventArgs e)
        {
            导航到页(e.ClickedItem);
        }
        private void 导航到页(object clickedItem)
        {
            var sel = clickedItem as HamburgerMenuItem;
        
            if (sel?.TargetPageType != null)
            {
                var name = sel.TargetPageType.NameNavigation();
                _navigationService.Navigate(name, null);
            }
        }


    }
}
