using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class EditDoctorViewModel : BaseViewModel
    {
        EditDoctorView doctorView;
        Genders genders = new Genders();
        Managers managers = new Managers();
        Doctors doctors = new Doctors();
        Shifts shifts = new Shifts();

        public vwClinicDoctor OldDoctor { get; set; }

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

        public EditDoctorViewModel(EditDoctorView doctorView, vwClinicDoctor doctorToEdit)
        {
            this.doctorView = doctorView;
            ClinicDoctor = doctorToEdit;
            GenderList = genders.GetGenders();
            ShiftList = shifts.GetShifts();
            ManagerList = managers.ManagersWhoCanSupervise();
            OldDoctor = new vwClinicDoctor
            {
                Citizenship = doctorToEdit.Citizenship,
                DateOfBirth = doctorToEdit.DateOfBirth,
                Gender = doctorToEdit.Gender,
                IdentityCardNumber = doctorToEdit.IdentityCardNumber,
                NameAndSurname = doctorToEdit.NameAndSurname,
                Password = doctorToEdit.Password,
                Username = doctorToEdit.Username,
                BankAccountNumber = doctorToEdit.BankAccountNumber,
                Department = doctorToEdit.Department,
                ResponsibleForPatientAdmission = doctorToEdit.ResponsibleForPatientAdmission,
                Shift = doctorToEdit.Shift,
                SuperiorManager = doctorToEdit.SuperiorManager,
                UniqueNumber = doctorToEdit.UniqueNumber,
                Manager = doctorToEdit.Manager                
            };
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
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to edit the doctor?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        if (Manager != null)
                        {
                            ClinicDoctor.SuperiorManager = Convert.ToInt32(Manager.ManagerId);
                        }
                        bool isEdited = doctors.EditDoctor(ClinicDoctor);
                        if (isEdited)
                        {
                            MessageBox.Show("Doctor is edited.", "Notification", MessageBoxButton.OK);
                            doctorView.Close();
                        }
                        else
                        {
                            MessageBox.Show("Doctor cannot be edited.", "Notification", MessageBoxButton.OK);
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
            if (ClinicDoctor.NameAndSurname != OldDoctor.NameAndSurname || ClinicDoctor.IdentityCardNumber != OldDoctor.IdentityCardNumber ||
                ClinicDoctor.Gender != OldDoctor.Gender || ClinicDoctor.DateOfBirth != OldDoctor.DateOfBirth || ClinicDoctor.Citizenship != OldDoctor.Citizenship
                || ClinicDoctor.Username != OldDoctor.Username || ClinicDoctor.Password != OldDoctor.Password || ClinicDoctor.UniqueNumber != OldDoctor.UniqueNumber ||
                ClinicDoctor.BankAccountNumber != OldDoctor.BankAccountNumber || ClinicDoctor.Department != OldDoctor.Department || ClinicDoctor.Shift != OldDoctor.Shift
                || ClinicDoctor.ResponsibleForPatientAdmission != OldDoctor.ResponsibleForPatientAdmission
                || ClinicDoctor.Manager != OldDoctor.Manager
                )
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
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel editing the doctor?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
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

