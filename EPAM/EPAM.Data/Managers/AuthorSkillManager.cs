using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data.Managers
{
    public class AuthorSkillManager
    {   
        static private AuthorSkillManager _instance;
        static public AuthorSkillManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AuthorSkillManager();
                return _instance;
            }
        }

        public Dictionary<Guid, AuthorSkill> AuthorSkills;

        private AuthorSkillManager() 
        {
            AuthorSkills = new Dictionary<Guid, AuthorSkill>();
        }
    }
}
