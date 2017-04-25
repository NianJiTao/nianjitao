using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NJT.Convert
{
    public class 验证字符串为空 : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var number = value as string;
            return string.IsNullOrWhiteSpace(number)
                ? new ValidationResult(false, "不能为空")
                : ValidationResult.ValidResult;
        }
    }
}
