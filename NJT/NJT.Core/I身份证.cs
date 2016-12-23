using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    /// <summary>
    ///     Interface 包含有唯一Guid的接口
    /// </summary>
    public interface I身份证 : I名称
    {
        Guid 身份证 { get; set; }
    }


    public class 身份证1 : I身份证
    {
        public 身份证1()
        {
            身份证 = Guid.NewGuid();
            名称 = 身份证.ToString();
        }
        public Guid 身份证 { get; set; }
        public string 名称 { get; set; }
    }
}
