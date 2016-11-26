using EPAM.FunctionTypes.ViewModel;
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

namespace EPAM.FunctionTypes
{
    public partial class MainWindow : Window
    {
        private MainWindowVM _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = _viewModel = new MainWindowVM();
        }

        private void btnFileDialog_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.btnFileDialog_Click();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.btnStart_Click();
        }

        private void lbInterfaces_Changed(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.lbInterfaces_Changed(sender);
        }

        private void lbMethods_Changed(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.lbMethods_Changed(sender);
        }
    }
}
