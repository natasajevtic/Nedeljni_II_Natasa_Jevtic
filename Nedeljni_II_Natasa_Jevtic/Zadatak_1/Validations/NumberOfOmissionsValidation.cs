﻿using System;
using System.Globalization;
using System.Windows.Controls;

namespace Zadatak_1.Validations
{
    class NumberOfOmissionsValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string number = value as string;
            if (!Int32.TryParse(number, out int numberOfOmissions))
            {
                return new ValidationResult(false, "Please enter a number.");
            }
            else if (numberOfOmissions < 0)
            {
                return new ValidationResult(false, "Please enter a positive number.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
