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
    [DBTable("JobSubcategory")]
    [DataContract]
    public class JobSubcategory : Base
    {
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
        private String _name;
        [DBColumn("Name")]
        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        [DataMember]
        [DBColumn("Description")]
        public String Description { get; set; }

        public JobSubcategory() : base() { InitProperties(); }

        public JobSubcategory(Guid id) : base(id) { InitProperties(); }

        private void InitProperties()
        {
            Name = "Empty";
            Description = "";
        }
    }
}
