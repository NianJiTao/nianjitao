using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NJT.Core
{
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

        [XmlAttribute] public string 名称 { get; set; } = string.Empty;

        [XmlAttribute] public double 最小值 { get; set; }

        [XmlAttribute] public double 最大值 { get; set; } = 1.0;
    }
}