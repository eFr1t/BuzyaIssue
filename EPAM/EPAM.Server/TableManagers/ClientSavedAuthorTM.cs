using EPAM.Model;
using EPAM.Model.IRepository;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Server.TableManagers
{
    public class ClientSavedAuthorTM : BaseTM<ClientSavedAuthor>, IClientSavedAuthorRepository
    {
        public ClientSavedAuthorTM() :
            base(ClientSavedAuthorRepository.Instance) { }

        public List<Guid> GetClientSavedAuthorIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And ClientId = '{1}'", _defaultSelectCommand, id));
        }
    }
}
