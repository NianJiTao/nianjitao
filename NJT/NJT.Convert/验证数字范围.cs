using System.Globalization;
using System.Windows.Controls;

namespace NJT.Convert
{
    public class 验证数字范围 : ValidationRule
    {
        public int Min { get; set; }

        public int Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value==null)
            {
                return ValidationResult.ValidResult;
            }
            int number;
            if (!int.TryParse( value.ToString(), out number))
                return new ValidationResult(false, "请输入数字");

            if (number < Min || number > Max)
                return new ValidationResult(false, $"请在此范围内输入:{Min}~{Max}");

            return ValidationResult.ValidResult;
        }
    }
}