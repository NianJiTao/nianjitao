using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using DevExpress.Mvvm;
using NJT.Tree;
using NJT.Tree.Wpf;

namespace NJT.Demo.ViewModels
{
    public class 目录树1ViewModel : ViewModelBase
    {
        private 文件夹 _根目录;


        public 文件夹 根目录
        {
            get
            {
                if (_根目录 == null)
                {
                    _根目录 = new 文件夹() { 名称 = "我的电脑" };
                    var f = 读取磁盘组();
                    foreach (var k in f)
                    {
                        k.刷新();

                        _根目录.子.Add(k);
                    }
                }

                return _根目录;
            }
            set { _根目录 = value; }
        }


     

        public static IList<文件夹> 读取磁盘组()
        {
            var 磁盘组 = Directory.GetLogicalDrives();
            var find = from item in 磁盘组
                       let d = new DriveInfo(item)
                       where d.IsReady
                       select
                       new 文件夹
                       {
                           深度 = 1,
                           数据 = item,
                           名称 = d.Name,
                       };

            return find.ToList();
        }
    }
}