using System;
using System.Globalization;
using System.Windows.Controls;

namespace Zadatak_1.Validations
{
    class ExpiryDateOfHealthInsuranceValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string expiryDate = value as string;
            try
            {
                DateTime conversion = DateTime.ParseExact(expiryDate, "M/d/yyyy", CultureInfo.InvariantCulture);
                if (conversion < DateTime.Now)
                {
                    return new ValidationResult(false, "Cannot be in the past.");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
            //if cannot convert to DateTime, because  doesn't contain a valid date
            catch (Exception)
            {
                return new ValidationResult(false, "Invalid date. Format: M/d/yyyy");
            }
        }
    }
}
