using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.ViewModel
{
    public class QuestionUCVM : BaseVM
    {
        private Question _question;
        public Question Question
        {
            get { return _question; }
            set
            {
                if (value != _question)
                {
                    _question = value;
                    OnPropertyChanged("Question");
                }
            }
        }

        public QuestionUCVM(Question q)
        {
            Question = q;
        }
    }
}
