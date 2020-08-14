using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Zadatak_1.Helper;

namespace Zadatak_1.Models
{
    class Users
    {
        /// <summary>
        /// This method finds administrator in DbSet with forwarded username and password.
        /// </summary>
        /// <param name="username">Administrator username.</param>
        /// <param name="password">Administrator password.</param>
        /// <returns>Administrator if finded, null if not.</returns>
        public vwClinicAdministrator FindAdministrator(string username, string password)
        {
            string encryptedPassword = Encryption.EncryptPassword(password);
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    return context.vwClinicAdministrators.Where(x => x.Username == username && x.Password == encryptedPassword).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method finds maintenance in DbSet with forwarded username and password.
        /// </summary>
        /// <param name="username">Maintenance username.</param>
        /// <param name="password">Maintenance password.</param>
        /// <returns>Maintenance if finded, null if not.</returns>
        public vwClinicMaintenance FindMaintenance(string username, string password)
        {
            string encryptedPassword = Encryption.EncryptPassword(password);
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    return context.vwClinicMaintenances.Where(x => x.Username == username && x.Password == encryptedPassword).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method finds manager in DbSet with forwarded username and password.
        /// </summary>
        /// <param name="username">Manager username.</param>
        /// <param name="password">Manager password.</param>
        /// <returns>Manager if finded, null if not.</returns>
        public vwClinicManager FindManager(string username, string password)
        {
            string encryptedPassword = Encryption.EncryptPassword(password);
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    return context.vwClinicManagers.Where(x => x.Username == username && x.Password == encryptedPassword).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
         /// This method finds doctor in DbSet with forwarded username and password.
         /// </summary>
         /// <param name="username">Doctor username.</param>
         /// <param name="password">Doctor password.</param>
         /// <returns>Doctor if finded, null if not.</returns>
        public vwClinicDoctor FindDoctor(string username, string password)
        {
            string encryptedPassword = Encryption.EncryptPassword(password);
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    return context.vwClinicDoctors.Where(x => x.Username == username && x.Password == encryptedPassword).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method finds patient in DbSet with forwarded username and password.
        /// </summary>
        /// <param name="username">Patient username.</param>
        /// <param name="password">patient password.</param>
        /// <returns>Patient if finded, null if not.</returns>
        public vwClinicPatient FindPatient(string username, string password)
        {
            string encryptedPassword = Encryption.EncryptPassword(password);
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    return context.vwClinicPatients.Where(x => x.Username == username && x.Password == encryptedPassword).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method creates a list of data from table of all users.
        /// </summary>
        /// <returns>List of users.</returns>
        public List<tblUser> GetAllUsers()
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    return context.tblUsers.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
