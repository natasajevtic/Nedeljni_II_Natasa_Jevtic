using System.Windows.Controls;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for EditClinic.xaml
    /// </summary>
    public partial class EditClinicView : UserControl
    {
        public EditClinicView()
        {
            InitializeComponent();
            this.Name = "EditClinic";
            this.DataContext = new EditClinicViewModel(this);
        }
    }
}

