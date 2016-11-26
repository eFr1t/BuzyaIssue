using EPAM.DBAttribute;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model
{
    [DBTable("Answer")]
    [DataContract]
    public class Answer : Base
    {
        [DataMember]
        private Guid _applicationId;
        [DBColumn("ApplicationId")]
        public Guid ApplicationId
        {
            get { return _applicationId; }
            set { _applicationId = value; }
        }
        public Application Application
        {
            get { return ApplicationRepository.Instance.GetItemById(_applicationId); }
            set { _applicationId = value.Id; }
        }

        [DataMember]
        private Guid _questionId;
        [DBColumn("QuestionId")]
        public Guid QuestionId
        {
            get { return _questionId; }
            set { _questionId = value; }
        }
        public Question Question
        {
            get { return QuestionRepository.Instance.GetItemById(_questionId); }
            set { _questionId = value.Id; }
        }

        [DataMember]
        [DBColumn("Text")]
        public String Text { get; set; }

        public Answer() : base() { }

        public Answer(Guid id) : base(id) { }
    }
}
