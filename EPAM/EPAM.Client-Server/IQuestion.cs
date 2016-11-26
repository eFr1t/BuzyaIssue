using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Client_Server
{
    public interface IQuestion
    {
        bool CreateQuestion(Question question);
        bool DeleteQuestion(Question question);
        bool AnswerQuestion(Question question);
    }
}
