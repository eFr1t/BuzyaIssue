using EPAM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data.Managers
{
    public class AuthorManager
    {
        static private AuthorManager _instance;
        static public AuthorManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AuthorManager();
                return _instance;
            }
        }

        public Dictionary<Guid, Author> Authors;

        private AuthorManager() 
        {
            Authors = new Dictionary<Guid, Author>();
        }

        public Author GetAuthorById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool EditAuthorInfo(Author author)
        {
            throw new NotImplementedException();
        }

        public bool AddAuthorSkill(Skill skill)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAuthorSkill(Skill skill)
        {
            throw new NotImplementedException();
        }

        public List<Contract> GetAuthorContracts(Author author)
        {
            throw new NotImplementedException();
        }

        public List<Application> GetAuthorApplications(Author author)
        {
            throw new NotImplementedException();
        }

        public List<Talk> GetAuthorTalks(Author author)
        {
            throw new NotImplementedException();
        }

        public List<Skill> GetAuthorSkills(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
