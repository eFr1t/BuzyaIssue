using EPAM.Model.Client_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Managers
{
    public class SkillManager : BaseManager<Skill>, ISkill
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

        private SkillManager() : base() { }

        public List<Skill> GetJobSkills(Job job)
        {
            throw new NotImplementedException();
        }

        public List<Skill> GetAuthorSkills(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
