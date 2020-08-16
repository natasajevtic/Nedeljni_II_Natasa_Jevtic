using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using Zadatak_1.Models;

namespace Zadatak_1.Validations
{
    class DoctorNumberValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string number = value as string;
            if (number.Length == 5)
            {
                Doctors doctors = new Doctors();
                List<vwClinicDoctor> doctorList = doctors.ViewAllDoctors();
                var doctor = doctorList.Where(x => x.UniqueNumber == number).FirstOrDefault();
                //if exists doctor with forwarded number, return false
                if (doctor != null)
                {
                    if (this.Wrapper != null)
                    {
                        //if doctor editing
                        if (this.Wrapper.OldDoctorNumber == doctor.UniqueNumber)
                        {
                            return new ValidationResult(true, null);
                        }
                        //if doctor creating
                        else
                        {
                            return new ValidationResult(false, "Doctor with this number already exists.");
                        }
                    }
                    else
                    {
                        return new ValidationResult(false, "Doctor with this number already exists.");
                    }
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
            else
            {
                return new ValidationResult(false, "Number must contain 5 digits.");
            }
        }
        public Wrapper Wrapper { get; set; }
    }
}    
