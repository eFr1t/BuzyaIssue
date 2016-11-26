using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Client_Server
{
    [ServiceContract]
    public interface ISkill
    {
        [OperationContract]
        List<Skill> GetJobSkills(Job job);
        [OperationContract]
        List<Skill> GetAuthorSkills(Author author);
    }
}
