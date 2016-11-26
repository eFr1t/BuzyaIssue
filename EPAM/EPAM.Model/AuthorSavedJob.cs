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
    [DBTable("AuthorSavedJob")]
    [DataContract]
    public class AuthorSavedJob : Base
    {
        [DataMember]
        private Guid _authorId;
        [DBColumn("AuthorId")]
        public Guid AuthorId
        {
            get { return _authorId; }
            set { _authorId = value; }
        }
        public Author Author
        {
            set { _authorId = value.Id; }
            get { return AuthorRepository.Instance.GetItemById(_authorId); }
        }

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
            set { _jobId = value.Id; }
            get { return JobRepository.Instance.GetItemById(_jobId); }
        }

        public AuthorSavedJob() : base() { }

        public AuthorSavedJob(Guid id) : base(id) { }
    }
}
