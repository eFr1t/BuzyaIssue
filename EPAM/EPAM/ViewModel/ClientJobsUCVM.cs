using EPAM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EPAM.ViewModel
{
    public class ClientJobsUCVM : BaseVM
    {
        private bool _isCreateJob;
        public bool IsCreateJob
        {
            get { return _isCreateJob; }
            set 
            {
                if(value != _isCreateJob)
                {
                    SetAllFalse(value);
                    _isCreateJob = value;
                    OnPropertyChanged("IsCreateJob");
                }
            }
        }

        private bool _isMyJobs;
        public bool IsMyJobs
        {
            get { return _isMyJobs; }
            set 
            { 
                if(value != _isMyJobs)
                {
                    SetAllFalse(value);
                    _isMyJobs = value;
                    OnPropertyChanged("IsMyJobs");
                }
            }
        }

        private bool _isMyContracts;
        public bool IsMyContracts
        {
            get { return _isMyContracts; }
            set 
            {
                if(value != _isMyContracts)
                {
                    SetAllFalse(value);
                    _isMyContracts = value;
                    OnPropertyChanged("IsMyContracts");
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

        public ClientJobsUCVM()
        {
            IsCreateJob = true;
        }

        private void SetAllFalse(bool value)
        {
            if (value)
            {
                IsCreateJob = false;
                IsMyJobs = false;
                IsMyContracts = false;
            }
        }

        public void Checked()
        {
            if (IsCreateJob)
                CurrentUC = new ClientCreateJobUC();
            else
                CurrentUC = null;
        }
    }
}
