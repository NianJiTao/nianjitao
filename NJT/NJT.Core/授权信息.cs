using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public static class 授权信息
    {

        public static string 注册码 { get; set; }
        //钥匙05
        public static string 公钥2018 { get; set; } =
            "<RSAKeyValue><Modulus>pUn/pzjdPTFwVZFh17eOfHyi2YPFQqKzfA9Tv+VePgMRSxAEAmHHCIHGzakz+h29V3oFUz7CTEXvtg37huqZGFbUAKR2qFQNFDL+JFLyB11Tu/zdGdN2OwJsFfPo/nsh3A5ZMSI71AYZrSGP5v0WiBWj9ss0RhzVbYEqoX/YZvE=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"
            ;

        //钥匙06
        public static string 公钥2021 { get; set; } =
            "<RSAKeyValue><Modulus>zTfxKlxPUKKDNajIUsRlpgqnvJIC6OXRdiDiRdFCldgWL7RzJscGBalEPbaqCu9kC7OTUuva7w0nDDPOaJAluQ+CPcfzcokkKquhqQzvNy1NG7n6NvHwTQmVLiAQfZrdBQGYlyfH+SU0+wXUyQOwz7PuRHXXs/mC10RrrANmmx8=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"
            ;
        #region 授权

        public static DateTime 启动时间 { get; set; } = DateTime.Now;

        public static bool 允许试用 => DateTime.Now - 启动时间 < 常量.H2小时;
        public static bool 半年试用 => DateTime.Now > new DateTime(2021, 4, 25)
            && DateTime.Now < new DateTime(2021, 10, 1);
        public static bool 授权 { get; set; } = true;

        public static bool 功能限制 => !授权 && !允许试用 && !半年试用;


        #endregion

    }
}
