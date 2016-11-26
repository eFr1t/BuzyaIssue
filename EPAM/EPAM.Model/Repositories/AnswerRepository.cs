using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    public class AnswerRepository : BaseRepository<Answer, IAnswerRepository>, IAnswerRepository
    {
        static private AnswerRepository _instance;
        static public AnswerRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AnswerRepository();
                return _instance;
            }
        }

        public List<Answer> GetApplicationAnswers(Application application)
        {
            return GetListFromIds(GetApplicationAnswerIds(application.Id));
        }

        public List<Guid> GetApplicationAnswerIds(Guid id)
        {
            return Proxy.GetApplicationAnswerIds(id);
        }
    }
}
