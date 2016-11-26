using EPAM.Model;
using EPAM.Model.IRepository;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Server.TableManagers
{
    public class AnswerTM : BaseTM<Answer>, IAnswerRepository
    {
        public AnswerTM() :
            base(AnswerRepository.Instance) { }

        public List<Guid> GetApplicationAnswerIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And ApplicationId = '{1}'", _defaultSelectCommand, id));
        }
    }
}
