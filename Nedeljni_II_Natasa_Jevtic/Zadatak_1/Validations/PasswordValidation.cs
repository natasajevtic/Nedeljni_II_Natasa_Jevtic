using System;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;

namespace Zadatak_1.Validations
{
    class PasswordValidation : ValidationRule
    {
        /// <summary>
        /// This method checks if user password meets the requirements.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns>validationResult.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string password = value as string;
            if (password.Length < 8)
            {
                return new ValidationResult(false, "Password must contain at least 8 characters.");
            }
            else
            {
                var listOfUpper = password.Where(Char.IsUpper).ToList();
                if (listOfUpper.Count < 1)
                {
                    return new ValidationResult(false, "Password must contain at least one upper letter.");
                }
                else
                {
                    var listOfLower = password.Where(Char.IsLower).ToList();
                    if (listOfLower.Count < 1)
                    {
                        return new ValidationResult(false, "Password must contain at least one lower letter.");
                    }
                    else
                    {
                        var listOfDigits = password.Where(Char.IsDigit).ToList();
                        if (listOfDigits.Count < 1)
                        {
                            return new ValidationResult(false, "Password must contain at least one digit.");
                        }
                        else
                        {
                            var listOfSpecialCharacters = password.Where(Char.IsSymbol).ToList();
                            if (listOfSpecialCharacters.Count < 1)
                            {
                                return new ValidationResult(false, "Password must contain at least one special character.");
                            }
                            else
                            {
                                return new ValidationResult(true, null);
                            }
                        }

                    }
                }
            }
        }
    }
}

