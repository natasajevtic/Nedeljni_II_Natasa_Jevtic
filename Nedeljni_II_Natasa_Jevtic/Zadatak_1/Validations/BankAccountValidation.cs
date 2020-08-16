using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Zadatak_1.Models;

namespace Zadatak_1.Validations
{
    class BankAccountValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string number = value as string;
            if (number.Length == 18)
            {
                Doctors doctors = new Doctors();
                List<vwClinicDoctor> doctorList = doctors.ViewAllDoctors();
                var doctor = doctorList.Where(x => x.BankAccountNumber == number).FirstOrDefault();
                //if exists doctor with forwarded number, return false
                if (doctor != null)
                {
                    if (this.Wrapper != null)
                    {
                        //if doctor editing
                        if (this.Wrapper.OldBankAccountNumber == doctor.BankAccountNumber)
                        {
                            return new ValidationResult(true, null);
                        }
                        //if doctor creating
                        else
                        {
                            return new ValidationResult(false, "Doctor with this account already exists.");
                        }
                    }
                    else
                    {
                        return new ValidationResult(false, "Doctor with this account already exists.");
                    }
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
            else
            {
                return new ValidationResult(false, "Number must contain 18 digits.");
            }
        }
        public Wrapper Wrapper { get; set; }
    }
}  
