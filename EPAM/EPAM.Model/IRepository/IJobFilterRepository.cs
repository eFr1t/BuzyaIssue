using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.IRepository
{
    public interface IJobFilterRepository : IBaseRepository<JobFilter> 
    {
        List<Guid> GetAuthorSavedJobFilterIds(Guid id);
    }
}
