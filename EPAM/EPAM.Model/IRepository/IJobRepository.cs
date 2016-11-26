using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.IRepository
{
    public interface IJobRepository : IBaseRepository<Job>
    {
        List<Guid> GetFilterJobIds(Guid id);
        List<Guid> GetFilterJobIdsDirectly(JobFilter jobFilter);
        List<Guid> GetAuthorOngoingJobIds(Guid id);
        List<Guid> GetAuthorPastJobIds(Guid id);
        List<Guid> GetClientOngoingJobIds(Guid id);
        List<Guid> GetClientPastJobIds(Guid id);
    }
}
