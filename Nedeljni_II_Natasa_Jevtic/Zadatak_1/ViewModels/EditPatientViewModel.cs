using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class EditPatientViewModel : BaseViewModel
    {
        EditPatientView patientView;
        Genders genders = new Genders();
        Doctors doctors = new Doctors();
        Patients patients = new Patients();

        public vwClinicPatient OldPatient { get; set; }

        private vwClinicPatient clinicPatient;

        public vwClinicPatient ClinicPatient
        {
            get
            {
                return clinicPatient;
            }
            set
            {
                clinicPatient = value;
                OnPropertyChanged("ClinicPatient");
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

        private vwClinicDoctor doctor;

        public vwClinicDoctor Doctor
        {
            get
            {
                return doctor;
            }
            set
            {
                doctor = value;
                OnPropertyChanged("Doctor");
            }
        }

        private List<vwClinicDoctor> doctorList;

        public List<vwClinicDoctor> DoctorList
        {
            get
            {
                return doctorList;
            }
            set
            {
                doctorList = value;
                OnPropertyChanged("DoctorList");
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

        public EditPatientViewModel(EditPatientView patientView, vwClinicPatient patientToEdit)
        {
            this.patientView = patientView;
            ClinicPatient = patientToEdit;
            GenderList = genders.GetGenders();
            DoctorList = doctors.ViewAllDoctors();
            OldPatient = new vwClinicPatient
            {
                Citizenship = patientToEdit.Citizenship,
                DateOfBirth = patientToEdit.DateOfBirth,
                Gender = patientToEdit.Gender,
                IdentityCardNumber = patientToEdit.IdentityCardNumber,
                NameAndSurname = patientToEdit.NameAndSurname,
                Password = patientToEdit.Password,
                Username = patientToEdit.Username,
                ExpirationDateOfHealthInsurance = patientToEdit.ExpirationDateOfHealthInsurance,
                HealthInsuranceCardNumber = patientToEdit.HealthInsuranceCardNumber,
                UniqueNumberOfSelectedDoctor = patientToEdit.UniqueNumberOfSelectedDoctor
            };
        }

        public void SaveExecute()
        {
            if (String.IsNullOrEmpty(ClinicPatient.NameAndSurname) || String.IsNullOrEmpty(ClinicPatient.IdentityCardNumber) || String.IsNullOrEmpty(ClinicPatient.DateOfBirth.ToString()) || String.IsNullOrEmpty(ClinicPatient.Gender)
               || String.IsNullOrEmpty(ClinicPatient.Citizenship) || String.IsNullOrEmpty(ClinicPatient.Username) || String.IsNullOrEmpty(ClinicPatient.Password) || String.IsNullOrEmpty(ClinicPatient.HealthInsuranceCardNumber) ||
               String.IsNullOrEmpty(ClinicPatient.ExpirationDateOfHealthInsurance.ToString()) || String.IsNullOrEmpty(ClinicPatient.UniqueNumberOfSelectedDoctor))
            {
                MessageBox.Show("Please fill all fields.", "Notification");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to edit the patient?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {                        
                        bool isEdited = patients.EditPatient(ClinicPatient);
                        if (isEdited)
                        {
                            MessageBox.Show("Patient is edited.", "Notification", MessageBoxButton.OK);
                            patientView.Close();
                        }
                        else
                        {
                            MessageBox.Show("Patient cannot be edited.", "Notification", MessageBoxButton.OK);
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
            if (ClinicPatient.NameAndSurname != OldPatient.NameAndSurname || ClinicPatient.IdentityCardNumber != OldPatient.IdentityCardNumber ||
                ClinicPatient.Gender != OldPatient.Gender || ClinicPatient.DateOfBirth != OldPatient.DateOfBirth || ClinicPatient.Citizenship != OldPatient.Citizenship
                || ClinicPatient.Username != OldPatient.Username || ClinicPatient.Password != OldPatient.Password || ClinicPatient.UniqueNumberOfSelectedDoctor != OldPatient.UniqueNumberOfSelectedDoctor ||
                ClinicPatient.HealthInsuranceCardNumber != OldPatient.HealthInsuranceCardNumber || ClinicPatient.ExpirationDateOfHealthInsurance != OldPatient.ExpirationDateOfHealthInsurance 
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
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel editing the patient?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    patientView.Close();
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


