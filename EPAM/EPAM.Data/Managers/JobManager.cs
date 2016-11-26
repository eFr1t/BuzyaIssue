using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data.Managers
{
    public class JobManager
    {   
        static private JobManager _instance;
        static public JobManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new JobManager();
                return _instance;
            }
        }

        public Dictionary<Guid, Job> Jobs;

        private JobManager() 
        {
            Jobs = new Dictionary<Guid, Job>();
        }
    }
}
