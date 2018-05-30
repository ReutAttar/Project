using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PLWPF
{
    class IDValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            {
                int num ;
                if (!int.TryParse(value.ToString(), out num))
                    return new ValidationResult(false, "ID must be integer");
                return ValidationResult.ValidResult;
            }
        }
    }
}
