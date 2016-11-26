using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Client_Server
{
    public interface IContract
    {
        bool CreateContract(Contract contract);
        bool EndContract(Contract contract);
        bool AddJobToContract(Contract contract, Job job);
        bool RemoveJobContract(Job job);
        List<Job> GetContractJobs(Contract contract);
    }
}
