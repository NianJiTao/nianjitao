using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Windows.Media;

namespace NJT.Core
{
    public class 属性值转换
    {
        public static void 属性转换<T>(Func<T, T> 属性设置方法, Func<string, I运行结果<T>> 值转换方法, string value)
        {
            var k = 值转换方法(value);
            if (k.IsTrue)
            {
                属性设置方法.Invoke(k.Data);
            }
        }


        public static I运行结果<TimeSpan> 时间转换(string value)
        {
            var k = (TimeSpan.TryParse(value, out var r));
            return new 运行结果<TimeSpan>(k) {Data = r};
        }


        public static I运行结果<DateTime> 日期转换(string value)
        {
            var k = (DateTime.TryParse(value, out var r));
            return new 运行结果<DateTime>(k) {Data = r};
        }


        //public static I运行结果<SolidColorBrush>   颜色转换(string value)
        //{
        //    object convertFromString=null;
        //    try
        //    {
        //          convertFromString = ColorConverter.ConvertFromString(value);
        //    }
        //    catch (Exception e)
        //    {
        //    return new 运行结果<SolidColorBrush>(false,e.Message) {Data = Brushes.Black };  
        //    }

        //    if (convertFromString == null)  return new 运行结果<SolidColorBrush>(false) { Data = Brushes.Black };
        //    var r = new SolidColorBrush((Color)convertFromString);
        //    return  new 运行结果<SolidColorBrush>(true) { Data =r };     
        //}

        //示例
        //[XmlIgnore]
        //public SolidColorBrush 颜色 { get; set; }

        //public string 颜色s
        //{
        //    get { return 颜色.Color.ToString(); }
        //    set
        //    {
        //        转换.属性转换(x => 颜色 = x, 转换.颜色转换, value);
        //    }
        //}


        //示例
        //[XmlIgnore]
        //public TimeSpan 时间 { get; set; }

        //public string 时间str
        //{
        //    get { return 时间.ToString(); }
        //    set
        //    {
        //        转换.属性转换(x => 时间 = x, 转换.时间转换, value);
        //    }
        //}


        //示例
        //[XmlIgnore]
        //public TimeSpan 时间 { get; set; }

        //public string 时间str
        //{
        //    get { return 日期.ToString("s"); }
        //    set
        //    {
        //        转换.属性转换(x => 时间 = x, 转换.时间转换, value);
        //    }
        //}
    }
}