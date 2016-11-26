using EPAM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Interfaces
{
    public interface IAuthor
    {
        Author GetAuthorById(Guid id);
        bool EditAuthorInfo(Author author);
        bool AppltyToJob(Author author, Job job);
        bool DeleteApplication(Application application);
        bool AddAuthorSkill(Author author, Skill skill);
        bool DeleteAuthorSkill(Author authorb, Skill skill);
    }
}
