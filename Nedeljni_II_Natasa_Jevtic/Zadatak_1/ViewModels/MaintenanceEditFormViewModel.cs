using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class MaintenanceEditFormViewModel : BaseViewModel
    {
        MaintenanceEditFormView maintenanceView;
        Genders genders = new Genders();
        Maintenances maintenances = new Maintenances();

        public vwClinicMaintenance OldMaintenance { get; set; }

        private vwClinicMaintenance clinicMaintenance;

        public vwClinicMaintenance ClinicMaintenance
        {
            get
            {
                return clinicMaintenance;
            }
            set
            {
                clinicMaintenance = value;
                OnPropertyChanged("ClinicMaintenance");
            }
        }

        private List<string> genderList;

        public List<string> GenderList
        {
            get
            {
                return genderList;
            }
            set
            {
                genderList = value;
                OnPropertyChanged("GenderList");
            }
        }

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                if (cancel == null)
                {
                    cancel = new RelayCommand(param => CancelExecute(), param => CanCancelExecute());
                }
                return cancel;
            }
        }

        public MaintenanceEditFormViewModel(MaintenanceEditFormView maintenanceView, vwClinicMaintenance maintenanceToEdit)
        {
            this.maintenanceView = maintenanceView;
            ClinicMaintenance = maintenanceToEdit;
            GenderList = genders.GetGenders();
            OldMaintenance = new vwClinicMaintenance
            {
                Citizenship = maintenanceToEdit.Citizenship,
                DateOfBirth = maintenanceToEdit.DateOfBirth,
                Gender = maintenanceToEdit.Gender,
                IdentityCardNumber = maintenanceToEdit.IdentityCardNumber,
                NameAndSurname = maintenanceToEdit.NameAndSurname,
                Password = maintenanceToEdit.Password,
                PermissionToExpandClinic = maintenanceToEdit.PermissionToExpandClinic,
                ResponsibleForAccessibilityOfInvalids = maintenanceToEdit.ResponsibleForAccessibilityOfInvalids,
                Username = maintenanceToEdit.Username
            };
        }

        public void SaveExecute()
        {
            if (String.IsNullOrEmpty(ClinicMaintenance.NameAndSurname) || String.IsNullOrEmpty(ClinicMaintenance.IdentityCardNumber) || String.IsNullOrEmpty(ClinicMaintenance.DateOfBirth.ToString()) || String.IsNullOrEmpty(ClinicMaintenance.Gender)
               || String.IsNullOrEmpty(ClinicMaintenance.Citizenship) || String.IsNullOrEmpty(ClinicMaintenance.Username) || String.IsNullOrEmpty(ClinicMaintenance.Password))
            {
                MessageBox.Show("Please fill all fields.", "Notification");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to edit the maintenance?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isEdited = maintenances.EditMaintenance(ClinicMaintenance);
                        if (isEdited)
                        {
                            MessageBox.Show("Maintenance is edited.", "Notification", MessageBoxButton.OK);
                            maintenanceView.Close();
                        }
                        else
                        {
                            MessageBox.Show("Maintenance cannot be edited.", "Notification", MessageBoxButton.OK);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public bool CanSaveExecute()
        {
            if (ClinicMaintenance.NameAndSurname != OldMaintenance.NameAndSurname || ClinicMaintenance.IdentityCardNumber != OldMaintenance.IdentityCardNumber ||
                ClinicMaintenance.Gender != OldMaintenance.Gender || ClinicMaintenance.DateOfBirth != OldMaintenance.DateOfBirth || ClinicMaintenance.Citizenship != OldMaintenance.Citizenship
                || ClinicMaintenance.Username != OldMaintenance.Username || ClinicMaintenance.Password != OldMaintenance.Password || ClinicMaintenance.PermissionToExpandClinic != OldMaintenance.PermissionToExpandClinic
                || ClinicMaintenance.ResponsibleForAccessibilityOfInvalids != OldMaintenance.ResponsibleForAccessibilityOfInvalids)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CancelExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel editing the maintenance?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    maintenanceView.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanCancelExecute()
        {
            return true;
        }
    }
}