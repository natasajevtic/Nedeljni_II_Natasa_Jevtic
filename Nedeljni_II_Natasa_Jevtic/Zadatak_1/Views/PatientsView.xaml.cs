using System.Windows.Controls;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for PatientsView.xaml
    /// </summary>
    public partial class PatientsView : UserControl
    {
        public PatientsView()
        {
            InitializeComponent();
            this.Name = "Patients";
            this.DataContext = new PatientsViewModel(this);
        }
    }
}
