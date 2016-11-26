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
    [DBTable("Message")]
    [DataContract]
    public class Message : Base
    {
        [DataMember]
        private Guid _talkId;
        [DBColumn("TalkId")]
        public Guid TalkId
        {
            get { return _talkId; }
            set { _talkId = value; }
        }
        public Talk Talk
        {
            get { return TalkRepository.Instance.GetItemById(_talkId); }
            set { _talkId = value.Id; }
        }

        [DataMember]
        private Guid _personId;
        [DBColumn("PersonId")]
        public Guid PersonId
        {
            get { return _personId; }
            set { _personId = value; }
        }
        public Person Sender
        {
            get { return PersonRepository.Instance.GetItemById(_personId); }
            set { _personId = value.Id; }
        }

        [DataMember]
        [DBColumn("Name")]
        String Name { get; set; }
        [DataMember]
        [DBColumn("Text")]
        String Text { get; set; }
        [DataMember]
        [DBColumn("DateTime")]
        DateTime DateTime { get; set; }

        public Message() : base() { }

        public Message(Guid id) : base(id) { }
    }
}
