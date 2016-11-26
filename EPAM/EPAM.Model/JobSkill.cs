using EPAM.DBAttribute;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model
{
    [DBTable("JobSkill")]
    [DataContract]
    public class JobSkill : Base
    {
        [DataMember]
        private Guid _jobId;
        [DBColumn("JobId")]
        public Guid JobId
        {
            get { return _jobId; }
            set { _jobId = value; }
        }
        public Job Job
        {
            get { return JobRepository.Instance.GetItemById(_jobId); }
            set { _jobId = value.Id; }
        }

        [DataMember]
        private Guid _skillId;
        [DBColumn("SkillId")]
        public Guid SkillId
        {
            get { return _skillId; }
            set { _skillId = value; }
        }
        public Skill Skill
        {
            get { return SkillRepository.Instance.GetItemById(_skillId); }
            set { _skillId = value.Id; }
        }

        public JobSkill() : base() { }

        public JobSkill(Guid id) : base(id) { }
    }
}
