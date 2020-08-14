using System.Windows;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for MaintenanceAddFormView.xaml
    /// </summary>
    public partial class MaintenanceAddFormView : Window
    {
        public MaintenanceAddFormView()
        {
            InitializeComponent();
            this.DataContext = new MaintenanceAddFormViewModel(this);
        }
    }
}

