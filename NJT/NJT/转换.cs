using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace NJT
{
    public class 转换
    {
       

        public static void 属性转换<T>(Func<T, T> 属性设置方法, Func<string, Tuple<bool, T>> 值转换方法, string value)
        {
            var k = 值转换方法(value);
            if (k.Item1)
            {
                属性设置方法.Invoke(k.Item2);
            }
        }


        public static Tuple<bool, TimeSpan> 时间转换(string value)
        {
            TimeSpan r;
            var k = (TimeSpan.TryParse(value, out r));
            return new Tuple<bool, TimeSpan>(k, r);
        }

        public static Tuple<bool, DateTime> 日期转换(string value)
        {
            DateTime r;
            var k = (DateTime.TryParse(value, out r));
            return new Tuple<bool, DateTime>(k, r);
        }

        public static Tuple<bool, SolidColorBrush> 颜色转换(string value)
        {
            var convertFromString = ColorConverter.ConvertFromString(value);
            var k = (convertFromString == null);
            if (k) return new Tuple<bool, SolidColorBrush>(false, null);
            var r = new SolidColorBrush((Color)convertFromString);
            return new Tuple<bool, SolidColorBrush>(true, r);
        }
        //示例
        //[XmlIgnore]
        //public SolidColorBrush 颜色 { get; set; }

        //public string 颜色s
        //{
        //    get { return 颜色.Color.ToString(); }
        //    set
        //    {
        //        属性转换(x => 颜色 = x, 颜色转换, value);
        //    }
        //}


        //示例
        //[XmlIgnore]
        //public TimeSpan 时间 { get; set; }

        //public string 时间s
        //{
        //    get { return 时间.ToString(); }
        //    set
        //    {
        //        属性转换(x => 时间 = x, 时间转换, value);
        //    }
        //}



        public static string ToHexString(byte[] bytes) // 0xae00cf => "AE00CF "
        {
            var hexString = string.Empty;
            if (bytes != null)
            {
                var strB = new StringBuilder();
                for (var i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }

        public static byte[] HexToByte(string hexString)
        {
            var returnBytes = new byte[hexString.Length / 2];
            for (var i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

    }
}
