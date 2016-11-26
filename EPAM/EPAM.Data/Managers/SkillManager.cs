using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data.Managers
{
    public class SkillManager
    {   
        static private SkillManager _instance;
        static public SkillManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SkillManager();
                return _instance;
            }
        }

        public Dictionary<Guid, Skill> Skills;

        private SkillManager() 
        {
            Skills = new Dictionary<Guid, Skill>();
        }
    }
}
