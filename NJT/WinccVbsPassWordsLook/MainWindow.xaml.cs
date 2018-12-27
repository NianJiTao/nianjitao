using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WinccVbsPassWordsLook
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("设计:年纪涛\r\nQQ:925007694\r\n可查看Wincc(7.0|7.3)Vbs脚本密码");
        }


        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            var a = new OpenFileDialog();
            a.Multiselect = false;
            a.ShowDialog();
            var f1 = a.FileName;
            if (string.IsNullOrEmpty(f1))
                return;
            解密2(f1);
        }


        private void 解密2(string filename)
        {
            if (!System.IO.File.Exists(filename))
            {
                info.Text = "文件不存在";
                return;
            }

            var ext = Properties.Settings.Default.文件格式;
            if (!filename.EndsWith(ext))
            {
                info.Text = "文件格式不对";
                return;
            }

            pass.Text = new 解密().运行(filename);
        }


        private void Window_Drop(object sender, DragEventArgs e)
        {
            string[] filePath = (string[]) e.Data.GetData(DataFormats.FileDrop);
            if (filePath == null || !filePath.Any())
                return;
            var f1 = filePath[0];
            解密2(f1);
        }


        private void Window_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Link;
            else e.Effects = DragDropEffects.None;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}