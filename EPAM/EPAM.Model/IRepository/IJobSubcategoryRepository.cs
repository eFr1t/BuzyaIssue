using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.IRepository
{
    public interface IJobSubcategoryRepository : IBaseRepository<JobSubcategory>
    {
        List<Guid> GetCategorySubcategoryIds(Guid id);
    }
}
