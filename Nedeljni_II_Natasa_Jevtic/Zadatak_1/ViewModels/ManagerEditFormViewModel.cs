using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class ManagerEditFormViewModel : BaseViewModel
    {
        ManagerEditFormView managerView;
        Genders genders = new Genders();
        Managers managers = new Managers();

        public vwClinicManager OldManager { get; set; }

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

        public ManagerEditFormViewModel(ManagerEditFormView managerView, vwClinicManager managerToEdit)
        {
            this.managerView = managerView;
            ClinicManager = managerToEdit;
            GenderList = genders.GetGenders();
            OldManager = new vwClinicManager
            {
                Citizenship = managerToEdit.Citizenship,
                DateOfBirth = managerToEdit.DateOfBirth,
                Gender = managerToEdit.Gender,
                IdentityCardNumber = managerToEdit.IdentityCardNumber,
                NameAndSurname = managerToEdit.NameAndSurname,
                Password = managerToEdit.Password,
                Username = managerToEdit.Username,
                Floor = managerToEdit.Floor,
                MaximumNumberOfSupervisedDoctors = managerToEdit.MaximumNumberOfSupervisedDoctors,
                MinimumNumberOfSupervisedRooms = managerToEdit.MinimumNumberOfSupervisedRooms,
                NumberOfOmissions = managerToEdit.NumberOfOmissions
            };
        }

        public void SaveExecute()
        {
            if (String.IsNullOrEmpty(ClinicManager.NameAndSurname) || String.IsNullOrEmpty(ClinicManager.IdentityCardNumber) || String.IsNullOrEmpty(ClinicManager.DateOfBirth.ToString()) || String.IsNullOrEmpty(ClinicManager.Gender)
               || String.IsNullOrEmpty(ClinicManager.Citizenship) || String.IsNullOrEmpty(ClinicManager.Username) || String.IsNullOrEmpty(ClinicManager.Password) || String.IsNullOrEmpty(ClinicManager.NumberOfOmissions.ToString())
               || String.IsNullOrEmpty(ClinicManager.MaximumNumberOfSupervisedDoctors.ToString()) || String.IsNullOrEmpty(ClinicManager.MinimumNumberOfSupervisedRooms.ToString()) ||
               String.IsNullOrEmpty(ClinicManager.Floor.ToString()))
            {
                MessageBox.Show("Please fill all fields.", "Notification");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to edit the manager?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isEdited = managers.EditManager(ClinicManager);
                        if (isEdited)
                        {
                            MessageBox.Show("Manager is edited.", "Notification", MessageBoxButton.OK);
                            managerView.Close();
                        }
                        else
                        {
                            MessageBox.Show("Manager cannot be edited.", "Notification", MessageBoxButton.OK);
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
            if (ClinicManager.NameAndSurname != OldManager.NameAndSurname || ClinicManager.IdentityCardNumber != OldManager.IdentityCardNumber ||
                ClinicManager.Gender != OldManager.Gender || ClinicManager.DateOfBirth != OldManager.DateOfBirth || ClinicManager.Citizenship != OldManager.Citizenship
                || ClinicManager.Username != OldManager.Username || ClinicManager.Password != OldManager.Password || ClinicManager.Floor != OldManager.Floor ||
                ClinicManager.MaximumNumberOfSupervisedDoctors != OldManager.MaximumNumberOfSupervisedDoctors || ClinicManager.MinimumNumberOfSupervisedRooms != OldManager.MinimumNumberOfSupervisedRooms
                || ClinicManager.NumberOfOmissions != OldManager.NumberOfOmissions)
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
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel editing the manager?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
