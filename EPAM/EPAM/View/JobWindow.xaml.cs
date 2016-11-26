using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EPAM.View
{
    public partial class JobWindow : Window
    {
        private Job Job;

        public JobWindow(Job job)
        {
            InitializeComponent();

            Job = job;

            //cbJobType.Text =  Job.Type;
            //tbxJobTheme.Text = Job.Theme;
            //tbxJobDescription.Text = Job.Description;
            //tbxJobTime.Text = Job.RequireTimeToComplete.ToString();
            //cbJobTimeType.Text = Job.TimeType;
            //tbxJobBudget.Text = Job.ClientBudget.ToString();
            //cbJobBudgetCurrency.Text = Job.CurrencyType;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //Job.Type = cbJobType.Text;
            //Job.Theme = tbxJobTheme.Text;
            //Job.Description = tbxJobDescription.Text;
            //Job.RequireTimeToComplete = int.Parse(tbxJobTime.Text);
            //Job.TimeType = cbJobTimeType.Text;
            //Job.ClientBudget = int.Parse(tbxJobBudget.Text);
            //Job.CurrencyType = cbJobBudgetCurrency.Text;

            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
