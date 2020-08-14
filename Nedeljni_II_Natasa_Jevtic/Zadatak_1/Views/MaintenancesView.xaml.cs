using System.Windows.Controls;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for MaintenancesView.xaml
    /// </summary>
    public partial class MaintenancesView : UserControl
    {
        public MaintenancesView()
        {
            InitializeComponent();
            this.Name = "Maintenances";
            this.DataContext = new MaintenancesViewModel(this);
        }
    }
}
