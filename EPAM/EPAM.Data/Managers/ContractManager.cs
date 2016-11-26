using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data.Managers
{
    public class ContractManager
    {   
        static private ContractManager _instance;
        static public ContractManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ContractManager();
                return _instance;
            }
        }

        public Dictionary<Guid, Contract> Contracts;

        private ContractManager() 
        {
            Contracts = new Dictionary<Guid, Contract>();
        }
    }
}
