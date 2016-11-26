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
    public class JobSkillTM : BaseTM<JobSkill>, IJobSkillRepository
    {
        public JobSkillTM() :
            base(JobSkillRepository.Instance) { }

        public List<Guid> GetJobSkillIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And JobId = '{1}'", _defaultSelectCommand, id));
        }
    }
}
