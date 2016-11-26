using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data.Managers
{
    public class JobSkillManager
    {   
        static private JobSkillManager _instance;
        static public JobSkillManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new JobSkillManager();
                return _instance;
            }
        }

        public Dictionary<Guid, JobSkill> JobSkills;

        private JobSkillManager() 
        {
            JobSkills = new Dictionary<Guid, JobSkill>();
        }
    }
}
