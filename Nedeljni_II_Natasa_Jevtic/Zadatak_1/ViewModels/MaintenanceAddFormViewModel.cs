using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class MaintenanceAddFormViewModel : BaseViewModel
    {
        MaintenanceAddFormView maintenanceView;
        Genders genders = new Genders();
        Maintenances maintenances = new Maintenances();

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

        public MaintenanceAddFormViewModel(MaintenanceAddFormView maintenanceView)
        {
            this.maintenanceView = maintenanceView;
            ClinicMaintenance = new vwClinicMaintenance();
            GenderList = genders.GetGenders();
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
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to save the maintenance?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool canCreate = maintenances.CheckIfExistThree();
                        if (canCreate == false)
                        {
                            MessageBoxResult result1 = MessageBox.Show("Maximum number of maintances is 3. If you save this maintenance, first maintenance will be deleted. Are you sure you want to save the maintenance?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            if (result1 == MessageBoxResult.Yes)
                            {
                                maintenances.DeleteFirst();
                                bool isCreated = maintenances.CreateMaintenance(ClinicMaintenance);
                                if (isCreated)
                                {
                                    MessageBox.Show("Maintenance is created.", "Notification", MessageBoxButton.OK);
                                    maintenanceView.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Maintenance cannot be created.", "Notification", MessageBoxButton.OK);
                                }
                            }
                        }
                        else
                        {
                            bool isCreated = maintenances.CreateMaintenance(ClinicMaintenance);
                            if (isCreated)
                            {
                                MessageBox.Show("Maintenance is created.", "Notification", MessageBoxButton.OK);
                                maintenanceView.Close();
                            }
                            else
                            {
                                MessageBox.Show("Maintenance cannot be created.", "Notification", MessageBoxButton.OK);
                            }
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
            return true;
        }

        public void CancelExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel creating the maintenance?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
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