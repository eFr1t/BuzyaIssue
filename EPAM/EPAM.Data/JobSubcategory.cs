using EPAM.Data.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data
{
    public class JobSubcategory
    {
        public Guid Id { get; private set; }

        private Guid _jobCategoryId;
        public JobCategory JobCategory
        {
            get { return JobCategoryManager.Instance.JobCategorys[_jobCategoryId]; }
            set { _jobCategoryId = value.Id; }
        }

        public String Name { get; set; }
        public String Description { get; set; }

        public JobSubcategory()
        {
            Id = Guid.NewGuid();
        }

        public static JobSubcategory getByValue(Guid id, Guid jobCategoryId, String name, String desc)
        {
            JobSubcategory jsc = new JobSubcategory();
            jsc.Id = id;
            jsc._jobCategoryId = jobCategoryId;
            jsc.Name = name;
            jsc.Description = desc;
            return jsc;
        }
    }
}
