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
    [DBTable("JobFilter")]
    [DataContract]
    public class JobFilter : Base
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
        [DBColumn("BudgetMin")]
        public double BudgetMin { get; set; }
        [DataMember]
        [DBColumn("BudgetMax")]
        public double BudgetMax { get; set; }
        [DataMember]
        [DBColumn("DeadlineAfter")]
        public DateTime DeadlineAfter { get; set; }
        [DataMember]
        [DBColumn("SearchString")]
        public String SearchString { get; set; }

        public JobFilter() : base() { InitParameters(); }

        public JobFilter(Guid id) : base(id) { InitParameters(); }

        private void InitParameters()
        {
            BudgetMax = 100000;
        }
    }
}
