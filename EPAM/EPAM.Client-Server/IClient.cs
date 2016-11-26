using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Client_Server
{
    public interface IClient
    {
        Client GetClientById(Guid id);
        bool EditClientInfo(Client client);
        List<Job> GetClientJobs(Client client);
        List<Contract> GetCLientContracts(Client client);
        List<Talk> GetClientTalks(Client client);
    }
}
