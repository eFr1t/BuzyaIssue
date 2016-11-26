using EPAM.Model;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Admin.ViewModel
{
    public class QuestionsUCVM : BaseVM
    {
        private ObservableCollection<Question> _questions;
        public ObservableCollection<Question> Questions
        {
            get { return _questions; }
            set
            {
                _questions = value;
                OnPropertyChanged("Questions");
            }
        }

        private Question _selectedQuestion;
        public Question SelectedQuestion
        {
            get { return _selectedQuestion; }
            set
            {
                _selectedQuestion = value;
                OnPropertyChanged("SelectedQuestion");
            }
        }

        private String _questionText;
        public String QuestionText
        {
            get { return _questionText; }
            set
            {
                _questionText = value;
                OnPropertyChanged("QuestionText");
            }
        }

        public QuestionsUCVM()
        {
            Questions = new ObservableCollection<Question>(QuestionRepository.Instance.GetAllDefaultQuestions().OrderBy(i => i.Text));
        }

        public void QuestionsSelectionChanged()
        {
            if (SelectedQuestion == null)
                return;

            QuestionText = SelectedQuestion.Text;
        }

        public void Add()
        {
            Question item = new Question();
            item.IsDefault = true;
            QuestionRepository.Instance.SetItem(item);

            Questions.Add(item);
            SelectedQuestion = item;
        }

        public void Save()
        {
            if (SelectedQuestion == null)
                return;

            SelectedQuestion.Text = QuestionText;

            QuestionRepository.Instance.UpdateItem(SelectedQuestion);
        }

        public void Delete()
        {
            if (SelectedQuestion == null)
                return;

            QuestionRepository.Instance.RemoveItem(SelectedQuestion);
            Questions.Remove(SelectedQuestion);

            QuestionText = "";
        }
    }
}
