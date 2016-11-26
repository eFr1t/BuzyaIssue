using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    public class JobRepository : BaseRepository<Job, IJobRepository>, IJobRepository
    {
        static private JobRepository _instance;
        static public JobRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new JobRepository();
                return _instance;
            }
        }

        private JobRepository() : base() { }

        public List<Job> GetAuthorOngoingJobs(Author author)
        {
            return GetListFromIds(GetAuthorOngoingJobIds(author.Id));
        }

        public List<Job> GetAuthorPastJobs(Author author)
        {
            return GetListFromIds(GetAuthorPastJobIds(author.Id));
        }

        public List<Job> GetClientOngoingJobs(Client client)
        {
            return GetListFromIds(GetClientOngoingJobIds(client.Id));
        }

        public List<Job> GetClientPastJobs(Client client)
        {
            return GetListFromIds(GetClientPastJobIds(client.Id));
        }

        public List<Job> GetAuthorSavedJobs(Author author)
        {
            return GetListFromIds(GetAuthorSavedJobIds(author.Id));
        }

        public List<Guid> GetFilterJobIds(Guid id)
        {
            return Proxy.GetFilterJobIds(id);
        }

        public List<Guid> GetFilterJobIdsDirectly(JobFilter jobFilter)
        {
            return Proxy.GetFilterJobIdsDirectly(jobFilter);
        }

        public List<Guid> GetAuthorOngoingJobIds(Guid id)
        {
            return Proxy.GetAuthorOngoingJobIds(id);
        }

        public List<Guid> GetAuthorPastJobIds(Guid id)
        {
            return Proxy.GetAuthorPastJobIds(id);
        }

        public List<Guid> GetClientOngoingJobIds(Guid id)
        {
            return Proxy.GetClientOngoingJobIds(id);
        }

        public List<Guid> GetClientPastJobIds(Guid id)
        {
            return Proxy.GetClientPastJobIds(id);
        }

        public List<Guid> GetAuthorSavedJobIds(Guid id)
        {
            List<Guid> ids = new List<Guid>();
            foreach (var item in AuthorSavedJobRepository.Instance.GetAuthorSavedJobIds(id))
                ids.Add(AuthorSavedJobRepository.Instance.GetItemById(item).JobId);
            return ids;
        }
    }
}
