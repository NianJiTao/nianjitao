using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NJT.Core
{
    //public class 单数值限制
    //{
    //    public 单数值限制()
    //    {

    //    }

    //    public 单数值限制(string 名称1, double 最大值1)
    //    {
    //        名称 = 名称1;
    //        最大值 = 最大值1;
    //    }
    //    [XmlAttribute]
    //    public string 组 { get; set; } = string.Empty;
    //    [XmlAttribute]
    //    public string 名称 { get; set; } = "值名称";
    //    [XmlAttribute]
    //    public double 最小值 { get; set; } = 0;

    //    [XmlAttribute]
    //    public double 最大值 { get; set; } = 1;
    //}
    public interface I数值限制
    {
        string 组 { get; set; }

        string 名称 { get; set; }

        double 最小值 { get; set; }

        double 最大值 { get; set; }
    }

    public class 数值限制 : I数值限制
    {
        public 数值限制()
        {
        }


        public 数值限制(string 名称1, double 最大值1, double 最小值1 = 0)
        {
            this.名称 = 名称1;
            this.最大值 = 最大值1;
            this.最小值 = 最小值1;
        }
        /// <summary>
        /// 合金工艺名称
        /// </summary>
        [XmlAttribute]
        public string 组 { get; set; } = string.Empty;

        [XmlAttribute]
        public string 名称 { get; set; } = string.Empty;

        [XmlAttribute]
        public double 最小值 { get; set; }

        [XmlAttribute]
        public double 最大值 { get; set; } = 1.0;


        //    public void 名称表to名称()
        //    {
        //        if (this.名称表 == null || this.名称表.Length == 0)
        //            this.名称 = string.Empty;
        //        else
        //            this.名称 = string.Join(this.分隔符, this.名称表);
        //    }

        //    public void 名称to名称表()
        //    {
        //        if (string.IsNullOrEmpty(this.名称))
        //            this.名称表 = new string[0];
        //        else
        //            this.名称表 = this.名称.Split(this.分隔符.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //    }
    }

    public class 数值限制1 : I数值限制
    {
        public string 组 { get; set; }
        public string 名称 { get; set; }
        public double 最小值 { get; set; }
        public double 最大值 { get; set; }

    }
}
