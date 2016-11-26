using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.IRepository
{
    public interface IApplicationRepository : IBaseRepository<Application>
    {
        List<Guid> GetJobApplicationIds(Guid id);
        List<Guid> GetAuthorOngoingApplicationIds(Guid id);
        List<Guid> GetAuthorPastApplicationIds(Guid id);
    }
}
