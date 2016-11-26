using EPAM.Admin.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EPAM.Admin.ViewModel
{
    class AdminWindowVM : BaseVM
    {
        private bool _isCategories;
        public bool IsCategories
        {
            get { return _isCategories; }
            set
            {
                SetAllFalse(value);
                _isCategories = value;
                OnPropertyChanged("IsCategories");
            }
        }

        private bool _isSkills;
        public bool IsSkills
        {
            get { return _isSkills; }
            set
            {
                SetAllFalse(value);
                _isSkills = value;
                OnPropertyChanged("IsSkills");
            }
        }

        private bool _isTimeZones;
        public bool IsTimeZones
        {
            get { return _isTimeZones; }
            set
            {
                SetAllFalse(value);
                _isTimeZones = value;
                OnPropertyChanged("IsTimeZones");
            }
        }

        private bool _isQuestions;
        public bool IsQuestions
        {
            get { return _isQuestions; }
            set
            {
                SetAllFalse(value);
                _isQuestions = value;
                OnPropertyChanged("IsQuestions");
            }
        }

        private UserControl _currentUC;
        public UserControl CurrentUC
        {
            get { return _currentUC; }
            set
            {
                _currentUC = value;
                OnPropertyChanged("CurrentUC");
            }
        }

        public AdminWindowVM()
        {
            IsCategories = true;

            AppVM.Instace.ToString();
        }

        private void SetAllFalse(bool value)
        {
            if (value)
            {
                IsCategories = false;
                IsSkills = false;
                IsTimeZones = false;
                IsQuestions = false;
            }
        }

        public void Checked()
        {
            if (IsCategories)
                CurrentUC = new CategoriesUC();
            else if (IsSkills)
                CurrentUC = new SkillsUC();
            else if (IsTimeZones)
                CurrentUC = new TimeZonesUC();
            else
                CurrentUC = new QuestionsUC();
        }
    }
}
