using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    public class TalkRepository : BaseRepository<Talk, ITalkRepository>, ITalkRepository
    {   
        static private TalkRepository _instance;
        static public TalkRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TalkRepository();
                return _instance;
            }
        }

        private TalkRepository() : base () { }

        public List<Talk> GetPersonTalks(Person person)
        {
            return GetListFromIds(GetPersonTalkIds(person.Id));
        }

        public List<Guid> GetPersonTalkIds(Guid id)
        {
            return Proxy.GetPersonTalkIds(id);
        }
    }
}
