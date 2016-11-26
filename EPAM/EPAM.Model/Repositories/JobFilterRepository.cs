using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    public class JobFilterRepository : BaseRepository<JobFilter, IJobFilterRepository>, IJobFilterRepository
    {   
        static private JobFilterRepository _instance;
        static public JobFilterRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new JobFilterRepository();
                return _instance;
            }
        }

        private JobFilterRepository() : base() { }

        public List<JobFilter> GetAuthorSavedJobFilters(Author author)
        {
            return GetListFromIds(GetAuthorSavedJobFilterIds(author.Id));
        }

        public List<Guid> GetAuthorSavedJobFilterIds(Guid id)
        {
            return Proxy.GetAuthorSavedJobFilterIds(id);
        }
    }
}
