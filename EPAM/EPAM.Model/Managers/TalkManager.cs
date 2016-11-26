using EPAM.Model.Client_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Managers
{
    public class TalkManager : BaseManager<Talk>, ITalk
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

        private TalkManager() : base () { }

        public List<Talk> GetPersonTalks(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
