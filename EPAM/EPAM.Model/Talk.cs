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
    [DBTable("Talk")]
    [DataContract]
    public class Talk : Base
    {
        [DataMember]
        private Guid _clientId;
        [DBColumn("ClientId")]
        public Guid ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }
        public Client Client
        {
            get { return ClientRepository.Instance.GetItemById(_clientId); }
            set { _clientId = value.Id; }
        }

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
            get { return AuthorRepository.Instance.GetItemById(_clientId); }
            set { _authorId = value.Id; }
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
            get { return JobRepository.Instance.GetItemById(_jobId); }
            set { _jobId = value.Id; }
        }

        public Talk() : base() { }

        public Talk(Guid id) : base(id) { }
    }
}
