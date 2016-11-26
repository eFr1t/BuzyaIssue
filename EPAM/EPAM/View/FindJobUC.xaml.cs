using EPAM.Model;
using EPAM.Model.Repositories;
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
    /// Логика взаимодействия для FindJobUC.xaml
    /// </summary>
    public partial class FindJobUC : UserControl
    {
        public FindJobUC()
        {
            InitializeComponent();

            foreach(var item in JobRepository.Instance.GetCurrentItems())
                spJobPosts.Children.Add(new JobPostUC(item));
        }
    }
}
