using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        MainWindow main;
        delegate void Finder();
        event Finder OnFinder;
        Users users = new Users();
        Clinic clinic = new Clinic();
        public vwClinicAdministrator Administrator { get; set; }
        public vwClinicMaintenance Maintenance { get; set; }
        public vwClinicManager Manager { get; set; }
        public vwClinicDoctor Doctor { get; set; }
        public vwClinicPatient Patient { get; set; }

        string MasterUsername { get; set; }
        string MasterPassword { get; set; }

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

        private string password;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private ICommand logIn;

        public ICommand LogIn
        {
            get
            {
                if (logIn == null)
                {
                    logIn = new RelayCommand(LogInExecute, CanLogInExecute);
                }
                return logIn;
            }
        }

        public MainWindowViewModel(MainWindow main)
        {
            this.main = main;
            OnFinder += GetMasterUsernameAndPassword;
            OnFinder();
        }
        /// <summary>
        /// This method checks if username and password valid.
        /// </summary>
        /// <param name="password">User input for password.</param>
        public void LogInExecute(object password)
        {
            Password = (password as PasswordBox).Password;
            if (Username == MasterUsername && Password == MasterPassword)
            {
                MasterView masterView = new MasterView(Username,Password);
                masterView.ShowDialog();
            }
            else if (users.FindAdministrator(Username, Password) != null)
            {
                Administrator = users.FindAdministrator(Username, Password);
                if (clinic.CheckIfClinicExists())
                {
                    AdministratorView administratorView = new AdministratorView();
                    administratorView.ShowDialog();
                }
                else
                {
                    CreateClinicView clinicView = new CreateClinicView();
                    clinicView.ShowDialog();
                }
            }
            else if (users.FindMaintenance(Username, Password) != null)
            {
                Maintenance = users.FindMaintenance(Username, Password);
                MaintenanceView maintenanceView = new MaintenanceView(Maintenance);
                maintenanceView.ShowDialog();
            }
            else if (users.FindManager(Username, Password) != null)
            {
                Manager = users.FindManager(Username, Password);
                ManagerView managerView = new ManagerView();
                managerView.ShowDialog();
            }
            else if (users.FindDoctor(Username, Password) != null)
            {
                Doctor = users.FindDoctor(Username, Password);
                DoctorView doctorView = new DoctorView();
                doctorView.ShowDialog();
            }
            else if (users.FindPatient(Username, Password) != null)
            {
                Patient = users.FindPatient(Username, Password);
                PatientView patientView = new PatientView();
                patientView.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong username or password. Please, try again.", "Notification");
            }
        }
        /// <summary>
        /// This method ensures that the login can only be executed when the login fields are not empty.
        /// </summary>
        /// <param name="password">User input for password.</param>
        /// <returns>True if login can execute, false if not.</returns>
        public bool CanLogInExecute(object password)
        {
            Password = (password as PasswordBox).Password;
            if (!String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void GetMasterUsernameAndPassword()
        {
            string source = @"../../ClinicAccess.txt";
            if (File.Exists(source))
            {
                string[] lines = File.ReadAllLines(source);
                string[] firstLine = lines[0].Split(':');
                MasterUsername = firstLine[1];
                string[] secondLine = lines[1].Split(':');
                MasterPassword = secondLine[1];
            }
        }
    }
}
