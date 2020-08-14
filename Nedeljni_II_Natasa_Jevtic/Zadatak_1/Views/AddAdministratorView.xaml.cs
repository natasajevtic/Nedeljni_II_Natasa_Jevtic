using System.Windows;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for AddAdministratorView.xaml
    /// </summary>
    public partial class AddAdministratorView : Window
    {
        public AddAdministratorView()
        {
            InitializeComponent();
            this.DataContext = new AddAdministratorViewModel(this);
        }
    }
}
