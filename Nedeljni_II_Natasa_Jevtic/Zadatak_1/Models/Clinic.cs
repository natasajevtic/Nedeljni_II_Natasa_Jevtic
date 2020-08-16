using System;
using System.Diagnostics;
using System.Linq;

namespace Zadatak_1.Models
{
    class Clinic
    {
        /// <summary>
        /// This method adds clinic to DbSet and save changes to database.
        /// </summary>
        /// <param name="clinic">Clinic to be added.</param>
        /// <returns>true if added, false if not.</returns>
        public bool CreateClinic(vwClinic clinic)
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    tblClinic newClinic = new tblClinic
                    {
                        Address = clinic.Address,
                        DateOfConstruction = clinic.DateOfConstruction.Date,
                        Name = clinic.Name,
                        NumberOfAccessPointsForAmbulanceCars = clinic.NumberOfAccessPointsForAmbulanceCars,
                        NumberOfAccessPointsForInvalids = clinic.NumberOfAccessPointsForInvalids,
                        NumberOfFloors = clinic.NumberOfFloors,
                        NumberOfRoomsPerFloor = clinic.NumberOfRoomsPerFloor,
                        Owner = clinic.Owner,
                        Terrace = clinic.Terrace,
                        Yard = clinic.Yard
                    };
                    context.tblClinics.Add(newClinic);
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
        /// This method checks if clinic exists in database.
        /// </summary>
        /// <returns>True if exists, false if not.</returns>
        public bool CheckIfClinicExists()
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    return context.tblClinics.Any();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        /// <summary>
        /// This method edits data about clinic.
        /// </summary>
        /// <param name="clinic">Clinic to be edited.</param>
        /// <returns>True if edited, false if not.</returns>
        public bool EditClinic(vwClinic clinic)
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    tblClinic clinicToEdit = context.tblClinics.Where(x => x.ClinicId == clinic.ClinicId).FirstOrDefault();
                    clinicToEdit.Owner = clinic.Owner;
                    clinicToEdit.NumberOfAccessPointsForAmbulanceCars = clinic.NumberOfAccessPointsForAmbulanceCars;
                    clinicToEdit.NumberOfAccessPointsForInvalids = clinic.NumberOfAccessPointsForInvalids;
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
        /// This method return clinic from DbSet.
        /// </summary>
        /// <returns>Clinic if exists, null if not.</returns>
        public vwClinic ViewClinic()
        {
            try
            {
                using (ClinicEntities context = new ClinicEntities())
                {
                    return context.vwClinics.FirstOrDefault();
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
