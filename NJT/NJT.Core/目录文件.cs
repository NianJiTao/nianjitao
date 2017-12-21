using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public class 目录文件
    {
        public static void 打开文件(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return;
            if (File.Exists(fileName)) 新进程.运行(fileName);
        }


        public static void 打开目录(string dir)
        {
            if (string.IsNullOrEmpty(dir))
                return;
            if (Directory.Exists(dir)) 新进程.运行(dir);
        }


        /// <summary>
        /// 所有子目录s the specified 根目录.
        /// 0层为搜索本目录下面的.
        /// -1 为只有本根目录.
        /// </summary>
        /// <param name="根目录">The 根目录.</param>
        /// <param name="搜索层">The 搜索层.</param>
        /// <returns>List{System.String}.</returns>
        public static List<string> 所有目录(string 根目录, int 搜索层)
        {
            var r = new List<string>() {根目录};
            if (string.IsNullOrEmpty(根目录) || Directory.Exists(根目录) == false)
            {
                return r;
            }

            if (搜索层 < 0)
                return r;
            try
            {
                var 子目录 = Directory.GetDirectories(根目录);
                r.AddRange(子目录);
                foreach (var item in 子目录)
                {
                    r.AddRange(所有目录(item, 搜索层 - 1));
                }
            }
            catch
            {
                // ignored
            }

            return r;
        }


        /// <summary>
        /// 所有文件s the specified 目录列表.
        /// 根据扩展名过滤文件. 如 .mp3 ; 
        /// </summary>
        /// <param name="目录列表">The 目录列表.</param>
        /// <param name="扩展名cs">The 扩展名CS.</param>
        /// <returns>List{System.String}.</returns>
        public static List<string> 所有文件(IEnumerable<string> 目录列表, IList<string> 扩展名cs)
        {
            var result = new List<string>();
            foreach (var item in 目录列表)
            {
                if (!Directory.Exists(item)) continue;
                var d = new DirectoryInfo(item);

                if ((d.Parent != null) && ((d.Attributes & FileAttributes.Hidden) != 0 ||
                                           (d.Attributes & FileAttributes.System) != 0))
                {
                    continue;
                }

                string[] 文件列表;
                try
                {
                    文件列表 = Directory.GetFiles(item);
                }
                catch (Exception)
                {
                    文件列表 = new string[] { };
                }

                if (!文件列表.Any())
                {
                    continue;
                }

                if (!扩展名cs.Any())
                {
                    result.AddRange(文件列表);
                    continue;
                }

                var f = from cs in 文件列表
                    from cs1 in 扩展名cs
                    where cs.EndsWith(cs1, StringComparison.CurrentCultureIgnoreCase)
                    select cs;
                result.AddRange(f);
            }

            return result;
        }
    }
}