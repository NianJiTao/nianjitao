namespace NJT.Core
{
    public static class Base24Encoding
    {
        private const string SBase24 = "BCDFGHJKMPQRTVWXY2346789";

        public static string 编码(string sIn)
        {
            if (sIn == null)
                return string.Empty;
            var s2 = System.Text.Encoding.Default.GetBytes(sIn);
            return Base24Encoding.编码toString(s2);
        }

        public static string 解码(string sIn)
        {
            if (sIn == null)
                return string.Empty;
            var s2 = Base24Encoding.解码toByte(sIn);
            return System.Text.Encoding.Default.GetString(s2);
        }


        public static string 编码toString(byte[] sIn)
        {
            if (sIn == null)
                return string.Empty;

            var idx = 0;
            var inl = sIn.Length;
            var sOut = new char[inl * 2];

            for (idx = 0; idx < inl; idx++)
            {
                var n = sIn[idx];
                var n1 = (byte)(n >> 4);
                var n2 = (byte)(n & 0x0f);

                sOut[2 * idx] = SBase24[n1];
                sOut[2 * idx + 1] = SBase24[23 - n2];
            }

            return new string(sOut);
        }

        public static byte[] 解码toByte(string sIn)
        {
            if (sIn == null)
                return new byte[0];

            var idx = 0;
            var inl = sIn.Length;

            if (inl % 2 == 1)
                return new byte[0];

            var outl = inl / 2;
            var sOut = new byte[outl];

            for (idx = 0; idx < outl; idx++)
            {
                var c1 = sIn[2 * idx];
                var c2 = sIn[2 * idx + 1];

                var loc1 = (byte)SBase24.IndexOf(c1);
                var loc2 = (byte)SBase24.IndexOf(c2);

                var n1 = loc1;
                var n2 = loc2;
                n2 = (byte)(23 - n2);

                var n = (byte)((n1 << 4) | n2);

                sOut[idx] = n;
            }

            return sOut;
        }
    }
}