using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class AddAdministratorViewModel : BaseViewModel
    {
        AddAdministratorView administratorView;
        Genders genders = new Genders();
        Administrators administrators = new Administrators();

        private vwClinicAdministrator clinicAdministrator;

        public vwClinicAdministrator ClinicAdministrator
        {
            get
            {
                return clinicAdministrator;
            }
            set
            {
                clinicAdministrator = value;
                OnPropertyChanged("ClinicAdministrator");
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

        private ICommand saveAdministrator;
        public ICommand SaveAdministrator
        {
            get
            {
                if (saveAdministrator == null)
                {
                    saveAdministrator = new RelayCommand(param => SaveAdministratorExecute(), param => CanSaveAdministratorExecute());
                }
                return saveAdministrator;
            }
        }

        private ICommand cancelAdministrator;
        public ICommand CancelAdministrator
        {
            get
            {
                if (cancelAdministrator == null)
                {
                    cancelAdministrator = new RelayCommand(param => CancelAdministratorExecute(), param => CanCancelAdministratorExecute());
                }
                return cancelAdministrator;
            }
        }

        public AddAdministratorViewModel(AddAdministratorView administratorView)
        {
            this.administratorView = administratorView;
            ClinicAdministrator = new vwClinicAdministrator();
            GenderList = genders.GetGenders();
        }

        public void SaveAdministratorExecute()
        {
            if (String.IsNullOrEmpty(ClinicAdministrator.NameAndSurname) || String.IsNullOrEmpty(ClinicAdministrator.IdentityCardNumber) || String.IsNullOrEmpty(ClinicAdministrator.DateOfBirth.ToString()) || String.IsNullOrEmpty(ClinicAdministrator.Gender)
               || String.IsNullOrEmpty(ClinicAdministrator.Citizenship) || String.IsNullOrEmpty(ClinicAdministrator.Username) || String.IsNullOrEmpty(ClinicAdministrator.Password))
            {
                MessageBox.Show("Please fill all fields.", "Notification");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to save the administrator?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isCreated = administrators.CreateAdministrator(ClinicAdministrator);
                        if (isCreated)
                        {
                            MessageBox.Show("Administrator is created.", "Notification", MessageBoxButton.OK);
                            administratorView.Close();
                        }
                        else
                        {
                            MessageBox.Show("Administrator cannot be created.", "Notification", MessageBoxButton.OK);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public bool CanSaveAdministratorExecute()
        {
            return true;
        }

        public void CancelAdministratorExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel creating the administrator?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    administratorView.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanCancelAdministratorExecute()
        {
            return true;
        }
    }
}