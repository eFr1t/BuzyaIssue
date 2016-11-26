using EPAM.Model.Client_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Managers
{
    public class JobManager : BaseManager<Job>, IJob
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

        private JobManager() : base() { }

        public List<Job> GetContractJobs(Contract contract)
        {
            throw new NotImplementedException();
        }

        public List<Job> GetClientJobs(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
