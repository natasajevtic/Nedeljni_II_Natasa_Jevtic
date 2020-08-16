using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for AdministratorView.xaml
    /// </summary>
    public partial class AdministratorView : Window
    {
        public AdministratorView()
        {
            InitializeComponent();
            this.DataContext = new AdministratorViewModel(this);

            var menuClinic = new List<SubItem>();
            menuClinic.Add(new SubItem("Edit clinic", new EditClinicView()));
            var item1 = new ItemMenu("Clinic", menuClinic, PackIconKind.Hospital);

            var menuMaintenance = new List<SubItem>();
            menuMaintenance.Add(new SubItem("View all maintenances", new MaintenancesView()));
            var item2 = new ItemMenu("Maintenances", menuMaintenance, PackIconKind.PeopleGroupOutline);

            var menuManagers = new List<SubItem>();
            menuManagers.Add(new SubItem("View all managers", new ManagersView()));
            var item3 = new ItemMenu("Managers", menuManagers, PackIconKind.PeopleGroupOutline);

            var menuDoctors = new List<SubItem>();
            menuDoctors.Add(new SubItem("View all doctors", new DoctorsView()));
            var item4 = new ItemMenu("Doctors", menuDoctors, PackIconKind.PeopleGroupOutline);

            var menuPatients = new List<SubItem>();
            menuPatients.Add(new SubItem("View all patients", new PatientsView()));
            var item5 = new ItemMenu("Patients", menuPatients, PackIconKind.PeopleGroupOutline);

            var item0 = new ItemMenu("", new UserControl(), PackIconKind.ViewDashboard);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            Menu.Children.Add(new UserControlMenuItem(item4, this));
            Menu.Children.Add(new UserControlMenuItem(item5, this));
        }

        public void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);
            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);

                if (screen.Name == "EditClinic")
                {
                    AddAdministratorView administratorsView = new AddAdministratorView();
                }
                else if (screen.Name == "Maintenances")
                {
                    MaintenancesView maintenancesView = new MaintenancesView();
                }
                else if (screen.Name == "Managers")
                {
                    ManagersView managersView = new ManagersView();
                }
                else if (screen.Name == "Doctors")
                {
                    DoctorsView doctorsView = new DoctorsView();
                }
                else if (screen.Name == "Patients")
                {
                    PatientsView patientsView = new PatientsView();
                }
            }
        }
    }
}

