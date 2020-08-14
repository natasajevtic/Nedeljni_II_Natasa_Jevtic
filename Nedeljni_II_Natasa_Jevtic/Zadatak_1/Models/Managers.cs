using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Zadatak_1.Helper;

namespace Zadatak_1.Models
{
    class Managers
    {
        /// <summary>
        /// This method adds manager to DbSet and save changes to database.
        /// </summary>
        /// <param name="manager">Manager to be added.</param>
        /// <returns>True if added, false if not.</returns>
        public bool CreateManager(vwClinicManager manager)
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    tblUser user = new tblUser
                    {
                        Citizenship = manager.Citizenship,
                        DateOfBirth = manager.DateOfBirth,
                        Gender = manager.Gender,
                        IdentityCardNumber = manager.IdentityCardNumber,
                        NameAndSurname = manager.NameAndSurname,
                        Password = Encryption.EncryptPassword(manager.Password),
                        Username = manager.Username
                    };
                    context.tblUsers.Add(user);
                    context.SaveChanges();
                    manager.UserId = user.UserId;
                    tblClinicManager newManager = new tblClinicManager
                    {
                        Floor = manager.Floor,
                        MaximumNumberOfSupervisedDoctors = manager.MaximumNumberOfSupervisedDoctors,
                        MinimumNumberOfSupervisedRooms = manager.MinimumNumberOfSupervisedRooms,
                        NumberOfOmissions = 0,
                        UserId = manager.UserId

                    };
                    context.tblClinicManagers.Add(newManager);
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
        /// This method creates a list of data from view of amanagers.
        /// </summary>
        /// <returns>List of managers.</returns>
        public List<vwClinicManager> ViewAllManager()
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    return context.vwClinicManagers.ToList();
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