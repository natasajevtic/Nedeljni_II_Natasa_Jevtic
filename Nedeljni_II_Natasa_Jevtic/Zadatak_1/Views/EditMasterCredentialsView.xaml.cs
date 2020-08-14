using System.Windows.Controls;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for EditMasterCredintialsView.xaml
    /// </summary>
    public partial class EditMasterCredentialsView : UserControl
    {
        public EditMasterCredentialsView(string username, string password)
        {
            InitializeComponent();
            this.Name = "MyAccount";
            this.DataContext = new EditMasterCredentialsViewModel(this, username, password);
        }
    }
}
