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
    [DBTable("Question")]
    [DataContract]
    public class Question : Base
    {
        [DataMember]
        private Guid _jobId;
        [DBColumn("JobId")]
        public Guid JobId
        {
            get { return _jobId; }
            set { _jobId = value; }
        }
        public Job Job
        {
            get { return JobRepository.Instance.GetItemById(_jobId); }
            set { _jobId = value.Id; }
        }

        [DataMember]
        private String _text;
        [DBColumn("Text")]
        public String Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        [DataMember]
        [DBColumn("IsDefault")]
        public bool IsDefault { get; set; }

        public Question() : base() { InitProperties(); }

        public Question(Guid id) : base(id) { InitProperties(); }

        private void InitProperties()
        {
            IsDefault = false;
            Text = "Empty";
        }
    }
}
