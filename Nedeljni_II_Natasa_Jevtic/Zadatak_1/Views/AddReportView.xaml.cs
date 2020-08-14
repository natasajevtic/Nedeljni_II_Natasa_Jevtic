using System;
using System.Windows;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for AddReportView.xaml
    /// </summary>
    public partial class AddReportView : Window
    {
        public AddReportView(vwClinicMaintenance maintenance)
        {
            InitializeComponent();
            txtDate.Text = DateTime.Now.ToShortDateString();
            this.DataContext = new AddReportViewModel(this, maintenance);
        }
    }
}
