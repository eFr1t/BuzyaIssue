using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    public class ApplicationRepository : BaseRepository<Application, IApplicationRepository>, IApplicationRepository
    {
        static private ApplicationRepository _instance;
        static public ApplicationRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ApplicationRepository();
                return _instance;
            }
        }

        private ApplicationRepository() : base() { }

        public List<Application> GetJobApplications(Job job)
        {
            return GetListFromIds(GetJobApplicationIds(job.Id));
        }

        public List<Application> GetAuthorOngoingApplications(Author author)
        {
            return GetListFromIds(GetAuthorOngoingApplicationIds(author.Id));
        }

        public List<Application> GetAuthorPastApplications(Author author)
        {
            return GetListFromIds(GetAuthorPastApplicationIds(author.Id));
        }

        public List<Guid> GetJobApplicationIds(Guid id)
        {
            return Proxy.GetJobApplicationIds(id);
        }

        public List<Guid> GetAuthorOngoingApplicationIds(Guid id)
        {
            return Proxy.GetAuthorOngoingApplicationIds(id);
        }

        public List<Guid> GetAuthorPastApplicationIds(Guid id)
        {
            return Proxy.GetAuthorPastApplicationIds(id);
        }
    }
}
