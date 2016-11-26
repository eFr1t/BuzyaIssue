using EPAM.Model;
using EPAM.Model.Client_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Managers
{
    public class ClientManager : BaseManager<Client>, IClient
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

        private ClientManager() : base() { }
    }
}
