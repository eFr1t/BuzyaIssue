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
    [DBTable("JobCategory")]
    [DataContract]
    public class JobCategory : Base
    {
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

        public List<JobSubcategory> JobSubcategories
        {
            get { return JobSubcategoryRepository.Instance.GetCategorySubcategories(this); }
        }

        public JobCategory() : base() { InitProperties(); }

        public JobCategory(Guid id) : base(id) { InitProperties(); }

        private void InitProperties()
        {
            Name = "Empty";
            Description = "";
        }
    }
}
