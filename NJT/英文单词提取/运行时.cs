using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 英文单词提取
{
    public static class 运行时
    {

        public static 用户 单用户 { get; set; } = new 用户();


        public static List<单词> 提取结果 { get; set; } = new List<单词>();


        public static string 原文 { get; set; } =
@"从文档内容里面提取英文单词,方便学习单词.请在此粘贴需要提取的文档

a friend in need is a friend indeed. 患难见真交。

a good medicine tastes bitter. 良药苦口。

a journey of a thousand miles begins with single step.千里之行，始于足下。

after a storm comes a calm. 雨过天晴。

all roads lead to rome. 条条大路通罗马。

art is long, but life is short. 人生有限，学问无涯。

better late than never.只要开始，虽晚不迟。

east, west, home is best. 金窝银窝，不如自己的草窝。 ";
         

        public static 配置 配置1 { get; set; } = new 配置();

    }
}
