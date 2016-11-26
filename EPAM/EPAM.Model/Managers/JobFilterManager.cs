using EPAM.Model.Client_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Managers
{
    public class JobFilterManager : BaseManager<JobFilter>, IJobFilter
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

        private JobFilterManager() : base() { }
    }
}
