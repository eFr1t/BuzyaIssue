using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Client_Server
{
    public interface IJob
    {
        bool CreateJob(Job job);
        bool DeleteJob(Job job);
        bool AddJobSkill(Job job, Skill skill);
        bool DeleteJobSkill(Job job, Skill skill);
        List<Application> GetJobApplications(Job job);
        List<Stage> GetJobStages(Job job);
        List<Question> GetJobQuestions(Job job);
    }
}
