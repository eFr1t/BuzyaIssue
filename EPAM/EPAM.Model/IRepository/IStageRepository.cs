using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.IRepository
{
    public interface IStageRepository : IBaseRepository<Stage>
    {
        List<Guid> GetJobStageIds(Guid id);
    }
}
