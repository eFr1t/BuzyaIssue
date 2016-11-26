using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.Model.Repositories;
using EPAM.DBAttribute;

namespace EPAM.Model
{
    [DataContract]
    public class Author : Person
    {
        [DataMember]
        [DBColumn("PhotoPath")]
        public String PhotoPath { get; set; }
        [DataMember]
        [DBColumn("Title")]
        public String Title { get; set; }
        [DataMember]
        [DBColumn("HourRate")]
        public double HourRate { get; set; }
        [DataMember]
        [DBColumn("Overview")]
        public String Overview { get; set; }
        [DataMember]
        [DBColumn("IsAvailable")]
        public bool IsAvailable { get; set; }

        public List<Skill> Skills
        {
            get { return SkillRepository.Instance.GetAuthorSkills(this); }
        }

        public List<JobFilter> SavedJobFilters
        {
            get { return JobFilterRepository.Instance.GetAuthorSavedJobFilters(this); }
        }

        public List<Job> SavedJobs
        {
            get { return JobRepository.Instance.GetAuthorSavedJobs(this); }
        }

        public List<Job> OngoingJobs
        {
            get { return JobRepository.Instance.GetAuthorOngoingJobs(this); }
        }

        public List<Job> PastJobs
        {
            get { return JobRepository.Instance.GetAuthorPastJobs(this); }
        }

        public List<Application> OngoingApplications
        {
            get { return ApplicationRepository.Instance.GetAuthorOngoingApplications(this); }
        }

        public List<Application> PastApplications
        {
            get { return ApplicationRepository.Instance.GetAuthorPastApplications(this); }
        }

        public List<Talk> Talks
        {
            get { return TalkRepository.Instance.GetPersonTalks(this); }
        }

        public Author(Guid id) : base(id) { InitProperties(); }

        public Author() : base() { InitProperties(); }

        private void InitProperties()
        {
            Title = "";
            Overview = "";
            HourRate = 0;
        }

        public bool IsSavedByClientId(Guid id)
        {
            List<Guid> savedAuthorsIds = AuthorRepository.Instance.GetClientSavedAuthorIds(id);
            return savedAuthorsIds.Contains(Id);
        }
    }
}
