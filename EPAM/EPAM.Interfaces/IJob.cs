using EPAM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Interfaces
{
    public interface IJob
    {
        bool CreateJob(Job job);
        bool DeleteJob(Job job);
        bool AddJobSkill(Job job, Skill skill);
        bool DeleteJobSkill(Job job, Skill skill);
    }
}
