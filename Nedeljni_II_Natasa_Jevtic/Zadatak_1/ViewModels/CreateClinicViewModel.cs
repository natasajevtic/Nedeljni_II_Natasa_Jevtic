using System;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class CreateClinicViewModel : BaseViewModel
    {
        CreateClinicView clinicView;
        Clinic newClinic = new Clinic();

        private vwClinic clinic;

        public vwClinic Clinic
        {
            get
            {
                return clinic;
            }
            set
            {
                clinic = value;
                OnPropertyChanged("Clinic");
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

        public CreateClinicViewModel(CreateClinicView clinicView)
        {
            this.clinicView = clinicView;
            Clinic = new vwClinic();
        }

        public bool CanSaveExecute()
        {
            return true;
        }

        public void SaveExecute()
        {
            if (String.IsNullOrEmpty(Clinic.Name) || String.IsNullOrEmpty(Clinic.DateOfConstruction.ToString()) || String.IsNullOrEmpty(Clinic.Owner) || String.IsNullOrEmpty(Clinic.Address)
              || String.IsNullOrEmpty(Clinic.NumberOfFloors.ToString()) || String.IsNullOrEmpty(Clinic.NumberOfRoomsPerFloor.ToString()) || String.IsNullOrEmpty(Clinic.Terrace.ToString()) ||
                    String.IsNullOrEmpty(Clinic.Yard.ToString()) || String.IsNullOrEmpty(Clinic.NumberOfAccessPointsForAmbulanceCars.ToString()) || String.IsNullOrEmpty(Clinic.NumberOfAccessPointsForInvalids.ToString())
                    || Clinic.NumberOfRoomsPerFloor==0)
            {
                MessageBox.Show("Please fill all fields.", "Notification");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to save the clinic?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isCreated = newClinic.CreateClinic(Clinic);
                        if (isCreated)
                        {
                            MessageBox.Show("Clinic is created.", "Notification", MessageBoxButton.OK);
                            clinicView.Close();
                            AdministratorView adminView = new AdministratorView();
                            adminView.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Clinic cannot be created.", "Notification", MessageBoxButton.OK);
                            clinicView.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public void CancelExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel creating clinic?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    clinicView.Close();
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