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
    public class Application
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        private Guid _jobId;
        public Job Job
        {
            set { _jobId = value.Id; }
            get { return JobManager.Instance.Jobs[_jobId]; }
        }

        [DataMember]
        private Guid _authorId;
        public Author Author
        {
            set { _authorId = value.Id; }
            get { return AuthorManager.Instance.Authors[_authorId]; }
        }

        [DataMember]
        public bool IsApproved { get; set; }

        public List<Question> Questions
        {
            get
            {
                return (from questions in QuestionManager.Instance.Questions.Values
                        where questions.Application == this
                        select questions).ToList();
            }
        }

        public Application()
        {
            Id = Guid.NewGuid();

            IsApproved = false;
        }
    }
}
