using EPAM.Model;
using EPAM.Model.Repositories;
using EPAM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EPAM.ViewModel
{
    public class ClientCreateJobUCVM : BaseVM
    {
        private Job _job;
        public Job Job
        {
            get { return _job; }
            set
            {
                if (value != _job)
                {
                    _job = value;
                    OnPropertyChanged("Job");
                }
            }
        }

        private String _title;
        public String Title
        {
            get { return _title; }
            set 
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private String _description;
        public String Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private String _shortDescription;
        public String ShortDescription
        {
            get { return _shortDescription; }
            set
            {
                _shortDescription = value;
                OnPropertyChanged("ShortDescription");
            }
        }

        private String _budget;
        public String Budget
        {
            get { return _budget; }
            set
            {
                _budget = value;
                OnPropertyChanged("Budget");
            }
        }

        private List<JobCategory> _jobCategories;
        public List<JobCategory> JobCategories
        {
            get { return _jobCategories; }
            set
            {
                if (value != _jobCategories)
                {
                    _jobCategories = value;
                    OnPropertyChanged("JobCategories");
                }
            }
        }

        private JobCategory _currentJobCategory;
        public JobCategory CurrentJobCategory
        {
            get { return _currentJobCategory; }
            set
            {
                if (value != _currentJobCategory)
                {
                    _currentJobCategory = value;
                    OnPropertyChanged("CurrentJobCategory");
                    if(value == null)
                    {
                        CurrentJobSubcategory = null;
                        JobSubcategories = null;
                    }
                    else
                    {
                        JobSubcategories = CurrentJobCategory.JobSubcategories;
                        IsEnabledJobSubcategory = true;
                    }
                }
            }
        }

        private bool _isEnabledJobSubcategory;
        public bool IsEnabledJobSubcategory
        {
            get { return _isEnabledJobSubcategory; }
            set
            {
                if (value != _isEnabledJobSubcategory)
                {
                    _isEnabledJobSubcategory = value;
                    OnPropertyChanged("IsEnabledJobSubcategory");
                }
            }
        }

        private List<JobSubcategory> _jobSubcategories;
        public List<JobSubcategory> JobSubcategories
        {
            get { return _jobSubcategories; }
            set
            {
                if (value != _jobSubcategories)
                {
                    _jobSubcategories = value;
                    OnPropertyChanged("JobSubcategories");
                    if(value == null)
                    {
                        IsEnabledJobSubcategory = false;
                    }
                }
            }
        }

        private JobSubcategory _currentJobSubcategory;
        public JobSubcategory CurrentJobSubcategory
        {
            get { return _currentJobSubcategory; }
            set
            {
                if (value != _currentJobSubcategory)
                {
                    _currentJobSubcategory = value;
                    OnPropertyChanged("CurrentJobSubcategory");
                }
            }
        }

        private ObservableCollection<QuestionUC> _questions;
        public ObservableCollection<QuestionUC> Questions
        {
            get { return _questions; }
            set 
            {
                if (value != _questions)
                {
                    _questions = value;
                    OnPropertyChanged("Questions");
                }
            }
        }

        private ObservableCollection<Button> _questionButtons;
        public ObservableCollection<Button> QuestionButtons
        {
            get { return _questionButtons; }
            set {
                if (value != _questionButtons)
                {
                    _questionButtons = value;
                    OnPropertyChanged("QuestionButtons");
                }
            }
        }

        public ClientCreateJobUCVM()
        {
            InitializeJob();
            JobCategories = JobCategoryRepository.Instance.GetAllItems();
            IsEnabledJobSubcategory = false;

            Questions = new ObservableCollection<QuestionUC>();
            QuestionButtons = new ObservableCollection<Button>();
        }

        private static int maxValue = 0;

        public void addQuestion()
        {
            Question q = new Question();
            q.Job = Job;
            q.QuestionText = "Question" + ++maxValue;
            Questions.Add(new QuestionUC(q));
            Button b = new Button();
            b.Content = "-";
            QuestionButtons.Add(b);
        }

        public void Save()
        {
            Job.Title = Title;
            Job.JobCategory = CurrentJobCategory;
            Job.JobSubcategory = CurrentJobSubcategory;
            Job.ShortDescription = ShortDescription;
            Job.Description = Description;
            Job.PostedDate = DateTime.Now;
            Job.Deadline = DateTime.Now;
            Job.Budget = Int32.Parse(Budget);

            if(JobRepository.Instance.SetItem(Job))
                Clear();
        }

        public void Clear()
        {
            InitializeJob();
            CurrentJobCategory = null;
            Title = "";
            ShortDescription = "";
            Description = "";
            Budget = "";
        }

        private void InitializeJob()
        {
            Job = new Job();
            Job.Client = (Client)AppVM.Instace.Person;
        }
    }
}
