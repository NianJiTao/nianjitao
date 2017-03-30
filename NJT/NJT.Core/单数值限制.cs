using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NJT.Core
{
    public class 单数值限制
    {
        public 单数值限制()
        {

        }

        public 单数值限制(string 名称1, double 最大值1)
        {
            名称 = 名称1;
            最大值 = 最大值1;
        }
        [XmlAttribute]
        public string 组 { get; set; } = string.Empty;
        [XmlAttribute]
        public string 名称 { get; set; } = "值名称";
        [XmlAttribute]
        public double 最小值 { get; set; } = 0;

        [XmlAttribute]
        public double 最大值 { get; set; } = 1;
    }


}
