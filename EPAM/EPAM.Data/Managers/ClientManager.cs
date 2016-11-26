using EPAM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data.Managers
{
    public class ClientManager
    {
        static private ClientManager _instance;
        static public ClientManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ClientManager();
                return _instance;
            }
        }

        public Dictionary<Guid, Client> Clients;

        private ClientManager() 
        {
            Clients = new Dictionary<Guid, Client>();
        }

        public Client GetClientById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool EditClientInfo(Client client)
        {
            throw new NotImplementedException();
        }

        public List<Job> GetClientJobs(Client client)
        {
            throw new NotImplementedException();
        }

        public List<Contract> GetCLientContracts(Client client)
        {
            throw new NotImplementedException();
        }

        public List<Talk> GetClientTalks(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
