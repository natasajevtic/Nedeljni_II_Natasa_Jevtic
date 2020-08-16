using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class PatientsViewModel : BaseViewModel
    {
        PatientsView patientsView;
        Patients patients = new Patients();
        Doctors doctors = new Doctors();

        private vwClinicPatient patient;

        public vwClinicPatient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                patient = value;
                OnPropertyChanged("Patient");
            }
        }

        private List<vwClinicPatient> patientList;

        public List<vwClinicPatient> PatientList
        {
            get
            {
                return patientList;
            }
            set
            {
                patientList = value;
                OnPropertyChanged("PatientList");
            }
        }

        private ICommand add;
        public ICommand Add
        {
            get
            {
                if (add == null)
                {
                    add = new RelayCommand(param => AddExecute(), param => CanAddExecute());
                }
                return add;
            }
        }

        private ICommand edit;
        public ICommand Edit
        {
            get
            {
                if (edit == null)
                {
                    edit = new RelayCommand(param => EditExecute(), param => CanEditExecute());
                }
                return edit;
            }
        }

        private ICommand delete;
        public ICommand Delete
        {
            get
            {
                if (delete == null)
                {
                    delete = new RelayCommand(param => DeleteExecute(), param => CanDeleteExecute());
                }
                return delete;
            }
        }

        public PatientsViewModel(PatientsView patientsView)
        {
            this.patientsView = patientsView;
            PatientList = patients.ViewAllPatients();
        }
        /// <summary>
        /// This method invokes method for opening a window for adding patient.
        /// </summary>
        public void AddExecute()
        {
            try
            {
                if (doctors.CheckIfDoctorExists())
                {
                    AddPatientView form = new AddPatientView();
                    form.ShowDialog();
                    PatientList = patients.ViewAllPatients();
                }
                else
                {
                    MessageBox.Show("Please first create a doctor.", "Notification", MessageBoxButton.OK);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanAddExecute()
        {
            return true;
        }

        public void EditExecute()
        {
            try
            {
                if (Patient != null)
                {
                    EditPatientView form = new EditPatientView(Patient);
                    form.ShowDialog();
                    PatientList = patients.ViewAllPatients();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public bool CanEditExecute()
        {
            if (Patient != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteExecute()
        {
            try
            {
                if (Patient != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this patient?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isDeleted = patients.DeletePatient(Patient);

                        if (isDeleted == true)
                        {
                            MessageBox.Show("Patient is deleted.", "Notification", MessageBoxButton.OK);
                            PatientList = patients.ViewAllPatients();
                        }
                        else
                        {
                            MessageBox.Show("Patient cannot be deleted.", "Notification", MessageBoxButton.OK);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public bool CanDeleteExecute()
        {
            if (Patient != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

