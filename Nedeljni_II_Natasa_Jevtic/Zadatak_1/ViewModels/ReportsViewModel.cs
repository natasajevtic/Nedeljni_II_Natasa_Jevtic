using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class ReportsViewModel : BaseViewModel
    {
        ReportsView reportView;        

        private vwClinicMaintenance maintenance;

        public vwClinicMaintenance Maintenance
        {
            get
            {
                return maintenance;
            }
            set
            {
                maintenance = value;
                OnPropertyChanged("Maintenance");
            }
        }

        private Report report;

        public Report Report
        {
            get
            {
                return report;
            }
            set
            {
                report = value;
                OnPropertyChanged("Report");
            }
        }

        private List<Report> reports;

        public List<Report> Reports
        {
            get
            {
                return reports;
            }
            set
            {
                reports = value;
                OnPropertyChanged("Reports");
            }
        }

        private ICommand add;
        public ICommand Add
        {
            get
            {
                if (add == null)
                {
                    add = new RelayCommand(param => AddExecute(), param => CanAddExecute());
                }
                return add;
            }
        }

        public ReportsViewModel(ReportsView reportView, vwClinicMaintenance maintenance)
        {
            this.reportView = reportView;
            Maintenance = maintenance;           
            GetReports();
        }

        public void GetReports()
        {
            Reports = new List<Report>();
            string source = string.Format(@"../../Maintenance{0}.txt", Maintenance.MaintenanceId);
            if (File.Exists(source))
            {
                string[] lines = File.ReadAllLines(source);
                List<string> values = new List<string>();
                for (int i = 0; i < lines.Length; i++)
                {
                    values = lines[i].Split('[',']').ToList();
                    Report report = new Report();
                    report.Date = values[1];
                    report.Hours = values[3];
                    report.Description = values[5];
                    Reports.Add(report);
                }
            }            
        }

        public void AddExecute()
        {
            try
            {
                AddReportView form = new AddReportView(Maintenance);
                form.ShowDialog();
                GetReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanAddExecute()
        {
            return true;
        }
    }
}
