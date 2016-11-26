using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model
{
    [DataContract]
    public class AuthorFilter
    {
        [DataMember]
        public String SearchString { get; set; }
        [DataMember]
        public double HourRateMin { get; set; }
        [DataMember]
        public double HourRateMax { get; set; }
        [DataMember]
        public int CountOfPastJobsMin { get; set; }
        [DataMember]
        public int CountOfPastJobsMax { get; set; }
        [DataMember]
        public List<Guid> SkillIds { get; set; }
        public List<Skill> Skills
        {
            get
            {
                List<Skill> skills = new List<Skill>();
                if (SkillIds != null)
                    foreach (var id in SkillIds)
                        skills.Add(SkillRepository.Instance.GetItemById(id));
                return skills;
            }
            set
            {
                SkillIds.Clear();
                foreach (var skill in value)
                    SkillIds.Add(skill.Id);
            }
        }

        public AuthorFilter()
        {
            SkillIds = new List<Guid>();
            HourRateMin = 0;
            HourRateMax = 100;
            CountOfPastJobsMin = 0;
            CountOfPastJobsMax = 100;
        }
    }
}
