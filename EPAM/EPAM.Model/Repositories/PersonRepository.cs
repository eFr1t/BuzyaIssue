using EPAM.Model;
using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    //not extends BaseManager<Person> because Person is abstract
    public class PersonRepository
    {
        static private PersonRepository _instance;
        static public PersonRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PersonRepository();
                return _instance;
            }
        }

        private PersonRepository() { }

        public Person Login(String login, String password)
        {
            Client c = ClientRepository.Instance.Login(login, password);
            if (c != null)
                return c;

            return AuthorRepository.Instance.Login(login, password);
        }

        public Person GetItemById(Guid id)
        {
            Client c = ClientRepository.Instance.GetItemById(id);
            if (c != null)
                return c;

            return AuthorRepository.Instance.GetItemById(id);
        }

        public bool Register(Person person)
        {
            if (person.GetType() == typeof(Client))
                return ClientRepository.Instance.Register(person as Client);
            else
                return AuthorRepository.Instance.Register(person as Author);

        }
    }
}
