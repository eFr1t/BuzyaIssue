using EPAM.Model.Client_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Managers
{
    public class JobSubcategoryManager : BaseManager<JobSubcategory>, IJobSubcategory
    {
        static private JobSubcategoryManager _instance;
        static public JobSubcategoryManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new JobSubcategoryManager();
                return _instance;
            }
        }

        private JobSubcategoryManager() : base() { }

        public List<JobSubcategory> GetCategorySubcategories(JobCategory category)
        {
            throw new NotImplementedException();
        }
    }
}
