using System.Windows;
using DevExpress.Xpf.Core;
using Microsoft.Win32;
using NJT.Core;
using NJT.Prism;

namespace NJT.UI
{
    public class 对话框
    {
        public static 运行结果<string> 选择文件(string 扩展名 = "Excel 文档(*.xlsx)|*.xlsx")
        {
            //扩展名 = "全部(*.*)|*.*";
            //扩展名 = "Excel 文档(*.xlsx)|*.xlsx"
            var r = new 运行结果<string>(false);

            var dialog = new OpenFileDialog {Filter = 扩展名};
            var result = dialog.ShowDialog();
            if (result == null || result.Value == false)
                return r;

            var filename = dialog.FileName;
            if (string.IsNullOrEmpty(filename)) return r;
            r.IsTrue = true;
            r.Data = filename;
            return r;
        }


        /// <summary>
        ///     返回文件名全路径
        /// </summary>
        /// <param name="初始目录"></param>
        /// <param name="扩展名"></param>
        /// <returns></returns>
        public static 运行结果<string> 保存文件(string 初始目录 = "", string 扩展名 = "全部(*.*)|*.*")
        {
            var r = new 运行结果<string>(false);
            var dialog = new SaveFileDialog
            {
                Filter = 扩展名
            };
            if (string.IsNullOrEmpty(初始目录) == false) dialog.InitialDirectory = 初始目录;
            var result = dialog.ShowDialog();
            if (result == null || result.Value == false)
                return r;

            var filename = dialog.FileName;
            if (string.IsNullOrEmpty(filename))
                return r;
            r.IsTrue = true;
            r.Data = filename;
            return r;
        }


        public static MessageBoxResult ShowYesNo(string 消息, string 标题)
        {
            var show = DXMessageBox.Show(UiHelper.Win, 消息, 标题, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return show;
        }
    }
}