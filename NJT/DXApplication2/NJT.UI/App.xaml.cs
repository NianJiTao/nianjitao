using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using DevExpress.Xpf.Core;
using NJT.Core;

namespace NJT.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnAppStartup_UpdateThemeName(object sender, StartupEventArgs e)
        {
            DevExpress.Xpf.Core.ApplicationThemeHelper.UpdateApplicationThemeName();


            命令行处理(e.Args);
        }

        命令行参数 参数 = new 命令行参数();

        private void 命令行处理(string[] args)
        {
            if (args == null || args.Length <= 0)
                return;
            消息提取(args);
        }

        private void 消息提取(string[] args)
        {
            var find = 参数.提取(args, "-消息", 3);
            if (find.Length > 2)
            {
                发布消息(find[1], find[2]);
            }
            else if (find.Length > 1)
            {
                发布消息(find[1], "提示");
            }
        }

        private void 发布消息(string 内容, string 标题)
        {
            RunSet.发布通知(内容);
        }
    }
}