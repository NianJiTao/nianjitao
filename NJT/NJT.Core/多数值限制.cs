using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NJT.Core
{
    public class 多数值限制
    {

        [XmlAttribute]
        public string 合计公式 { get; set; } = "";
        [XmlAttribute]
        public string 组 { get; set; } = string.Empty;

        [XmlIgnore]
        public string 分隔符 { get; set; } = "+";
        [XmlIgnore]
        public string[] 名称表 { get; set; } = new string[0];


        [XmlAttribute]
        public double 最小值 { get; set; } = 0;


        [XmlAttribute]
        public double 最大值 { get; set; } = 1;


        public void NameToList()
        {
            if (名称表 == null || 名称表.Length == 0)
            {
                合计公式 = string.Empty;
            }
            else
            {
                合计公式 = string.Join(分隔符, 名称表);
            }
        }


        public void ListToName()
        {
            if (string.IsNullOrEmpty(合计公式))
            {
                名称表 = new string[0];
            }
            else
            {
                名称表 = 合计公式.Split(分隔符.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
