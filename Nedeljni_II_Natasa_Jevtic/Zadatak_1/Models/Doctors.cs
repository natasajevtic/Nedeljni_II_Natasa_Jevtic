using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Zadatak_1.Helper;

namespace Zadatak_1.Models
{
    class Doctors
    {
        /// <summary>
        /// This method creates a list of data from view of doctors.
        /// </summary>
        /// <returns>List of doctors.</returns>
        public List<vwClinicDoctor> ViewAllDoctors()
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    return context.vwClinicDoctors.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method adds doctor to DbSet and save changes to database.
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns>True if added, false if not.</returns>
        public bool CreateDoctor(vwClinicDoctor doctor)
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    tblUser user = new tblUser
                    {
                        Citizenship = doctor.Citizenship,
                        DateOfBirth = doctor.DateOfBirth,
                        Gender = doctor.Gender,
                        IdentityCardNumber = doctor.IdentityCardNumber,
                        NameAndSurname = doctor.NameAndSurname,
                        Password = Encryption.EncryptPassword(doctor.Password),
                        Username = doctor.Username
                    };
                    context.tblUsers.Add(user);
                    context.SaveChanges();
                    doctor.UserId = user.UserId;
                    tblClinicDoctor newDoctor = new tblClinicDoctor
                    {
                        BankAccountNumber = doctor.BankAccountNumber,
                        Department = doctor.Department,
                        ResponsibleForPatientAdmission = doctor.ResponsibleForPatientAdmission,
                        Shift = doctor.Shift,
                        SuperiorManager = doctor.SuperiorManager,
                        UniqueNumber = doctor.UniqueNumber,
                        UserId = doctor.UserId
                    };
                    context.tblClinicDoctors.Add(newDoctor);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        /// <summary>
        /// This method edits data about doctor and save changes to database.
        /// </summary>
        /// <param name="doctor">Doctor to be edited.</param>
        /// <returns>True if edited, false if not.</returns>
        public bool EditDoctor(vwClinicDoctor doctor)
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    tblClinicDoctor doctorToEdit = context.tblClinicDoctors.Where(x => x.DoctorId == doctor.DoctorId).FirstOrDefault();
                    doctorToEdit.UniqueNumber = doctor.UniqueNumber;
                    doctorToEdit.SuperiorManager = doctor.SuperiorManager;
                    doctorToEdit.Shift = doctor.Shift;
                    doctorToEdit.ResponsibleForPatientAdmission = doctor.ResponsibleForPatientAdmission;
                    doctorToEdit.Department = doctor.Department;
                    doctorToEdit.BankAccountNumber = doctor.BankAccountNumber;
                    context.SaveChanges();
                    tblUser userToEdit = context.tblUsers.Where(x => x.UserId == doctor.UserId).FirstOrDefault();
                    userToEdit.NameAndSurname = doctor.NameAndSurname;
                    userToEdit.IdentityCardNumber = doctor.IdentityCardNumber;
                    userToEdit.Gender = doctor.Gender;
                    userToEdit.DateOfBirth = doctor.DateOfBirth;
                    userToEdit.Citizenship = doctor.Citizenship;
                    userToEdit.Username = doctor.Username;
                    userToEdit.Password = Encryption.EncryptPassword(doctor.Password);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
    }
}
