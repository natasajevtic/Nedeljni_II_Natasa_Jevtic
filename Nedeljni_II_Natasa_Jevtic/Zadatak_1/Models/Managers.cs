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
        /// <summary>
        /// This method edit data about manager and save changes to database.
        /// </summary>
        /// <param name="manager">Manager to be edited.</param>
        /// <returns>True if edited, false if not.</returns>
        public bool EditManager(vwClinicManager manager)
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    tblClinicManager managerToEdit = context.tblClinicManagers.Where(x => x.ManagerId == manager.ManagerId).FirstOrDefault();
                    managerToEdit.Floor = manager.Floor;
                    managerToEdit.MaximumNumberOfSupervisedDoctors = manager.MaximumNumberOfSupervisedDoctors;
                    managerToEdit.MinimumNumberOfSupervisedRooms = manager.MinimumNumberOfSupervisedRooms;
                    managerToEdit.NumberOfOmissions = manager.NumberOfOmissions;
                    context.SaveChanges();
                    tblUser userToEdit = context.tblUsers.Where(x => x.UserId == manager.UserId).FirstOrDefault();
                    userToEdit.NameAndSurname = manager.NameAndSurname;
                    userToEdit.IdentityCardNumber = manager.IdentityCardNumber;
                    userToEdit.Gender = manager.Gender;
                    userToEdit.DateOfBirth = manager.DateOfBirth;
                    userToEdit.Citizenship = manager.Citizenship;
                    userToEdit.Username = manager.Username;
                    userToEdit.Password = Encryption.EncryptPassword(manager.Password);
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
        /// This method deleted manager from databas.
        /// </summary>
        /// <param name="manager">Manager to be deleted.</param>
        /// <returns>True if deleted, false if not.</returns>
        public bool DeleteManager(vwClinicManager manager)
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    tblClinicManager managerToDelete = context.tblClinicManagers.Where(x => x.ManagerId == manager.ManagerId).FirstOrDefault();
                    //finding doctors supervised by this manager
                    var doctors = context.tblClinicDoctors.Where(x => x.SuperiorManager == manager.ManagerId).ToList();
                    if (doctors.Count > 0)
                    {
                        foreach (var doctor in doctors)
                        {
                            doctor.SuperiorManager = null;
                            context.SaveChanges();
                        }
                    }
                    context.tblClinicManagers.Remove(managerToDelete);                   
                    context.SaveChanges();
                    tblUser userToDelete = context.tblUsers.Where(x => x.UserId == manager.UserId).FirstOrDefault();
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
        /// <summary>
        /// This method finds managers who can supervise. Number of ommisions cannot be higher than 5 and cannot violate the limit on the maximum number of doctors.
        /// </summary>
        /// <returns>List of managers.</returns>
        public List<vwClinicManager> ManagersWhoCanSupervise()
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    var managers = context.vwClinicManagers.Where(x => x.NumberOfOmissions <=5).ToList();
                    List<vwClinicManager> managerWhoCanSupervise = new List<vwClinicManager>();
                    foreach (var manager in managers)
                    {
                        //finding number of doctors that this manager supervise
                        int numberOfDoctors = context.tblClinicDoctors.Where(x => x.SuperiorManager == manager.ManagerId).Count();                        
                        if (numberOfDoctors < manager.MaximumNumberOfSupervisedDoctors)
                        {
                            managerWhoCanSupervise.Add(manager);
                        }
                    }
                    return managerWhoCanSupervise;
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