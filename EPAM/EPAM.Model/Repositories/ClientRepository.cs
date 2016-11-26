using EPAM.Model;
using EPAM.Model.IRegister;
using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    public class ClientRepository : BaseRepository<Client, IClientRepository>, IClientRepository, IRegisterClient
    {
        public IRegisterClient RegisterProxy { private get; set; }

        static private ClientRepository _instance;
        static public ClientRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ClientRepository();
                return _instance;
            }
        }

        private ClientRepository() : base() { }

        public bool Register(Client client)
        {
            return RegisterProxy.Register(client);
        }

        public Client Login(string login, string password)
        {
            return Proxy.Login(login, password);
        }
    }
}
