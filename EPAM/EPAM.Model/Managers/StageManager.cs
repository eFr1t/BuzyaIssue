using EPAM.Model.Client_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Managers
{
    public class StageManager : BaseManager<Stage>, IStage
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

        private StageManager() : base() { }

        public List<Stage> GetJobStages(Job job)
        {
            throw new NotImplementedException();
        }
    }
}
