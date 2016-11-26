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
    public class Stage
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
        public String Title { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public int Budget { get; set; }

        public Stage() { Id = Guid.NewGuid(); }
    }
}
