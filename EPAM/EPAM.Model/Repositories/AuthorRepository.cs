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
    public class AuthorRepository : BaseRepository<Author, IAuthorRepository>, IAuthorRepository, IRegisterAuthor
    {
        public IRegisterAuthor RegisterProxy { private get; set; }

        static private AuthorRepository _instance;
        static public AuthorRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AuthorRepository();
                return _instance;
            }
        }

        private AuthorRepository() : base() { }

        public bool Register(Author author)
        {
            return RegisterProxy.Register(author);
        }

        public Author Login(string login, string password)
        {
            return Proxy.Login(login, password);
        }

        public List<Author> GetClientSavedAuthors(Client client)
        {
            return GetListFromIds(GetClientSavedAuthorIds(client.Id));
        }

        public List<Guid> GetFilterAuthorIdsDirectly(AuthorFilter authorFilter)
        {
            return Proxy.GetFilterAuthorIdsDirectly(authorFilter);
        }

        public List<Guid> GetClientSavedAuthorIds(Guid id)
        {
            List<Guid> ids = new List<Guid>();
            foreach (var item in ClientSavedAuthorRepository.Instance.GetClientSavedAuthorIds(id))
                ids.Add(ClientSavedAuthorRepository.Instance.GetItemById(item).AuthorId);
            return ids;
        }
    }
}
