using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Client_Server
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IPerson
    {
        Person GetPersonById(Guid id);
        [OperationContract(IsOneWay = false, IsInitiating = true, IsTerminating = false)]
        Person Login(String login, String password);
        void RegisterPerson(Person person);
        void DeletePerson(Person person);
    }
}
