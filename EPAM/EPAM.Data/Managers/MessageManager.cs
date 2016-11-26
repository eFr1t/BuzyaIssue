using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data.Managers
{
    public class MessageManager
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

        public Dictionary<Guid, Message> Messages;

        private MessageManager() 
        {
            Messages = new Dictionary<Guid, Message>();
        }
    }
}
