using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for MasterView.xaml
    /// </summary>
    public partial class MasterView : Window
    {
        string Username { get; set; }
        string Password { get; set; }

        public MasterView(string username, string password)
        {
            InitializeComponent();
            Username = username;
            Password = password;
            this.DataContext = new MasterViewModel(this, username, password);

            var menuAdministrator = new List<SubItem>();
            menuAdministrator.Add(new SubItem("View administrator", new AdministratorsView()));
            var item1 = new ItemMenu("Administrator", menuAdministrator, PackIconKind.Person);

            var menuMaster = new List<SubItem>();
            menuMaster.Add(new SubItem("Change credentials", new EditMasterCredentialsView()));
            var item2 = new ItemMenu("My account", menuMaster, PackIconKind.Person);

            var item0 = new ItemMenu("", new UserControl(), PackIconKind.ViewDashboard);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
        }

        public void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);
            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);

                if (screen.Name == "Administrators")
                {
                    AdministratorsView administratorsView = new AdministratorsView();
                }
                else if (screen.Name == "MyAccount")
                {
                    EditMasterCredentialsView credentialsView = new EditMasterCredentialsView();
                }
            }
        }
    }
}

