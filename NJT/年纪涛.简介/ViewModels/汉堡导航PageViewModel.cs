using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Microsoft.Xaml.Interactions.Core;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace 年纪涛.简介.ViewModels
{
    public class 汉堡导航PageViewModel : VmBase
    {
        private bool _is左侧打开;

        private INavigationService NavigationService;
        public 汉堡导航PageViewModel(INavigationService NavigationService1)
        {
            NavigationService = NavigationService1;
        }
        public bool Is左侧打开
        {
            get { return _is左侧打开; }
            set {SetProperty(ref _is左侧打开, value); }
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
            var sel =  clickedItem as HamburgerMenuItem;
            if (sel?.Tag != null)
            {
                var t = sel.Tag.ToString();
                NavigationService.Navigate(t, null);
            }
        }


     
    }
}
