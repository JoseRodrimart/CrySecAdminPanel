using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CrySecAdminPanel.validationRules
{
    internal class NotEmptyValidationRule : ValidationRule
    {
        Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrWhiteSpace(value as string))
                return new ValidationResult(false, "Field is required.");

            if (!regex.IsMatch(value as string))
                return new ValidationResult(false, "Not a valid email");
            else
                return ValidationResult.ValidResult;
        }
    }
}
