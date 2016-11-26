using EPAM.Model.Client_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Managers
{
    public class JobCategoryManager : BaseManager<JobCategory>, IJobCategory
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

        private JobCategoryManager() : base() { }
    }
}
