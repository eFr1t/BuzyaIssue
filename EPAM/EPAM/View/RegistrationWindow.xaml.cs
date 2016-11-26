using EPAM.Model;
using EPAM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EPAM.View
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        RegistrationWindowVM _vm;

        public RegistrationWindow()
        {
            InitializeComponent();

            DataContext = _vm = new RegistrationWindowVM(this);


        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            _vm.DoRegister(pbPassword.Password, pbRepassword.Password);
        }
    }
}
