using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.IClient_Server
{
    [ServiceContract]
    public interface IRegisterService
    {
        [OperationContract]
        bool RegisterAuthor(Author author);
        [OperationContract]    
        bool RegisterClient(Client client);
    }
}
