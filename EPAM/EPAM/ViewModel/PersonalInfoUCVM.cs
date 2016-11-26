using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.ViewModel
{
    public class PersonalInfoUCVM : BaseVM
    {
        private Person _person;
        public Person Person
        {
            get { return _person; }
            set 
            { 
                if(value != _person)
                {
                    _person = value;
                    OnPropertyChanged("Person");
                }
            }
        }

        public PersonalInfoUCVM()
        {
            Person = AppVM.Instace.Person;
        }
    }
}
