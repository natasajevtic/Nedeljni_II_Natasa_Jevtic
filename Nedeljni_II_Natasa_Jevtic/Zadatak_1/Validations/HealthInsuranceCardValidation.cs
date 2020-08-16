using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using Zadatak_1.Models;

namespace Zadatak_1.Validations
{
    class HealthInsuranceCardValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string number = value as string;
            if (number.Length == 11)
            {
                Patients patients = new Patients();
                List<vwClinicPatient> patientsList = patients.ViewAllPatients();
                var patient = patientsList.Where(x => x.HealthInsuranceCardNumber == number).FirstOrDefault();
                //if exists patient with forwarded number, return false
                if (patient != null)
                {
                    if (this.Wrapper != null)
                    {
                        //if user editing
                        if (this.Wrapper.OldHealthInsurance == patient.HealthInsuranceCardNumber)
                        {
                            return new ValidationResult(true, null);
                        }
                        //if user creating
                        else
                        {
                            return new ValidationResult(false, "This number already exists.");
                        }
                    }
                    else
                    {
                        return new ValidationResult(false, "This number already exists.");
                    }
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
            else
            {
                return new ValidationResult(false, "Number must contain 11 digits.");
            }
        }
        public Wrapper Wrapper { get; set; }
    }
}

