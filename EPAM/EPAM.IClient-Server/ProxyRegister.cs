using EPAM.Model;
using EPAM.Model.IRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.IClient_Server
{
    public class ProxyRegister : ClientBase<IRegisterService>, IRegisterAuthor, IRegisterClient
    {
        public bool Register(Author author)
        {
            return Channel.RegisterAuthor(author);
        }

        public bool Register(Client client)
        {
            return Channel.RegisterClient(client);
        }
    }
}
