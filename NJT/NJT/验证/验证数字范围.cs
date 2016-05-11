using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NJT.验证
{
    public class 验证数字范围 : ValidationRule
    {
        private int min;

        public int Min
        {
            get { return min; }
            set { min = value; }
        }

        private int max;

        public int Max
        {
            get { return max; }
            set { max = value; }
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int number;
            if (!int.TryParse((string)value, out number))
            {
                return new ValidationResult(false, "请输入数字");
            }

            if (number < min || number > max)
            {
                return new ValidationResult(false, string.Format("请在此范围内输入:{0},{1}", min, max));
            }

            return ValidationResult.ValidResult;
        }
    }
}
