using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Common
{
    public class Base24Encoding
    {
        private const string S_base24 = "BCDFGHJKMPQRTVWXY2346789";

        public string GetString(byte[] bytes)
        {
            return 编码(bytes);
        }


        public byte[] GetBytes(string text)
        {
            byte[] r;
            try
            {
                r = 解码(text);
            }
            catch (Exception)
            {
                return new byte[0];
            }
            return r;
        }

        public static string 编码(byte[] sIn)
        {
            var idx = 0;
            var inl = sIn.Length;
            var sOut = new char[(inl * 2)];

            for (idx = 0; idx < inl; idx++)
            {
                byte n, n1, n2;
                n = sIn[idx];
                n1 = (byte)(n >> 4);
                n2 = (byte)(n & 0x0f);

                sOut[2 * idx] = S_base24[n1];
                sOut[2 * idx + 1] = S_base24[23 - n2];
            }

            return new string(sOut);
        }

        public static byte[] 解码(string sIn)
        {
            var idx = 0;
            var inl = sIn.Length;

            if (inl % 2 == 1)
                return null;

            var outl = inl / 2;
            var sOut = new byte[(outl)];

            for (idx = 0; idx < outl; idx++)
            {
                char c1, c2;
                byte loc1, loc2;
                byte n1, n2, n;

                c1 = sIn[2 * idx];
                c2 = sIn[2 * idx + 1];

                loc1 = (byte)S_base24.IndexOf(c1); // strchr((char*)S_base24, c1);
                loc2 = (byte)S_base24.IndexOf(c2); // strchr((char*)S_base24, c2);

                n1 = loc1;
                n2 = loc2;
                n2 = (byte)(23 - n2);

                n = (byte)((n1 << 4) | n2);

                sOut[idx] = n;
            }

            return sOut;
        }
    }
}
