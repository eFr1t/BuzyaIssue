using EPAM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Interfaces
{
    public interface IQuestion
    {
        bool CreateQuestion(Question question);
        bool DeleteQuestion(Question question);
        bool AnswerQuestion(Question question);
    }
}
