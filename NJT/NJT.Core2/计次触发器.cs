using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public class 计次触发器
    {
        public int 最大次数 { get; set; } = 3;
        private int _当前次数 = 0;
        public event EventHandler 超限触发;
        public event EventHandler 恢复触发;
        public bool Is超限触发 { get; private set; } = false;
        public bool Is首次触发 { get; private set; } = false;

        public void 累计()
        {
            _当前次数++;
            if (_当前次数 < 最大次数)
                return;
            _当前次数 = 0;
            if (Is超限触发)
                return;
            Is超限触发 = true;
            超限触发?.Invoke(this, null);
        }

        public void 恢复()
        {
            _当前次数 = 0;
            if (Is超限触发)
            {
                Is超限触发 = false;
                恢复触发?.Invoke(this, null);
                return;
            }
            if (Is首次触发 == false)
            {
                Is首次触发 = true;
                Is超限触发 = false;
                恢复触发?.Invoke(this, null);
                return;
            }
        }
    }
}
