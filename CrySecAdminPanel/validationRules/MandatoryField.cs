using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CrySecAdminPanel.validationRules
{
    internal class MandatoryField : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrWhiteSpace(value as string))
                return new ValidationResult(false, "Field is required.");
            else
                return ValidationResult.ValidResult;
        }
    }
}
