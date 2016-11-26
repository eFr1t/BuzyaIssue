using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data.Managers
{
    public class ApplicationManager
    {        
        static private ApplicationManager _instance;
        static public ApplicationManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ApplicationManager();
                return _instance;
            }
        }

        public Dictionary<Guid, Application> Applications;

        private ApplicationManager() 
        {
            Applications = new Dictionary<Guid, Application>();
        }
    }
}
