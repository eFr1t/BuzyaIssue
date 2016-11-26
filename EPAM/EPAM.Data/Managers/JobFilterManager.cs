using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data.Managers
{
    public class JobFilterManager
    {   
        static private JobFilterManager _instance;
        static public JobFilterManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new JobFilterManager();
                return _instance;
            }
        }

        public Dictionary<Guid, JobFilter> JobFilters;

        private JobFilterManager() 
        {
            JobFilters = new Dictionary<Guid, JobFilter>();
        }
    }
}
