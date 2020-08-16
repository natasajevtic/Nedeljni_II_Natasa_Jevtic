using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class AddManagerViewModel : BaseViewModel
    {
        AddManagerView managerView;
        Genders genders = new Genders();
        Managers managers = new Managers();

        private vwClinicManager clinicManager;

        public vwClinicManager ClinicManager
        {
            get
            {
                return clinicManager;
            }
            set
            {
                clinicManager = value;
                OnPropertyChanged("ClinicManager");
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

        public AddManagerViewModel(AddManagerView managerView)
        {
            this.managerView = managerView;
            ClinicManager = new vwClinicManager();
            GenderList = genders.GetGenders();
        }

        public void SaveExecute()
        {
            if (String.IsNullOrEmpty(ClinicManager.NameAndSurname) || String.IsNullOrEmpty(ClinicManager.IdentityCardNumber) || String.IsNullOrEmpty(ClinicManager.DateOfBirth.ToString()) || String.IsNullOrEmpty(ClinicManager.Gender)
               || String.IsNullOrEmpty(ClinicManager.Citizenship) || String.IsNullOrEmpty(ClinicManager.Username) || String.IsNullOrEmpty(ClinicManager.Password) || String.IsNullOrEmpty(ClinicManager.Floor.ToString()) ||
               String.IsNullOrEmpty(ClinicManager.MaximumNumberOfSupervisedDoctors.ToString()) || String.IsNullOrEmpty(ClinicManager.MinimumNumberOfSupervisedRooms.ToString()))
            {
                MessageBox.Show("Please fill all fields.", "Notification");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to save the manager?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isCreated = managers.CreateManager(ClinicManager);
                        if (isCreated)
                        {
                            MessageBox.Show("Manager is created.", "Notification", MessageBoxButton.OK);
                            managerView.Close();
                        }
                        else
                        {
                            MessageBox.Show("Manager cannot be created.", "Notification", MessageBoxButton.OK);
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
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel creating the manager?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    managerView.Close();
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
