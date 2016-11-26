using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    public class ClientSavedAuthorRepository : BaseRepository<ClientSavedAuthor, IClientSavedAuthorRepository>, IClientSavedAuthorRepository
    {
        static private ClientSavedAuthorRepository _instance;
        static public ClientSavedAuthorRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ClientSavedAuthorRepository();
                return _instance;
            }
        }

        public List<ClientSavedAuthor> GetClientSavedAuthors(Client client)
        {
            return GetListFromIds(GetClientSavedAuthorIds(client.Id));
        }

        public List<Guid> GetClientSavedAuthorIds(Guid id)
        {
            return Proxy.GetClientSavedAuthorIds(id);
        }
    }
}
