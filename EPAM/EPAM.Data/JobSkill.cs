using EPAM.Data.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data
{
    [DataContract]
    public class JobSkill
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        private Guid _jobId;
        public Job Job
        {
            get { return JobManager.Instance.Jobs[_jobId]; }
            set { _jobId = value.Id; }
        }

        [DataMember]
        private Guid _skillId;
        public Skill Skill
        {
            get { return SkillManager.Instance.Skills[_skillId]; }
            set { _skillId = value.Id; }
        }


    }
}
