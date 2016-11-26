using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    public class QuestionRepository : BaseRepository<Question, IQuestionRepository>, IQuestionRepository
    {   
        static private QuestionRepository _instance;
        static public QuestionRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new QuestionRepository();
                return _instance;
            }
        }

        private QuestionRepository() : base() { }

        public List<Question> GetJobQuestions(Job job)
        {
            return GetListFromIds(GetJobQuestionIds(job.Id));
        }

        public List<Question> GetAllDefaultQuestions()
        {
            return GetListFromIds(GetAllDefaultQuestionIds());
        }

        public List<Guid> GetJobQuestionIds(Guid id)
        {
            return Proxy.GetJobQuestionIds(id);
        }

        public List<Guid> GetAllDefaultQuestionIds()
        {
            return Proxy.GetAllDefaultQuestionIds();
        }
    }
}
