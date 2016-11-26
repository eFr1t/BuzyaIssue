using EPAM.Data.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data
{
    public class Message
    {
        public Guid Id { get; private set; }

        String Name { get; set; }
        String Text { get; set; }
        String DateTime { get; set; }

        private Guid _talkId;
        public Talk Talk
        {
            get { return TalkManager.Instance.Talks[_talkId]; }
            set { _talkId = value.Id; }
        }

        private Guid _personId;
        public Person Sender
        {
            get { return PersonManager.Instance.Persons[_personId]; }
            set { _personId = value.Id; }
        }

        public Message(String name, String text, String dateTime)
        {
            Id = Guid.NewGuid();

            Name = name; Text = text; DateTime = dateTime;
        }
    }
}
