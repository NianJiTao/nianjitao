using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Common
{
    public class 目录
    {
        public static IList<FileInfo> 文件信息列表(string 目录cs, IList<string> 扩展名cs)
        {
            var 所有子目录3 = new List<string>() { 目录cs };

            var r = 所有文件(所有子目录3, 扩展名cs);
            return r.Select(x => new FileInfo(x)).ToList();
        }

        public static string 当前目录
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }



        private static string[] _扩展名 = new string[] { "mp3", "wma", "wav" };

        //可写入新的扩展名
        public static string[] 扩展名
        {
            get { return _扩展名; }
            set { _扩展名 = value; }
        }

        public static string 点播歌曲扩展名
        {
            get
            {
                var a = "";
                var b = "";
                foreach (var item in _扩展名)
                {
                    a += "," + item;
                    b += ";*." + item;
                }
                a = a.Remove(0, 1);
                b = b.Remove(0, 1);
                return string.Format("常用格式({0})|{1}|所有文件 (*.*)|*.*", a, b);
            }
        }

        public static string[] 查找扩展名()
        {
            var r = new string[扩展名.Length];
            for (var i = 0; i < 扩展名.Length; i++)
            {
                r[i] = "*." + 扩展名[i];
            }
            return r;
        }


        public static string 目录合并(string 目录1, string 目录2)
        {
            return Path.Combine(目录1, 目录2);
        }



        public static bool 目录检查并建立(string dir)
        {
            if (string.IsNullOrEmpty(dir)) return false;
            if (Directory.Exists(dir)) return true;
            try
            {
                Directory.CreateDirectory(dir);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool 文件目录检查(string file1)
        {
            var dir = Path.GetDirectoryName(file1);
            return 目录检查并建立(dir);
        }

        public static bool 删除目录(string 目录1)
        {
            try
            {
                Directory.Delete(目录1, true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void 删除文件(List<string> 文件列表)
        {
            文件列表.ForEach(删除文件);
        }
        public static void 删除文件(string 文件名)
        {
            File.Delete(文件名);
        }


        public static string 主转备(string 文件地址, string 源域名, string 目标域名)
        {
            var r = 文件地址;
            if (文件地址.StartsWith(源域名, StringComparison.CurrentCultureIgnoreCase))
            {
                r = 目标域名 + 文件地址.Remove(0, 源域名.Length);
            }
            return r;
        }

        public static string 网络转本地(string 文件地址, string 主域名, string 备域名, string 本地目录)
        {
            var r = 文件地址;
            if (string.IsNullOrEmpty(文件地址) || string.IsNullOrEmpty(主域名) || string.IsNullOrEmpty(备域名))
                return r;
            var 有效目录 = (文件地址.StartsWith(备域名, StringComparison.CurrentCultureIgnoreCase))
                ? 备域名
                : 主域名;
            r = 主转备(文件地址, 有效目录, 本地目录);
            return r;
        }



        /// <summary>
        /// 所有子目录包含自己.
        /// </summary>
        /// <param name="result">子目录.</param>
        /// <param name="s">本目录.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public static List<string> 所有子目录(List<string> result, string s, int 深度)
        {
            if (Directory.Exists(s))
            {
                result.Add(s);
                if (深度 > 0)
                {
                    try
                    {
                        var 下层深度 = 深度 - 1;
                        var 目录 = Directory.GetDirectories(s);
                        foreach (var item in 目录)
                        {
                            result = 所有子目录(result, item, 下层深度);
                        }
                    }
                    catch
                    {
                    }
                }

            }
            return result;
        }

        public static List<string> 所有子目录(List<string> result, List<string> s)
        {
            foreach (var item in s)
            {
                result = 所有子目录(result, item, 10);
            }
            return result;
        }


        /// <summary>
        /// 所有子目录s the specified 根目录.
        /// 0层为搜索本目录下面的.
        /// -1 为只有本根目录.
        /// </summary>
        /// <param name="根目录">The 根目录.</param>
        /// <param name="搜索层">The 搜索层.</param>
        /// <returns>List{System.String}.</returns>
        public static List<string> 所有子目录(string 根目录, int 搜索层)
        {
            var r = new List<string>();
            if (Directory.Exists(根目录))
            {
                if (搜索层 < 0) return r;
                try
                {
                    var 子目录 = Directory.GetDirectories(根目录);
                    r.AddRange(子目录);
                    foreach (var item in 子目录)
                    {
                        r.AddRange(所有子目录(item, 搜索层 - 1));
                    }
                }
                catch
                {
                }
            }
            return r;
        }

        public static List<string> 所有子目录含自己(string 根目录, int 搜索层)
        {
            if (根目录 == null || string.IsNullOrEmpty(根目录) || !System.IO.Directory.Exists(根目录))
            {
                return new List<string>();
            }
            var 所有子目录3 = new List<string>() { 根目录 };
            所有子目录3.AddRange(所有子目录(根目录, 搜索层));
            return 所有子目录3;
        }


        /// <summary>
        /// 所有文件s the specified 目录列表.
        /// 根据扩展名过滤文件. 如 .mp3 ; 
        /// </summary>
        /// <param name="目录列表">The 目录列表.</param>
        /// <param name="扩展名cs">The 扩展名CS.</param>
        /// <returns>List{System.String}.</returns>
        public static List<string> 所有文件(IEnumerable<string> 目录列表, IEnumerable<string> 扩展名cs)
        {
            var result = new List<string>();
            foreach (var item in 目录列表)
            {
                if (!Directory.Exists(item)) continue;
                var d = new DirectoryInfo(item);

                if ((d.Parent != null) && ((d.Attributes & FileAttributes.Hidden) != 0 || (d.Attributes & FileAttributes.System) != 0))
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
