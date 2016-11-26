using EPAM.Model;
using EPAM.IClient_Server;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Server.ServerServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple, IncludeExceptionDetailInFaults=true)]
    public class RegisterService : IRegisterService
    {
        public bool RegisterAuthor(Author author)
        {
            return AuthorRepository.Instance.Register(author);
        }

        public bool RegisterClient(Client client)
        {
            return ClientRepository.Instance.Register(client);
        }
    }
}
