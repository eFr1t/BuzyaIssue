using EPAM.Model;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Admin.ViewModel
{
    public class CategoriesUCVM : BaseVM
    {
        private ObservableCollection<JobCategory> _categories;
        public ObservableCollection<JobCategory> Categories
        {
            get { return _categories; }
            set 
            { 
                _categories = value;
                OnPropertyChanged("Categories");
            }
        }

        private ObservableCollection<JobSubcategory> _subcategories;
        public ObservableCollection<JobSubcategory> Subcategories
        {
            get { return _subcategories; }
            set 
            { 
                _subcategories = value;
                OnPropertyChanged("Subcategories");
            }
        }

        private JobCategory _selectedCategory;
        public JobCategory SelectedCategory
        {
            get { return _selectedCategory; }
            set 
            {
                _selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        private JobSubcategory _selectedSubcategory;
        public JobSubcategory SelectedSubcategory
        {
            get { return _selectedSubcategory; }
            set 
            {
                _selectedSubcategory = value;
                OnPropertyChanged("SelectedSubcategory");
            }
        }

        private String _categoryName;
        public String CategoryName
        {
            get { return _categoryName; }
            set
            {
                _categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }

        private String _subcategoryName;
        public String SubcategoryName
        {
            get { return _subcategoryName; }
            set
            {
                _subcategoryName = value;
                OnPropertyChanged("SubcategoryName");
            }
        }

        private String _categorydescription;
        public String CategoryDescription
        {
            get { return _categorydescription; }
            set
            {
                _categorydescription = value;
                OnPropertyChanged("CategoryDescription");
            }
        }

        private String _subcategorydescription;
        public String SubcategoryDescription
        {
            get { return _subcategorydescription; }
            set
            {
                _subcategorydescription = value;
                OnPropertyChanged("SubcategoryDescription");
            }
        }

        private bool _isEnabledSubcategories;
        public bool IsEnabledSubcategories
        {
            get { return _isEnabledSubcategories; }
            set 
            { 
                _isEnabledSubcategories = value;
                OnPropertyChanged("IsEnabledSubcategories");
            }
        }

        public CategoriesUCVM()
        {
            Categories = new ObservableCollection<JobCategory>(JobCategoryRepository.Instance.GetAllItems().OrderBy(i => i.Name));
        }

        public void CategoriesSelectionChanged()
        {
            if (SelectedCategory == null)
            {
                IsEnabledSubcategories = false;
                return;
            }

            CategoryName = SelectedCategory.Name;
            CategoryDescription = SelectedCategory.Description;

            IsEnabledSubcategories = true;
            Subcategories = new ObservableCollection<JobSubcategory>(JobSubcategoryRepository.Instance.GetCategorySubcategories(SelectedCategory).OrderBy(i => i.Name));
        }

        public void SubcategoriesSelectionChanged()
        {
            if (SelectedSubcategory == null)
            {
                SubcategoryName = "";
                SubcategoryDescription = "";
                return;
            }

            SubcategoryName = SelectedSubcategory.Name;
            SubcategoryDescription = SelectedSubcategory.Description;
        }

        public void AddCategory()
        {
            JobCategory item = new JobCategory();
            JobCategoryRepository.Instance.SetItem(item);

            Categories.Add(item);
            SelectedCategory = item;
        }

        public void AddSubcategory()
        {
            JobSubcategory item = new JobSubcategory();
            item.JobCategory = SelectedCategory;
            JobSubcategoryRepository.Instance.SetItem(item);

            Subcategories.Add(item);
            SelectedSubcategory = item;
        }

        public void SaveCategory()
        {
            if (SelectedCategory == null)
                return;

            SelectedCategory.Name = CategoryName;
            SelectedCategory.Description = CategoryDescription;

            JobCategoryRepository.Instance.UpdateItem(SelectedCategory);
        }

        public void SaveSubcategory()
        {
            if (SelectedSubcategory == null)
                return;

            SelectedSubcategory.Name = SubcategoryName;
            SelectedSubcategory.Description = SubcategoryDescription;

            JobSubcategoryRepository.Instance.UpdateItem(SelectedSubcategory);
        }

        public void DeleteCategory()
        {
            if (SelectedCategory == null)
                return;

            JobCategoryRepository.Instance.RemoveItem(SelectedCategory);
            Categories.Remove(SelectedCategory);

            CategoryName = "";
            CategoryDescription = "";
        }

        public void DeleteSubcategory()
        {
            if (SelectedSubcategory == null)
                return;

            JobSubcategoryRepository.Instance.RemoveItem(SelectedSubcategory);
            Subcategories.Remove(SelectedSubcategory);

            SubcategoryName = "";
            SubcategoryDescription = "";
        }
    }
}
