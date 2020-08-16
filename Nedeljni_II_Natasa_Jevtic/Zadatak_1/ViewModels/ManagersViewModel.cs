using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class ManagersViewModel : BaseViewModel
    {
        ManagersView managersView;
        Managers managers = new Managers();
        Administrators administrators = new Administrators();

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

        public ManagersViewModel(ManagersView managersView)
        {
            this.managersView = managersView;
            ManagerList = managers.ViewAllManager();
        }
        /// <summary>
        /// This method invokes method for opening a window for adding manager.
        /// </summary>
        public void AddExecute()
        {
            try
            {
                AddManagerView form = new AddManagerView();
                form.ShowDialog();
                ManagerList = managers.ViewAllManager();
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
                if (Manager != null)
                {
                    ManagerEditFormView form = new ManagerEditFormView(Manager);
                    form.ShowDialog();
                    ManagerList = managers.ViewAllManager();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public bool CanEditExecute()
        {
            if (Manager != null)
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
                if (Manager != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this manager?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isDeleted = managers.DeleteManager(Manager);

                        if (isDeleted == true)
                        {
                            MessageBox.Show("Manager is deleted.", "Notification", MessageBoxButton.OK);
                            ManagerList = managers.ViewAllManager();
                        }
                        else
                        {
                            MessageBox.Show("Manager cannot be deleted.", "Notification", MessageBoxButton.OK);
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
            if (Manager != null)
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

