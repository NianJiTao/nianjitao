using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Text;

namespace 英文单词提取.Models
{
    public class Find
    {
        private static List<单词> 分析单词2(string text, string 正则式)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new List<单词>();
            }
            var find = 正则式;
            var reg = new Regex(find, RegexOptions.IgnoreCase);

            var list = new List<string>();
            var f2 = reg.Matches(text);
            foreach (Match match in f2)
            {
                list.Add(match.Value);
            }


            var sel = list.GroupBy(x => x)
                .Select(x => new 单词() { 名称 = x.Key, 首字母 = x.Key[0], 频率 = x.Count() })
                .OrderBy(x => x.首字母)
                .ToList();

            return sel;
        }


        public static List<单词> 分析单词(string text, string 正则式)
        {

            try
            {
                var r = 分析单词2(text, 正则式);
                return r;
            }
            catch (Exception)
            {
                return new List<单词>() { new 单词() { 名称 = "分析错误,请检查公式.", 首字母 = 'x', 频率 = 1 } };
            }
        }
        public static List<单词> 分析单词(string text)
        {
            var res = 分析单词(text, "[a-zA-Z]{2,}");
            return res;

        }


    }
}
