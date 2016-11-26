using EPAM.Model;
using EPAM.Model.Repositories;
using EPAM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.ViewModel
{
    public class RegistrationWindowVM : BaseVM
    {
        private RegistrationWindow _window;

        private String _name;
        public String Name
        {
            get { return _name; }
            set 
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private String _sName;
        public String SName
        {
            get { return _sName; }
            set 
            {
                if (value != _sName)
                {
                    _sName = value;
                    OnPropertyChanged("SName");
                }
            }
        }

        private String _email;
        public String Email
        {
            get { return _email; }
            set 
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        private bool _isClient;
        public bool IsClient
        {
            get { return _isClient; }
            set 
            {
                if (value != _isClient)
                {
                    _isClient = value;
                    OnPropertyChanged("IsClient");
                }
            }
        }

        private String _login;
        public String Login
        {
            get { return _login; }
            set 
            {
                if(value != _login)
                {
                    _login = value;
                    OnPropertyChanged("Login");
                }
            }
        }

        private List<Model.TimeZone> _timeZones;
        public List<Model.TimeZone> TimeZones
        {
            get { return _timeZones;}
            set
            {
                _timeZones = value;
                OnPropertyChanged("TimeZones");
            }
        }

        private Model.TimeZone _selectedTimeZone;
        public Model.TimeZone SelectedTimeZone
        {
            get { return _selectedTimeZone; }
            set
            {
                _selectedTimeZone = value;
                OnPropertyChanged("SelectedTimeZone");
            }
        }

        public RegistrationWindowVM(RegistrationWindow window)
        {
            _window = window;
            _isClient = true;

            TimeZones = TimeZoneRepository.Instance.GetAllItems();
            TimeZones.Sort(CompareTimeZonesByHour);
        }

        private static int CompareTimeZonesByHour(Model.TimeZone x, Model.TimeZone y)
        {
            if (x == null && y == null)
                return 0;
            else if (x == null)
                return -1;
            else if (y == null)
                return 1;
            else if (x.UTCHourValue == y.UTCHourValue)
                return 0;
            else
                return x.UTCHourValue > y.UTCHourValue ? 1 : -1;
        }

        public void DoRegister(String password, String repassword)
        {
            if (password != repassword)
                return;

            Person person = null;
            if (IsClient)
                person = new Client();
            else
                person = new Author();
            person.Login = Login;
            person.Password = password;
            person.Name = Name;
            person.SName = SName;
            person.Email = Email;
            person.TimeZone = SelectedTimeZone;

            PersonRepository.Instance.Register(person);

            new LogInWindow().Show();
            _window.Close();
        }
    }
}
