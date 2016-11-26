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
    [DBTable("Job")]
    [DataContract]
    public class Job : Base
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
            get { return AuthorRepository.Instance.GetItemById(_authorId); }
            set { _authorId = value.Id; }
        }

        [DataMember]
        private Guid _jobCategoryId;
        [DBColumn("JobCategoryId")]
        public Guid JobCategoryId
        {
            get { return _jobCategoryId; }
            set { _jobCategoryId = value; }
        }
        public JobCategory JobCategory
        {
            get { return JobCategoryRepository.Instance.GetItemById(_jobCategoryId); }
            set { _jobCategoryId = value.Id; }
        }

        [DataMember]
        private Guid _jobSubcategoryId;
        [DBColumn("JobSubcategoryId")]
        public Guid JobSubcategoryId
        {
            get { return _jobSubcategoryId; }
            set { _jobSubcategoryId = value; }
        }
        public JobSubcategory JobSubcategory
        {
            get { return JobSubcategoryRepository.Instance.GetItemById(_jobSubcategoryId); }
            set { _jobSubcategoryId = value.Id; }
        }

        [DataMember]
        [DBColumn("Title")]
        public String Title { get; set; }
        [DataMember]
        [DBColumn("ShortDescription")]
        public String ShortDescription { get; set; }
        [DataMember]
        [DBColumn("Description")]
        public String Description { get; set; }
        [DataMember]
        [DBColumn("Deadline")]
        public DateTime Deadline { get; set; }
        [DataMember]
        [DBColumn("PostedDate")]
        public DateTime PostedDate { get; set; }
        [DataMember]
        [DBColumn("Budget")]
        public double Budget { get; set; }
        [DataMember]
        [DBColumn("IsClosed")]
        public bool IsClosed { get; set; }

        public List<Question> Questions
        {
            get { return QuestionRepository.Instance.GetJobQuestions(this); }
        }

        public List<Skill> Skills
        {
            get { return SkillRepository.Instance.GetJobSkills(this); }
        }

        public List<Stage> Stages
        {
            get { return StageRepository.Instance.GetJobStages(this); }
        }

        public List<Application> Applications
        {
            get { return ApplicationRepository.Instance.GetJobApplications(this); }
        }

        public Job() : base() { }

        public Job(Guid id) : base(id) { }

        public bool IsSavedByAuthorId(Guid id)
        {
            List<Guid> savedJobIds = JobRepository.Instance.GetAuthorSavedJobIds(id);
            return savedJobIds.Contains(Id);
        }
    }
}
