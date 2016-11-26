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
    public partial class CategoriesUC : UserControl
    {
        CategoriesUCVM _vm;

        public CategoriesUC()
        {
            InitializeComponent();

            DataContext = _vm = new CategoriesUCVM();
        }

        private void lbCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _vm.CategoriesSelectionChanged();
        }

        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            _vm.AddCategory();
        }

        private void btnSaveCategory_Click(object sender, RoutedEventArgs e)
        {
            _vm.SaveCategory();
        }

        private void btnDeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            _vm.DeleteCategory();
        }

        private void lbSubcategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _vm.SubcategoriesSelectionChanged();
        }

        private void btnAddSubcategory_Click(object sender, RoutedEventArgs e)
        {
            _vm.AddSubcategory();
        }

        private void btnSaveSubcategory_Click(object sender, RoutedEventArgs e)
        {
            _vm.SaveSubcategory();
        }

        private void btnDeleteSubcategory_Click(object sender, RoutedEventArgs e)
        {
            _vm.DeleteSubcategory();
        }
    }
}
