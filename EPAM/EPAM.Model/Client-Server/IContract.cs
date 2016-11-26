using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Client_Server
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        List<Contract> GetPersonContracts(Person person);
    }
}
