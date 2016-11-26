using EPAM.Model.Client_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Managers
{
    public class MessageManager : BaseManager<Message>, IMessage
    {   
        static private MessageManager _instance;
        static public MessageManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MessageManager();
                return _instance;
            }
        }

        private MessageManager() : base() { }

        public List<Message> GetTalkMessages(Talk talk)
        {
            throw new NotImplementedException();
        }
    }
}
