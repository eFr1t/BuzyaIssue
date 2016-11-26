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

namespace EPAM.Admin.View
{
    public partial class QuestionsUC : UserControl
    {
        private QuestionsUCVM _vm;

        public QuestionsUC()
        {
            InitializeComponent();

            DataContext = _vm = new QuestionsUCVM();
        }

        private void lbQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _vm.QuestionsSelectionChanged();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _vm.Save();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            _vm.Add();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _vm.Delete();
        }
    }
}
