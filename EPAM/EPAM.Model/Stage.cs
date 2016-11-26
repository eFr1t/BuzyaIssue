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
    [DBTable("Stage")]
    [DataContract]
    public class Stage : Base
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
        [DBColumn("Title")]
        public String Title { get; set; }
        [DataMember]
        [DBColumn("Description")]
        public String Description { get; set; }
        [DataMember]
        [DBColumn("Budget")]
        public int Budget { get; set; }

        public Stage() : base() { }

        public Stage(Guid id) : base(id) { }
    }
}
