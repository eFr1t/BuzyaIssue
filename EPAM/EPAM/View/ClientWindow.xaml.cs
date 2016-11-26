using EPAM.Model;
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
using System.Windows.Shapes;

namespace EPAM.View
{
    public partial class ClientWindow : Window
    {
        private Client Client { get; set; }

        private ClientWindowVM _vm;

        public ClientWindow(Client client)
        {
            InitializeComponent();

            Client = client;

            DataContext = _vm = new ClientWindowVM();
        }

        private void tbChecked(object sender, RoutedEventArgs e)
        {
            _vm.Checked();
        }
    }
}
