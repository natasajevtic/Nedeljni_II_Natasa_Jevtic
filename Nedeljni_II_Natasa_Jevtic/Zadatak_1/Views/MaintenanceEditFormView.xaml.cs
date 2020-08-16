using System.Windows;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for MaintenanceEditFormView.xaml
    /// </summary>
    public partial class MaintenanceEditFormView : Window
    {
        public MaintenanceEditFormView(vwClinicMaintenance maintenance)
        {
            InitializeComponent();
            this.Name = "Maintenances";
            this.DataContext = new MaintenanceEditFormViewModel(this, maintenance);
        }
    }
}