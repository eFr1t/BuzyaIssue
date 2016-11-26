using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.IRepository
{
    public interface IJobSkillRepository : IBaseRepository<JobSkill>
    {
        List<Guid> GetJobSkillIds(Guid id);
    }
}
