using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data.Managers
{
    public class JobSubcategoryManager
    {
        static private JobSubcategoryManager _instance;
        static public JobSubcategoryManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new JobSubcategoryManager();
                return _instance;
            }
        }

        public Dictionary<Guid, JobSubcategory> JobSubcategorys;

        private JobSubcategoryManager() 
        {
            JobSubcategorys = new Dictionary<Guid, JobSubcategory>(); 
        }
    }
}
