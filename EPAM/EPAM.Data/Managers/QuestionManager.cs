using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data.Managers
{
    public class QuestionManager
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

        public Dictionary<Guid, Question> Questions;

        private QuestionManager() 
        {
            Questions = new Dictionary<Guid, Question>();
        }
    }
}
