using EPAM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Interfaces
{
    public interface IPerson
    {
        Person GetPersonById(Guid id);
        Person GetPersonByLogin(String login, String password);
        bool RegisterPerson(Person person);
        bool DeletePerson(Person person);
    }
}
