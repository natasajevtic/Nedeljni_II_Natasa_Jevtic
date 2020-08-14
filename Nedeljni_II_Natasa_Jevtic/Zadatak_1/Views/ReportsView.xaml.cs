using System.Windows.Controls;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for ReportsView.xaml
    /// </summary>
    public partial class ReportsView : UserControl
    {
        public ReportsView(vwClinicMaintenance maintenance)
        {
            InitializeComponent();
            this.Name = "Reports";
            this.DataContext = new ReportsViewModel(this, maintenance);
        }
    }
}