using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data.Managers
{
    public class JobCategoryManager
    { 
        static private JobCategoryManager _instance;
        static public JobCategoryManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new JobCategoryManager();
                return _instance;
            }
        }

        public Dictionary<Guid, JobCategory> JobCategorys;

        private JobCategoryManager() 
        {
            JobCategorys = new Dictionary<Guid, JobCategory>(); 
            //{
            //    "Psychology",
            //    "Biology",
            //    "Biochemistry",
            //    "Chemistry",
            //    "Computer Science",
            //    "Ecology",
            //    "Engineering",
            //    "Mathematics",
            //    "Microbiology",
            //    "Physics",
            //    "Astronomy",
            //    "Zoology"
            //};
        }
    }
}
