using EPAM.Data.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data
{
    public class JobCategory
    {
        public Guid Id { get; private set; }

        public String Name { get; set; }
        public String Description { get; set; }

        public List<JobSubcategory> JobSubcategories
        {
            get
            {
                List<JobSubcategory> res = new List<JobSubcategory>();
                foreach (var js in JobSubcategoryManager.Instance.JobSubcategorys.Values)
                    if (js.JobCategory == this)
                        res.Add(js);
                return res;
            }
        }

        public JobCategory()
        {
            Id = Guid.NewGuid();
        }

        public static JobCategory getByValue(Guid id, String name, String desc)
        {
            JobCategory jc = new JobCategory();
            jc.Id = id;
            jc.Name = name;
            jc.Description = desc;
            return jc;
        }
    }
}
