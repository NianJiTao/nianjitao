﻿using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace NJT.UI
{
    public class 启动管理
    {
        private const int WS_SHOWNORMAL = 1;
        //private static Mutex mutex; //建立字段.程序不退出,字段不回收.


        //public static bool 多启动限制(string 唯一字符串)
        //{
        //    bool createdNew;
        //    mutex = new Mutex(true, 唯一字符串, out createdNew);
        //    if (!createdNew)
        //    {
        //        var d = new DX弹出消息1();

        //        var 消息 = new 弹出消息1
        //        {
        //            显示文字 = "不可以启动多个",
        //            显示毫秒 = 3000
        //        };
        //        d.Set消息(消息);
        //        d.Closed += (s, e) => { Environment.Exit(0); };
        //        d.置顶启动();

        //        return true;
        //    }

        //    return false;
        //}


        public static Process 查找运行进程()
        {
            var current = Process.GetCurrentProcess();
            var processes = Process.GetProcessesByName(current.ProcessName);
            foreach (var process in processes)
                if (process.Id != current.Id)
                {
                    var a = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                    var b = Path.GetDirectoryName(current.MainModule.FileName);
                    if (a == b) return process;
                }

            return null;
        }


        public static void 激活并置顶进程(Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, WS_SHOWNORMAL);
            SetForegroundWindow(instance.MainWindowHandle);
        }


        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);


        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}