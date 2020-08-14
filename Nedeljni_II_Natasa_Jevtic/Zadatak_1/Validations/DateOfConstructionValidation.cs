using System;
using System.Globalization;
using System.Windows.Controls;

namespace Zadatak_1.Validations
{
    class DateOfConstructionValidation : ValidationRule
    {
        /// <summary>
        /// This method checks if user input for date of construction valid.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns>ValidationResult.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string dateOfConstruction = value as string;
            try
            {
                DateTime conversion = DateTime.ParseExact(dateOfConstruction, "M/d/yyyy", CultureInfo.InvariantCulture);                
                return new ValidationResult(true, null);
            }
            //if cannot convert to DateTime, because  doesn't contain a valid date
            catch (Exception)
            {
                return new ValidationResult(false, "Invalid date. Format: M/d/yyyy");
            }
        }
    }
}
