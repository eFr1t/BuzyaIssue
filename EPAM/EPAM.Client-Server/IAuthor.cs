using EPAM.Model;
using EPAM.DBAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Client_Server
{
    public interface IAuthor
    {
        Author GetAuthorById(Guid id);
        bool EditAuthorInfo(Author author);
        bool AddAuthorSkill(Skill skill);
        bool DeleteAuthorSkill(Skill skill);
        List<Contract> GetAuthorContracts(Author author);
        List<Application> GetAuthorApplications(Author author);
        List<Talk> GetAuthorTalks(Author author);
        List<Skill> GetAuthorSkills(Author author);
    }
}
