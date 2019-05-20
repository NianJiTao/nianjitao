using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Media;
using System.Xml.Serialization;

namespace NJT.Core
{
    public class 时钟配置
    {
        [XmlAttribute]
        public bool 显示时间 { get; set; } = true;

        [XmlAttribute]
        public bool 显示日期 { get; set; } = true;

        [XmlAttribute]
        public bool 显示星期 { get; set; } = true;


        [XmlIgnore]
        public string 时间字体 { get; set; } =  "微软雅黑";

        //[XmlAttribute]
        //public string 时间字体s
        //{
        //    get { return 时间字体.Source; }
        //    set { 时间字体 = new FontFamily(value); }
        //}


        [XmlAttribute]
        public double 时间字体大小 { get; set; } = 48d;

        [XmlAttribute]
        public double 日期字体大小 { get; set; } = 20d;

        [XmlAttribute]
        public double 星期字体大小 { get; set; } = 20d;

        [XmlAttribute]
        public string 时间显示格式 { get; set; } = "HH:mm:ss";

        [XmlAttribute]
        public string 日期显示格式 { get; set; } = "yyyy年MM月dd日";

        [XmlAttribute]
        public string 星期显示格式 { get; set; } = "dddd";


        [XmlIgnore]
        public string 时间颜色 { get; set; } = "DarkGreen";

        [XmlIgnore]
        public string 日期颜色 { get; set; } = "DarkGreen";

        [XmlIgnore]
        public string 星期颜色 { get; set; } = "DarkGreen";

        [XmlIgnore]
        public string 背景颜色 { get; set; } = "LightSteelBlue";



        //[XmlAttribute]
        //public string 背景颜色s
        //{
        //    get { return 背景颜色.Color.ToString(); }
        //    set
        //    {

        //        属性值转换.属性转换(x => 背景颜色 = x, 属性值转换.颜色转换, value);
        //    }
        //}


        //[XmlAttribute]
        //public string 星期颜色s
        //{
        //    get { return 星期颜色.Color.ToString(); }
        //    set { 属性值转换.属性转换(x => 星期颜色 = x, 属性值转换.颜色转换, value); }
        //}

        //[XmlAttribute]
        //public string 时间颜色s
        //{
        //    get { return 时间颜色.Color.ToString(); }
        //    set { 属性值转换.属性转换(x => 时间颜色 = x, 属性值转换.颜色转换, value); }
        //}

        //[XmlAttribute]
        //public string 日期颜色s
        //{
        //    get { return 日期颜色.Color.ToString(); }
        //    set { 属性值转换.属性转换(x => 日期颜色 = x, 属性值转换.颜色转换, value); }
        //}
    }
}
