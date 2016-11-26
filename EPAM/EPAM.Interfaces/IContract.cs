using EPAM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Interfaces
{
    public interface IContract
    {
        bool CreateContract(Contract contract);
        bool EndContract(Contract contract);
        bool AddJobToContract(Contract contract, Job job);
    }
}
