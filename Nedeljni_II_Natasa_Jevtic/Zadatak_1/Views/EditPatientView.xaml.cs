using System.Windows;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for EditPatientView.xaml
    /// </summary>
    public partial class EditPatientView : Window
    {
        public EditPatientView(vwClinicPatient patient)
        {
            InitializeComponent();
            this.DataContext = new EditPatientViewModel(this, patient);
        }
    }
}
