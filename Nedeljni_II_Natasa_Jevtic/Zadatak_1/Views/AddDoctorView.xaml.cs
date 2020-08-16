using System.Windows;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for AddDoctorView.xaml
    /// </summary>
    public partial class AddDoctorView : Window
    {
        public AddDoctorView()
        {
            InitializeComponent();
            this.DataContext = new AddDoctorViewModel(this);
        }
    }
}
