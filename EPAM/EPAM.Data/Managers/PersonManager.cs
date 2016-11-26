using EPAM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data.Managers
{
    public class PersonManager
    {
        static private PersonManager _instance;
        static public PersonManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PersonManager();
                return _instance;
            }
        }

        public Dictionary<Guid, Person> Persons;

        private PersonManager() 
        {
            Persons = new Dictionary<Guid, Person>();
        }

        public Person GetPersonById(Guid id)
        {
            return Persons[id];
        }

        //public Client GetClientById(Guid id)
        //{
        //    return GetPersonById(id) as Client;
        //}

        //public Author GetAuthorById(Guid id)
        //{
        //    return GetPersonById(id) as Author;
        //}

        public Person GetPersonByLogin(String login, String password)
        {
            foreach(var p in Persons.Values)
            {
                if (p.IsIt(login, password))
                    return p;
            }
            return null;
        }


        public bool RegisterPerson(Person person)
        {
            return false;
        }

        public bool DeletePerson(Person person)
        {
            return false;
        }
    }
}
