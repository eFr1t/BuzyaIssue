using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data.Managers
{
    public class StageManager
    {   
        static private StageManager _instance;
        static public StageManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StageManager();
                return _instance;
            }
        }

        public Dictionary<Guid, Stage> Stages;

        private StageManager() 
        {
            Stages = new Dictionary<Guid, Stage>();
        }
    }
}
