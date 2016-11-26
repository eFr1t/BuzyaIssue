using EPAM.ViewModel;
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
    /// <summary>
    /// Логика взаимодействия для ClientJobsUC.xaml
    /// </summary>
    public partial class ClientJobsUC : UserControl
    {
        private ClientJobsUCVM _vm;

        public ClientJobsUC()
        {
            InitializeComponent();

            DataContext = _vm = new ClientJobsUCVM();
        }

        private void tbChecked(object sender, RoutedEventArgs e)
        {
            _vm.Checked();
        }
    }
}
