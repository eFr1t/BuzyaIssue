using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EPAM.ViewModel
{
    public class ClientFreelancersUCVM : BaseVM
    {
        private bool _isFind;
        public bool IsFind
        {
            get { return _isFind; }
            set 
            {
                if(value != _isFind)
                {
                    SetAllFalse(value);
                    _isFind = value;
                    OnPropertyChanged("IsFind");
                }
            }
        }

        private bool _isSaved;
        public bool IsSaved
        {
            get { return _isSaved; }
            set 
            { 
                if(value != _isSaved)
                {
                    SetAllFalse(value);
                    _isSaved = value;
                    OnPropertyChanged("IsSaved");
                }
            }
        }

        private bool _isOnContract;
        public bool IsOnContract
        {
            get { return _isOnContract; }
            set 
            {
                if(value != _isOnContract)
                {
                    SetAllFalse(value);
                    _isOnContract = value;
                    OnPropertyChanged("IsOnContract");
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

        public ClientFreelancersUCVM()
        {
            IsFind = true;
        }

        private void SetAllFalse(bool value)
        {
            if (value)
            {
                IsSaved = false;
                IsFind = false;
                IsOnContract = false;
            }
        }

        public void Checked()
        {
            ;
        }
    }
}
