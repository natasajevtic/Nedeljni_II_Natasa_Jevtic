using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class DoctorsViewModel : BaseViewModel
    {
        DoctorsView doctorsView;
        Doctors doctors = new Doctors();

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

        public DoctorsViewModel(DoctorsView doctorsView)
        {
            this.doctorsView = doctorsView;
            DoctorList = doctors.ViewAllDoctors();
        }
        /// <summary>
        /// This method invokes method for opening a window for adding doctor.
        /// </summary>
        public void AddExecute()
        {
            try
            {
                AddDoctorView form = new AddDoctorView();
                form.ShowDialog();
                DoctorList = doctors.ViewAllDoctors();
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
                if (Doctor != null)
                {
                    EditDoctorView form = new EditDoctorView(Doctor);
                    form.ShowDialog();
                    DoctorList = doctors.ViewAllDoctors();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public bool CanEditExecute()
        {
            if (Doctor != null)
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
