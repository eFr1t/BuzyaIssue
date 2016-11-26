using EPAM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EPAM.ViewModel
{
    public class ClientWindowVM : BaseVM
    {
        private bool _isJobs;
        public bool IsJobs
        {
            get { return _isJobs; }
            set 
            {
                if(value != _isJobs)
                {
                    SetAllFalse(value);
                    _isJobs = value;
                    OnPropertyChanged("IsJobs");
                }
            }
        }

        private bool _isFreelancers;
        public bool IsFreelancers
        {
            get { return _isFreelancers; }
            set 
            { 
                if(value != _isFreelancers)
                {
                    SetAllFalse(value);
                    _isFreelancers = value;
                    OnPropertyChanged("IsFreelancers");
                }
            }
        }

        private bool _isTalks;
        public bool IsTalks
        {
            get { return _isTalks; }
            set 
            {
                if(value != _isTalks)
                {
                    SetAllFalse(value);
                    _isTalks = value;
                    OnPropertyChanged("IsTalks");
                }
            }
        }

        private bool _isProfile;
        public bool IsProfile
        {
            get { return _isProfile; }
            set 
            {
                if(value != _isProfile)
                {
                    SetAllFalse(value);
                    _isProfile = value;
                    OnPropertyChanged("IsProfile");
                }
            }
        }

        private UserControl _currentUC;
        public UserControl CurrentUC
        {
            get { return _currentUC; }
            set 
            { 
                if(value != _currentUC)
                {
                    _currentUC = value;
                    OnPropertyChanged("CurrentUC");
                }
            }
        }

        public ClientWindowVM()
        {
            IsJobs = true;
        }

        private void SetAllFalse(bool value)
        {
            if (value)
            {
                IsJobs = false;
                IsFreelancers = false;
                IsTalks = false;
                IsProfile = false;
            }
        }

        public void Checked()
        {
            if (IsJobs)
                CurrentUC = new ClientJobsUC();
            else if (IsFreelancers)
                CurrentUC = new ClientFreelancersUC();
            else if (IsTalks)
                CurrentUC = null;
            else if (IsProfile)
            {
                CurrentUC = new ClientProfileUC();
            }
        }
    }
}
