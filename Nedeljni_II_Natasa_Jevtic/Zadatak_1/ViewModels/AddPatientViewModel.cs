using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class AddPatientViewModel : BaseViewModel
    {
        AddPatientView patientView;
        Genders genders = new Genders();
        Doctors doctors = new Doctors();
        Patients patients = new Patients();

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

        public AddPatientViewModel(AddPatientView patientView)
        {
            this.patientView = patientView;
            ClinicPatient = new vwClinicPatient();
            GenderList = genders.GetGenders();
            DoctorList = doctors.ViewAllDoctors();
        }

        public void SaveExecute()
        {
            if (String.IsNullOrEmpty(ClinicPatient.NameAndSurname) || String.IsNullOrEmpty(ClinicPatient.IdentityCardNumber) || String.IsNullOrEmpty(ClinicPatient.DateOfBirth.ToString()) || String.IsNullOrEmpty(ClinicPatient.Gender)
               || String.IsNullOrEmpty(ClinicPatient.Citizenship) || String.IsNullOrEmpty(ClinicPatient.Username) || String.IsNullOrEmpty(ClinicPatient.Password) || String.IsNullOrEmpty(ClinicPatient.HealthInsuranceCardNumber) ||
               String.IsNullOrEmpty(ClinicPatient.ExpirationDateOfHealthInsurance.ToString()) || String.IsNullOrEmpty(ClinicPatient.UniqueNumberOfSelectedDoctor) || ClinicPatient.ExpirationDateOfHealthInsurance!= default(DateTime).Date)
            {
                MessageBox.Show("Please fill all fields.", "Notification");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to save the patient?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {                        
                        bool isCreated = patients.CreatePatient(ClinicPatient);
                        if (isCreated)
                        {
                            MessageBox.Show("Patient is created.", "Notification", MessageBoxButton.OK);
                            patientView.Close();
                        }
                        else
                        {
                            MessageBox.Show("Patient cannot be created.", "Notification", MessageBoxButton.OK);
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
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel creating the patient?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
