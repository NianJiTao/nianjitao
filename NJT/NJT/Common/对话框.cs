using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace NJT.Common
{
    public static class 对话框
    {

        public static bool 操作确认(string 信息, string 标题)
        {
            var button = MessageBoxButton.YesNo;
            var icon = MessageBoxImage.Warning;
            var result = MessageBox.Show(信息, 标题, button, icon);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    return true;
                case MessageBoxResult.No:
                    return false;
                case MessageBoxResult.Cancel:
                    return false;
                default:
                    return false;
            }
        }

        public static void 操作提示(string 信息, string 标题)
        {
            var button = MessageBoxButton.OK;
            var icon = MessageBoxImage.Warning;
            var result = MessageBox.Show(信息, 标题, button, icon);
        }


        public static string 选择目录(string dir)
        {
            var dialogSaveFile = new FolderBrowserDialog();
            dialogSaveFile.SelectedPath = dir;
            var 保存确认 = dialogSaveFile.ShowDialog() == DialogResult.OK;
            if (!保存确认)
            {
                return string.Empty;
            }
            var 目录名 = dialogSaveFile.SelectedPath;
            return 目录名;
        }


        public static string 初始目录 = AppDomain.CurrentDomain.BaseDirectory;


        public static string 文件打开()
        {
            return 文件打开("所有文件|*.*");
        }

        public static string 文件打开(string 过滤)
        {
            var a = new OpenFileDialog();
            a.InitialDirectory = 初始目录;

            a.Filter = 过滤;
            if (a.ShowDialog() == DialogResult.OK)
            {
                return a.FileName;
            }
            return "";
        }
    }
}
