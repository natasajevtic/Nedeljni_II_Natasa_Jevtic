using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Zadatak_1.Helper;

namespace Zadatak_1.Models
{
    class Administrators
    {
        /// <summary>
        /// This method adds administrator to DbSet and save changes to database.
        /// </summary>
        /// <param name="administrator">Administrator to be added.</param>
        /// <returns>True if added, false if not.</returns>
        public bool CreateAdministrator(vwClinicAdministrator administrator)
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    tblUser user = new tblUser
                    {
                        Citizenship = administrator.Citizenship,
                        DateOfBirth = administrator.DateOfBirth,
                        Gender = administrator.Gender,
                        IdentityCardNumber = administrator.IdentityCardNumber,
                        NameAndSurname = administrator.NameAndSurname,
                        Password = Encryption.EncryptPassword(administrator.Password),
                        Username = administrator.Username
                    };
                    context.tblUsers.Add(user);
                    context.SaveChanges();
                    administrator.UserId = user.UserId;
                    tblClinicAdministrator newAdministrator = new tblClinicAdministrator
                    {
                        UserId = administrator.UserId
                    };
                    context.tblClinicAdministrators.Add(newAdministrator);
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
        /// This method checks if any administrator exists in database.
        /// </summary>
        /// <returns>True if exists, false if not.</returns>
        public bool CheckIfAdministratorExists()
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    return context.tblClinicAdministrators.Any();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        /// <summary>
        /// This method creates a list of data from view of administrators.
        /// </summary>
        /// <returns>List of administrators.</returns>
        public List<vwClinicAdministrator> ViewAdministrator()
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    return context.vwClinicAdministrators.ToList();
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
