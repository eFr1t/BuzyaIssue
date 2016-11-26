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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EPAM.View
{
    /// <summary>
    /// Логика взаимодействия для QuestionUC.xaml
    /// </summary>
    public partial class QuestionUC : UserControl
    {
        private QuestionUCVM _vm;

        public QuestionUC(Question q)
        {
            InitializeComponent();

            DataContext = _vm = new QuestionUCVM(q);
        }
    }
}
