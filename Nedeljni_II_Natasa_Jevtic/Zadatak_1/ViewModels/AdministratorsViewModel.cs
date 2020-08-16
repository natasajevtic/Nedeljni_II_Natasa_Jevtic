using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class AdministratorsViewModel : BaseViewModel
    {
        AdministratorsView administratorsView;
        Administrators administrators = new Administrators();

        private vwClinicAdministrator administrator;

        public vwClinicAdministrator Administrator
        {
            get
            {
                return administrator;
            }
            set
            {
                administrator = value;
                OnPropertyChanged("Administrator");
            }
        }

        private List<vwClinicAdministrator> administratorList;

        public List<vwClinicAdministrator> AdministratorList
        {
            get
            {
                return administratorList;
            }
            set
            {
                administratorList = value;
                OnPropertyChanged("AdministratorList");
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

        public AdministratorsViewModel(AdministratorsView administratorsView)
        {
            this.administratorsView = administratorsView;
            AdministratorList = administrators.ViewAdministrator();
        }
        /// <summary>
        /// This method invokes method for opening a window for adding administrator.
        /// </summary>
        public void AddExecute()
        {
            try
            {
                AddAdministratorView form = new AddAdministratorView();
                form.ShowDialog();
                AdministratorList = administrators.ViewAdministrator();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// This method checks if any administrator exists.
        /// </summary>
        /// <returns>False if exists, true if exists.</returns>
        public bool CanAddExecute()
        {
            if (administrators.CheckIfAdministratorExists())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
