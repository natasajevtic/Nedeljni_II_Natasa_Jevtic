using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class EditMasterCredentialsViewModel : BaseViewModel
    {
        EditMasterCredentialsView credentialsView;

        private string username;

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }       

        private string newPassword;

        public string NewPassword
        {
            get
            {
                return newPassword;
            }
            set
            {
                newPassword = value;
                OnPropertyChanged("NewPassword");
            }
        }

        private ICommand save;

        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(SaveExecute, CanSaveExecute);
                }
                return save;
            }
        }       

        public EditMasterCredentialsViewModel(EditMasterCredentialsView credentialsView, string oldUsername, string oldPassword)
        {
            this.credentialsView = credentialsView;
            Username = oldUsername;
            credentialsView.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// This methods invokes a method for changing credentials of master accouny.
        /// </summary>
        /// <param name="passwords"></param>
        public void SaveExecute(object passwords)
        {
            NewPassword = (passwords as PasswordBox).Password;
            ChangeMasterCredentials();
            MessageBox.Show("Credentials are changed.", "Notification", MessageBoxButton.OK);
        }
        /// <summary>
        /// This method ensures that the login can only be executed when the login fields are not empty.
        /// </summary>
        /// <param name="password">User input for password.</param>
        /// <returns>True if login can execute, false if not.</returns>
        public bool CanSaveExecute(object passwords)
        {            
            NewPassword = (passwords as PasswordBox).Password;
            if (!String.IsNullOrEmpty(NewPassword) && !String.IsNullOrEmpty(NewPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// This method writes new credentials to txt file.
        /// </summary>
        public void ChangeMasterCredentials()
        {
            string source = @"../../ClinicAccess.txt";
            StreamWriter str = new StreamWriter(source);
            string output = String.Format("Username:{0}\nPassword:{1}", Username, NewPassword);
            str.Write(output);
            str.Close();
        }        
    }
}
