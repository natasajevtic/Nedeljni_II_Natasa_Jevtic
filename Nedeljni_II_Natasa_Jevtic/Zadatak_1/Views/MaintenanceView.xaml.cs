using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for MaintenanceView.xaml
    /// </summary>
    public partial class MaintenanceView : Window
    {
        public vwClinicMaintenance maintenance { get; set; }

        public MaintenanceView(vwClinicMaintenance maintenance)
        {
            InitializeComponent();
            this.maintenance = maintenance;
            this.DataContext = new MaintenanceViewModel(this, maintenance);

            var menuReport = new List<SubItem>();
            menuReport.Add(new SubItem("View reports", new ReportsView(maintenance)));
            var item1 = new ItemMenu("Reports", menuReport, PackIconKind.File);

            var item0 = new ItemMenu("", new UserControl(), PackIconKind.ViewDashboard);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
        }

        public void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);
            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);

                if (screen.Name == "Reports")
                {
                    ReportsView reportsView = new ReportsView(maintenance);
                }
            }
        }
    }
}
