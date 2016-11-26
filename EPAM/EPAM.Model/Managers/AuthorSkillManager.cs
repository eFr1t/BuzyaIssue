using EPAM.Model.Client_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Managers
{
    public class AuthorSkillManager : BaseManager<AuthorSkill>, IAuthorSkill
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

        private AuthorSkillManager() : base() { }
    }
}
