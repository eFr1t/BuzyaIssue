using EPAM.Model.Client_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Managers
{
    public class JobSkillManager : BaseManager<JobSkill>, IJobSkill
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

        private JobSkillManager() : base() { }
    }
}
