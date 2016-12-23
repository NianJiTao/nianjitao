using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Common
{
    public class 新进程
    {
        public static void 运行(string 命令)
        {
            try
            {
                运行2(命令);
            }
            catch (Exception)
            {
            }
        }

        private static void 运行2(string 命令)
        {
            var s = 命令;
            string 程序;
            var 参数 = string.Empty;
            if (string.IsNullOrEmpty(s))
            {
                return;
            }
            var a = s.IndexOf(" ", System.StringComparison.Ordinal);
            if (a < 0)
            {
                程序 = s;
            }
            else
            {
                程序 = s.Substring(0, a);
                参数 = s.Remove(0, a);
            }

            var 进程1 = new Process { StartInfo = { FileName = 程序, Arguments = 参数 } };
            进程1.Start();
        }

        public static void cmd(string dos命令)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            process.Start();
            process.StandardInput.WriteLine(dos命令);
        }
    }
}
