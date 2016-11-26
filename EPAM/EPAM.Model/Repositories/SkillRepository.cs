using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    public class SkillRepository : BaseRepository<Skill, ISkillRepository>, ISkillRepository
    {   
        static private SkillRepository _instance;
        static public SkillRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SkillRepository();
                return _instance;
            }
        }

        private SkillRepository() : base() { }


        public List<Skill> GetJobSkills(Job job)
        {
            List<Skill> res = new List<Skill>();
            foreach (var item in JobSkillRepository.Instance.GetJobSkills(job))
                res.Add(item.Skill);
            return res;
        }

        public List<Skill> GetAuthorSkills(Author author)
        {
            List<Skill> res = new List<Skill>();
            foreach (var item in AuthorSkillRepository.Instance.GetAuthorSkills(author))
                res.Add(item.Skill);
            return res;
        }
    }
}
