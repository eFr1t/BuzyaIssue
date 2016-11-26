using EPAM.Model;
using EPAM.Model.IRepository;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Server.TableManagers
{
    public class TalkTM : BaseTM<Talk>, ITalkRepository
    {
        public TalkTM() :
            base(TalkRepository.Instance) { }

        public List<Guid> GetPersonTalkIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And PersonId = '{1}'", _defaultSelectCommand, id));
        }
    }
}
