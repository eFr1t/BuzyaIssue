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
    public class ApplicationTM : BaseTM<Application>, IApplicationRepository
    {
        public ApplicationTM() :
            base(ApplicationRepository.Instance) { }

        public List<Guid> GetJobApplicationIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And JobId = '{1}'", _defaultSelectCommand, id));
        }

        public List<Guid> GetAuthorOngoingApplicationIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And AuthorId = '{1}' And IsClosed = 0", _defaultSelectCommand, id));
        }

        public List<Guid> GetAuthorPastApplicationIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And AuthorId = '{1}' And IsClosed = 1", _defaultSelectCommand, id));
        }
    }
}
