using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class AddDoctorViewModel : BaseViewModel
    {
        AddDoctorView doctorView;
        Genders genders = new Genders();
        Doctors doctors = new Doctors();
        Shifts shifts = new Shifts();
        Managers managers = new Managers();

        private vwClinicDoctor clinicDoctor;

        public vwClinicDoctor ClinicDoctor
        {
            get
            {
                return clinicDoctor;
            }
            set
            {
                clinicDoctor = value;
                OnPropertyChanged("ClinicDoctor");
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

        private List<string> shiftList;

        public List<string> ShiftList
        {
            get
            {
                return shiftList;
            }
            set
            {
                shiftList = value;
                OnPropertyChanged("ShiftList");
            }
        }

        private vwClinicManager manager;

        public vwClinicManager Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }

        private List<vwClinicManager> managerList;

        public List<vwClinicManager> ManagerList
        {
            get
            {
                return managerList;
            }
            set
            {
                managerList = value;
                OnPropertyChanged("ManagerList");
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

        public AddDoctorViewModel(AddDoctorView doctorView)
        {
            this.doctorView = doctorView;
            ClinicDoctor = new vwClinicDoctor();
            GenderList = genders.GetGenders();
            ShiftList = shifts.GetShifts();
            ManagerList = managers.ManagersWhoCanSupervise();
        }

        public void SaveExecute()
        {
            if (String.IsNullOrEmpty(ClinicDoctor.NameAndSurname) || String.IsNullOrEmpty(ClinicDoctor.IdentityCardNumber) || String.IsNullOrEmpty(ClinicDoctor.DateOfBirth.ToString()) || String.IsNullOrEmpty(ClinicDoctor.Gender)
               || String.IsNullOrEmpty(ClinicDoctor.Citizenship) || String.IsNullOrEmpty(ClinicDoctor.Username) || String.IsNullOrEmpty(ClinicDoctor.Password) || String.IsNullOrEmpty(ClinicDoctor.UniqueNumber) ||
               String.IsNullOrEmpty(ClinicDoctor.BankAccountNumber) || String.IsNullOrEmpty(ClinicDoctor.Department) || String.IsNullOrEmpty(ClinicDoctor.Shift))
            {
                MessageBox.Show("Please fill all fields.", "Notification");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to save the doctor?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        if (Manager != null)
                        {
                            ClinicDoctor.SuperiorManager = Convert.ToInt32(Manager.ManagerId);
                        }
                        bool isCreated = doctors.CreateDoctor(ClinicDoctor);
                        if (isCreated)
                        {
                            MessageBox.Show("Doctor is created.", "Notification", MessageBoxButton.OK);
                            doctorView.Close();
                        }
                        else
                        {
                            MessageBox.Show("Doctor cannot be created.", "Notification", MessageBoxButton.OK);
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
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel creating the doctor?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    doctorView.Close();
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