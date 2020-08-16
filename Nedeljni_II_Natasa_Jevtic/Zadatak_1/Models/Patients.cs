using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Zadatak_1.Helper;

namespace Zadatak_1.Models
{
    class Patients
    {
        /// <summary>
        /// This method creates a list of data from view of patients.
        /// </summary>
        /// <returns>List of patients.</returns>
        public List<vwClinicPatient> ViewAllPatients()
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    return context.vwClinicPatients.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method adds patient to DbSet and save changes to database.
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>True if added, false if not.</returns>
        public bool CreatePatient(vwClinicPatient patient)
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    tblUser user = new tblUser
                    {
                        Citizenship = patient.Citizenship,
                        DateOfBirth = patient.DateOfBirth,
                        Gender = patient.Gender,
                        IdentityCardNumber = patient.IdentityCardNumber,
                        NameAndSurname = patient.NameAndSurname,
                        Password = Encryption.EncryptPassword(patient.Password),
                        Username = patient.Username
                    };
                    context.tblUsers.Add(user);
                    context.SaveChanges();
                    patient.UserId = user.UserId;
                    tblClinicPatient newPatient = new tblClinicPatient
                    {
                       ExpirationDateOfHealthInsurance = patient.ExpirationDateOfHealthInsurance,
                       HealthInsuranceCardNumber = patient.HealthInsuranceCardNumber,
                       UniqueNumberOfSelectedDoctor = patient.UniqueNumberOfSelectedDoctor,
                       UserId = patient.UserId
                    };
                    context.tblClinicPatients.Add(newPatient);
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
        /// This method edits data about patient and save changes to database.
        /// </summary>
        /// <param name="patient">Patient to be edited.</param>
        /// <returns>True if edited, false if not.</returns>
        public bool EditPatient(vwClinicPatient patient)
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    tblClinicPatient patientToEdit = context.tblClinicPatients.Where(x => x.PatientId == patient.PatientId).FirstOrDefault();
                    patientToEdit.ExpirationDateOfHealthInsurance = patient.ExpirationDateOfHealthInsurance;
                    patientToEdit.HealthInsuranceCardNumber = patient.HealthInsuranceCardNumber;
                    patientToEdit.UniqueNumberOfSelectedDoctor = patient.UniqueNumberOfSelectedDoctor;
                    context.SaveChanges();
                    tblUser userToEdit = context.tblUsers.Where(x => x.UserId == patient.UserId).FirstOrDefault();
                    userToEdit.NameAndSurname = patient.NameAndSurname;
                    userToEdit.IdentityCardNumber = patient.IdentityCardNumber;
                    userToEdit.Gender = patient.Gender;
                    userToEdit.DateOfBirth = patient.DateOfBirth;
                    userToEdit.Citizenship = patient.Citizenship;
                    userToEdit.Username = patient.Username;
                    userToEdit.Password = Encryption.EncryptPassword(patient.Password);
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
        /// This method deletes patient from database.
        /// </summary>
        /// <param name="patient">Patient to be deleted.</param>
        /// <returns>True if deleted, false if not.</returns>
        public bool DeletePatient(vwClinicPatient patient)
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {

                    tblClinicPatient patientToDelete = context.tblClinicPatients.Where(x => x.PatientId == patient.PatientId).FirstOrDefault();
                    //finding user to be deleted
                    tblUser userToDelete = context.tblUsers.Where(x => x.UserId == patient.UserId).FirstOrDefault();
                    context.tblClinicPatients.Remove(patientToDelete);
                    context.SaveChanges();
                    context.tblUsers.Remove(userToDelete);
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
