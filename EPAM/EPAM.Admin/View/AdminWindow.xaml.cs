using EPAM.Admin.ViewModel;
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

namespace EPAM.Admin
{
    public partial class MainWindow : Window
    {
        AdminWindowVM _vm;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = _vm = new AdminWindowVM();
        }

        private void tbChecked(object sender, RoutedEventArgs e)
        {
            _vm.Checked();
        }
    }
}
