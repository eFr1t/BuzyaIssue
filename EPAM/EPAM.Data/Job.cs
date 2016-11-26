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
    public class Job
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        private Guid _clientId;
        public Client Client
        {
            get { return ClientManager.Instance.Clients[_clientId]; }
            set { _clientId = value.Id; }
        }

        [DataMember]
        public String Title { get; set; }
        [DataMember]
        public String Category { get; set; }
        [DataMember]
        public String Subcategory { get; set; }
        [DataMember]
        public String ShortDescription { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public String Deadline { get; set; }
        [DataMember]
        public String PostedDate { get; set; }
        [DataMember]
        public int Budget { get; set; }

        public List<Question> Questions
        {
            get
            {
                return (from questions in QuestionManager.Instance.Questions.Values
                        where questions.Job == this
                        select questions).ToList();
            }
        }

        public List<Skill> Skills
        {
            get
            {
                return (from jobSkills in JobSkillManager.Instance.JobSkills.Values
                        where jobSkills.Job == this
                        select jobSkills.Skill).ToList();
            }
        }

        public List<Stage> Stages
        {
            get
            {
                return (from stages in StageManager.Instance.Stages.Values
                        where stages.Job == this
                        select stages).ToList();
            }
        }

        public List<Application> Applications
        {
            get
            {
                return (from applications in ApplicationManager.Instance.Applications.Values
                        where applications.Job == this
                        select applications).ToList();
            }
        }

        public Job() { Id = Guid.NewGuid(); }
    }
}
