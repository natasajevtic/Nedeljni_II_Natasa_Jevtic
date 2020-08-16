using System.Windows;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for EditDoctorView.xaml
    /// </summary>
    public partial class EditDoctorView : Window
    {
        public EditDoctorView(vwClinicDoctor doctor)
        {
            InitializeComponent();
            this.DataContext = new EditDoctorViewModel(this, doctor);
        }
    }
}
