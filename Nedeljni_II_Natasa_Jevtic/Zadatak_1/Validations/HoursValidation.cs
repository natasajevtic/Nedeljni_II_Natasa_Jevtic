using System;
using System.Globalization;
using System.Windows.Controls;

namespace Zadatak_1.Validations
{
    class HoursValidation : ValidationRule
    {
        /// <summary>
        /// This method checks if user input for hours valid.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns>ValidationResult.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string number = value as string;
            if (!Double.TryParse(number, out double hours))
            {
                return new ValidationResult(false, "Please enter a number.");
            }
            else if (hours <= 0 || hours > 24)
            {
                return new ValidationResult(false, "Please enter a value between 0.1 and 24.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}