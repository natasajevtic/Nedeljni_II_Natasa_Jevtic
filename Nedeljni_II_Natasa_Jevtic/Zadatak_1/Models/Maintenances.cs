using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Zadatak_1.Helper;

namespace Zadatak_1.Models
{
    class Maintenances
    {
        /// <summary>
        /// This methos creates a list of data from view of maintenance.
        /// </summary>
        /// <returns>list of maintenance.</returns>
        public List<vwClinicMaintenance> ViewAllMaintenances()
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    return context.vwClinicMaintenances.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method checks if three maintenance already exist in database.
        /// </summary>
        /// <returns>True id exist, false if not.</returns>
        public bool CheckIfExistThree()
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    int number = context.tblClinicMaintenances.Count();
                    if (number < 3)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        /// <summary>
        /// This method finds first maintenance in database and then invokes method for deleting.
        /// </summary>
        public void DeleteFirst()
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    Queue<vwClinicMaintenance> maintenances = new Queue<vwClinicMaintenance>(3);
                    var maintenancesFromDb = context.vwClinicMaintenances.ToList();
                    foreach (var item in maintenancesFromDb)
                    {
                        maintenances.Enqueue(item);
                    }
                    vwClinicMaintenance maintenanceToDelete = maintenances.Dequeue();
                    DeleteMaintenance(maintenanceToDelete);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
        /// <summary>
        /// This method adds maintenance to DbSet and save changes to database.
        /// </summary>
        /// <param name="maintenance">maintenance to be added.</param>
        /// <returns>True if added, false if not.</returns>
        public bool CreateMaintenance(vwClinicMaintenance maintenance)
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    tblUser user = new tblUser
                    {
                        NameAndSurname = maintenance.NameAndSurname,
                        IdentityCardNumber = maintenance.IdentityCardNumber,
                        Gender = maintenance.Gender,
                        DateOfBirth = maintenance.DateOfBirth.Date,
                        Citizenship = maintenance.Citizenship,
                        Username = maintenance.Username,
                        Password = Encryption.EncryptPassword(maintenance.Password)
                    };
                    context.tblUsers.Add(user);
                    context.SaveChanges();
                    maintenance.UserId = user.UserId;
                    tblClinicMaintenance newMaintenance = new tblClinicMaintenance
                    {
                        PermissionToExpandClinic = maintenance.PermissionToExpandClinic,
                        ResponsibleForAccessibilityOfInvalids = maintenance.ResponsibleForAccessibilityOfInvalids,
                        UserId = maintenance.UserId
                    };
                    context.tblClinicMaintenances.Add(newMaintenance);
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
        /// This method edits data about maintenance and save changes to database.
        /// </summary>
        /// <param name="maintenance">Maintenance to be edited.</param>
        /// <returns>true if edited, false if not.</returns>
        public bool EditMaintenance(vwClinicMaintenance maintenance)
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    tblClinicMaintenance maintenanceToEdit = context.tblClinicMaintenances.Where(x => x.MaintenanceId == maintenance.MaintenanceId).FirstOrDefault();
                    maintenanceToEdit.PermissionToExpandClinic = maintenance.PermissionToExpandClinic;
                    maintenanceToEdit.ResponsibleForAccessibilityOfInvalids = maintenance.ResponsibleForAccessibilityOfInvalids;
                    context.SaveChanges();
                    tblUser userToEdit = context.tblUsers.Where(x => x.UserId == maintenance.UserId).FirstOrDefault();
                    userToEdit.NameAndSurname = maintenance.NameAndSurname;
                    userToEdit.IdentityCardNumber = maintenance.IdentityCardNumber;
                    userToEdit.Gender = maintenance.Gender;
                    userToEdit.DateOfBirth = maintenance.DateOfBirth;
                    userToEdit.Citizenship = maintenance.Citizenship;
                    userToEdit.Username = maintenance.Username;
                    userToEdit.Password = Encryption.EncryptPassword(maintenance.Password);
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
        /// This method deletes maintenance from database.
        /// </summary>
        /// <param name="maintenance">Maintenance to be deleted.</param>
        /// <returns>True if deleted, false if not.</returns>
        public bool DeleteMaintenance(vwClinicMaintenance maintenance)
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {

                    tblClinicMaintenance maintenanceToDelete = context.tblClinicMaintenances.Where(x => x.MaintenanceId == maintenance.MaintenanceId).FirstOrDefault();
                    //finding user to be deleted
                    tblUser userToDelete = context.tblUsers.Where(x => x.UserId == maintenance.UserId).FirstOrDefault();
                    context.tblClinicMaintenances.Remove(maintenanceToDelete);
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