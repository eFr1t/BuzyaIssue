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
    /// Логика взаимодействия для ClientCreateJobUC.xaml
    /// </summary>
    public partial class ClientCreateJobUC : UserControl
    {
        private ClientCreateJobUCVM _vm;

        public ClientCreateJobUC()
        {
            InitializeComponent();

            DataContext = _vm = new ClientCreateJobUCVM();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            _vm.Clear();
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            _vm.addQuestion();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _vm.Save();
        }
    }
}
