using System;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class EditClinicViewModel : BaseViewModel
    {
        EditClinicView clinicView;
        Clinic clinics = new Clinic();
        public vwClinic OldClinic { get; set; }

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

        public EditClinicViewModel(EditClinicView clinicView)
        {
            this.clinicView = clinicView;
            vwClinic existingClinic = clinics.ViewClinic();
            Clinic = existingClinic;
            OldClinic = new vwClinic
            {
                Owner = existingClinic.Owner,
                NumberOfAccessPointsForAmbulanceCars = existingClinic.NumberOfAccessPointsForAmbulanceCars,
                NumberOfAccessPointsForInvalids = existingClinic.NumberOfAccessPointsForInvalids
            };
        }

        public void SaveExecute()
        {
            if (String.IsNullOrEmpty(Clinic.Owner) || String.IsNullOrEmpty(Clinic.NumberOfAccessPointsForAmbulanceCars.ToString()) ||
                  String.IsNullOrEmpty(Clinic.NumberOfAccessPointsForInvalids.ToString()))
            {
                MessageBox.Show("Please fill all fields.", "Notification");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to save changes?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isEdited = clinics.EditClinic(Clinic);
                        if (isEdited == true)
                        {
                            MessageBox.Show("Clinic is edited.", "Notification", MessageBoxButton.OK);                            
                        }
                        else
                        {
                            MessageBox.Show("Clinic cannot be edited.", "Notification", MessageBoxButton.OK);                            
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
            if (Clinic.Owner != OldClinic.Owner || Clinic.NumberOfAccessPointsForAmbulanceCars != OldClinic.NumberOfAccessPointsForAmbulanceCars ||
                Clinic.NumberOfAccessPointsForInvalids != OldClinic.NumberOfAccessPointsForInvalids)
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

