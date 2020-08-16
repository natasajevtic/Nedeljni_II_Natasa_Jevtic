using System.Windows;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for CreateClinicView.xaml
    /// </summary>
    public partial class CreateClinicView : Window
    {
        public CreateClinicView()
        {
            InitializeComponent();
            this.DataContext = new CreateClinicViewModel(this);
        }
    }
}
