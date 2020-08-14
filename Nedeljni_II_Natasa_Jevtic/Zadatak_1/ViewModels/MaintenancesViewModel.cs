using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class MaintenancesViewModel : BaseViewModel
    {
        MaintenancesView maintenancesView;
        Maintenances maintenances = new Maintenances();

        private vwClinicMaintenance maintenance;

        public vwClinicMaintenance Maintenance
        {
            get
            {
                return maintenance;
            }
            set
            {
                maintenance = value;
                OnPropertyChanged("Maintenance");
            }
        }

        private List<vwClinicMaintenance> maintenanceList;

        public List<vwClinicMaintenance> MaintenanceList
        {
            get
            {
                return maintenanceList;
            }
            set
            {
                maintenanceList = value;
                OnPropertyChanged("MaintenanceList");
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

        public MaintenancesViewModel(MaintenancesView maintenancesView)
        {
            this.maintenancesView = maintenancesView;
            MaintenanceList = maintenances.ViewAllMaintenances();
        }

        public void AddExecute()
        {
            try
            {
                MaintenanceAddFormView form = new MaintenanceAddFormView();
                form.ShowDialog();
                MaintenanceList = maintenances.ViewAllMaintenances();
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
                if (Maintenance != null)
                {
                    MaintenanceEditFormView form = new MaintenanceEditFormView(Maintenance);
                    form.ShowDialog();
                    MaintenanceList = maintenances.ViewAllMaintenances();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public bool CanEditExecute()
        {
            if (Maintenance != null)
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
                if (Maintenance != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this maintenance?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isDeleted = maintenances.DeleteMaintenance(Maintenance);

                        if (isDeleted == true)
                        {
                            MessageBox.Show("Maintenance is deleted.", "Notification", MessageBoxButton.OK);
                            MaintenanceList = maintenances.ViewAllMaintenances();
                        }
                        else
                        {
                            MessageBox.Show("Maintenance cannot be deleted.", "Notification", MessageBoxButton.OK);
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
            if (Maintenance != null)
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