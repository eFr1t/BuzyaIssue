using EPAM.DBAttribute;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EPAM.Model
{
    [DataContract]
    public class Client : Person
    {
        [DataMember]
        [DBColumn("IsCompany")]
        public bool IsCompany { get; set; }
        [DataMember]
        [DBColumn("CompanyName")]
        public String CompanyName { get; set; }
        [DataMember]
        [DBColumn("Overview")]
        public String Overview { get; set; }

        public List<Job> OngoingJobs
        {
            get { return JobRepository.Instance.GetClientOngoingJobs(this); }
        }

        public List<Job> PastJobs
        {
            get { return JobRepository.Instance.GetClientPastJobs(this); }
        }

        public List<Author> SavedAuthors
        {
            get { return AuthorRepository.Instance.GetClientSavedAuthors(this); }
        }

        public List<Talk> Talks
        {
            get { return TalkRepository.Instance.GetPersonTalks(this); }
        }

        public Client(Guid id) : base(id) { }

        public Client() : base() { }
    }
}
