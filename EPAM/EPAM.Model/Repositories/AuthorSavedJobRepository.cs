using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    public class AuthorSavedJobRepository : BaseRepository<AuthorSavedJob, IAuthorSavedJobRepository>, IAuthorSavedJobRepository
    {
        static private AuthorSavedJobRepository _instance;
        static public AuthorSavedJobRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AuthorSavedJobRepository();
                return _instance;
            }
        }

        public List<AuthorSavedJob> GetAuthorSavedJobs(Author author)
        {
            return GetListFromIds(GetAuthorSavedJobIds(author.Id));
        }

        public List<Guid> GetAuthorSavedJobIds(Guid id)
        {
            return Proxy.GetAuthorSavedJobIds(id);
        }
    }
}
