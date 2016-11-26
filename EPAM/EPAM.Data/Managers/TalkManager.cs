using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data.Managers
{
    public class TalkManager
    {   
        static private TalkManager _instance;
        static public TalkManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TalkManager();
                return _instance;
            }
        }

        public Dictionary<Guid, Talk> Talks;

        private TalkManager() 
        {
            Talks = new Dictionary<Guid, Talk>();
        }
    }
}
