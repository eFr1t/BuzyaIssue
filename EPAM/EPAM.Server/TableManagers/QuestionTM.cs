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
    public class QuestionTM : BaseTM<Question>, IQuestionRepository
    {
        public QuestionTM() :
            base(QuestionRepository.Instance) { }

        public List<Guid> GetApplicationQuestionIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And ApplicationId = '{1}'", _defaultSelectCommand, id));
        }

        public List<Guid> GetJobQuestionIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And JobId = '{1}'", _defaultSelectCommand, id));
        }

        public List<Guid> GetAllDefaultQuestionIds()
        {
            return GetCustomList(_defaultSelectCommand + " And IsDefault = 1");
        }
    }
}
