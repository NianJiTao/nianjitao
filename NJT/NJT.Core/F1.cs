using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace NJT.Core
{
    /// <summary>
    /// 帮助类
    /// </summary>
    public static class F1
    {
        public static ObservableCollection<T> Get动态集合<T>()
        {
            return new ObservableCollection<T>();
        }
        public static DispatcherTimer Get定时器()
        {
            return new DispatcherTimer();
        }
        public static void 授权复制(I授权配置 源, I授权配置 目标)
        {

            目标.客户名称 = 源.客户名称;
            目标.硬件码 = 源.硬件码;
            目标.注册码 = 源.注册码;
        }

        /// <summary>
        ///  新进程打开文件 ,调用默认关联程序
        /// </summary>
        /// <param name="fileName"></param>
        public static void 打开文件(string fileName)
        {
            if (File.Exists(fileName)) 新进程.运行(fileName);
        }
        /// <summary>
        ///新进程打开目录 ,调用默认关联程序
        /// </summary>
        /// <param name="dir"></param>
        public static void 打开目录(string dir)
        {
            if (Directory.Exists(dir)) 新进程.运行(dir);
        }

    }
}
