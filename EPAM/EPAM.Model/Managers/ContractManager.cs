using EPAM.Model.Client_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Managers
{
    public class ContractManager : BaseManager<Contract>, IContract
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

        private ContractManager() : base() { }

        public List<Contract> GetPersonContracts(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
