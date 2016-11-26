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
using System.Windows.Shapes;
using EPAM.ViewModel;
using System.IO;

namespace EPAM.View
{
    public partial class LogInWindow : Window
    {
        private LogInWindowVM vm;

        public LogInWindow()
        {
            InitializeComponent();

            DataContext = vm = new LogInWindowVM(this);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            vm.DoLogin(pbPass.Password);
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            vm.GoToRegister();
        }
    }
}
