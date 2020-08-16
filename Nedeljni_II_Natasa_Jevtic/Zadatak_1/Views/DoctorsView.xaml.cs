using System.Windows.Controls;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for DoctorsView.xaml
    /// </summary>
    public partial class DoctorsView : UserControl
    {
        public DoctorsView()
        {
            InitializeComponent();
            this.Name = "Doctors";
            this.DataContext = new DoctorsViewModel(this);
        }
    }
}
