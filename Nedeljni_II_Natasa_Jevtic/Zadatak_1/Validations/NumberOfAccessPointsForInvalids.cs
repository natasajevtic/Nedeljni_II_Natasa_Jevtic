using System;
using System.Globalization;
using System.Windows.Controls;

namespace Zadatak_1.Validations
{
    class NumberOfAccessPointsForInvalidsValidation : ValidationRule
    {
        /// <summary>
        /// This method checks if user enter a number for access points and when editing that number is higher than previous one.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns>ValidationResult.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string number = value as string;
            if (!Int32.TryParse(number, out int numberOfAccessPoints))
            {
                return new ValidationResult(false, "Please enter a number.");
            }
            else if (numberOfAccessPoints < 0)
            {
                return new ValidationResult(false, "Please enter a positive number.");
            }
            else
            {
                if (this.Wrapper != null)
                {
                    if (numberOfAccessPoints < this.Wrapper.OldNumberOfInvalids)
                    {
                        return new ValidationResult(false, "The number of access points can only be higher than the previous one.");
                    }
                    else
                    {
                        return new ValidationResult(true, null);
                    }
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
        }
        public Wrapper Wrapper { get; set; }
    }
}

