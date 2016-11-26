using EPAM.Data.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data
{
    public class Question
    {
        public Guid Id { get; private set; }

        public String QuestionText { get; set; }
        public String AnswerText { get; set; }

        private Guid _jobId;
        public Job Job
        {
            get { return JobManager.Instance.Jobs[_jobId]; }
            set { _jobId = value.Id; }
        }

        private Guid _applicationId;
        public Application Application
        {
            get { return ApplicationManager.Instance.Applications[_applicationId]; }
            set { _applicationId = value.Id; }
        }

        public Question()
        {
            Id = Guid.NewGuid();
        }
    }
}
