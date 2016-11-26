using EPAM.Model.Client_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Managers
{
    public class QuestionManager : BaseManager<Question>, IQuestion
    {   
        static private QuestionManager _instance;
        static public QuestionManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new QuestionManager();
                return _instance;
            }
        }

        private QuestionManager() : base() { }

        public List<Question> GetApplicationQuestions(Application application)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetJobQuestions(Job job)
        {
            throw new NotImplementedException();
        }
    }
}
