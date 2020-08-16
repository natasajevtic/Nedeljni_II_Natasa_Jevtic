using System;
using System.Globalization;
using System.Windows.Controls;

namespace Zadatak_1.Validations
{
    class NumberOfRoomsPerFloorValidation : ValidationRule
    {
        /// <summary>
        /// This method checks that user enter a positive number for number of rooms.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string number = value as string;
            if (!Int32.TryParse(number, out int numberOfRoomsPerFloor))
            {
                return new ValidationResult(false, "Please enter a number.");
            }
            else if (numberOfRoomsPerFloor < 1)
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

