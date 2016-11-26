using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    public class AuthorSkillRepository : BaseRepository<AuthorSkill, IAuthorSkillRepository>, IAuthorSkillRepository
    {   
        static private AuthorSkillRepository _instance;
        static public AuthorSkillRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AuthorSkillRepository();
                return _instance;
            }
        }

        private AuthorSkillRepository() : base() { }

        public List<AuthorSkill> GetAuthorSkills(Author author)
        {
            return GetListFromIds(GetAuthorSkillIds(author.Id));
        }

        public List<Guid> GetAuthorSkillIds(Guid id)
        {
            return Proxy.GetAuthorSkillIds(id);
        }
    }
}
