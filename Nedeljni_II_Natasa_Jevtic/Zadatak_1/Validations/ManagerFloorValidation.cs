using System;
using System.Globalization;
using System.Windows.Controls;
using Zadatak_1.Models;

namespace Zadatak_1.Validations
{
    class ManagerFloorValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string number = value as string;
            Clinic clinic = new Clinic();
            var existingClinic = clinic.ViewClinic();
            int maxFloor = existingClinic.NumberOfFloors;
            if (!Int32.TryParse(number, out int numberOfFloor))
            {
                return new ValidationResult(false, "Please enter a number.");
            }
            else if (numberOfFloor < 0)
            {
                return new ValidationResult(false, "Please enter a positive number.");
            }
            else if (numberOfFloor > maxFloor)
            {
                return new ValidationResult(false, "The clinic has " + maxFloor + " floors.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
