using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    public class JobSkillRepository : BaseRepository<JobSkill, IJobSkillRepository>, IJobSkillRepository
    {   
        static private JobSkillRepository _instance;
        static public JobSkillRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new JobSkillRepository();
                return _instance;
            }
        }

        private JobSkillRepository() : base() { }

        public List<JobSkill> GetJobSkills(Job job)
        {
            return GetListFromIds(GetJobSkillIds(job.Id));
        }

        public List<Guid> GetJobSkillIds(Guid id)
        {
            return Proxy.GetJobSkillIds(id);
        }
    }
}
