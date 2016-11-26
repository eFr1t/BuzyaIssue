using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    public class MessageRepository : BaseRepository<Message, IMessageRepository>, IMessageRepository
    {   
        static private MessageRepository _instance;
        static public MessageRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MessageRepository();
                return _instance;
            }
        }

        private MessageRepository() : base() { }

        public List<Message> GetTalkMessages(Talk talk)
        {
            return GetListFromIds(GetTalkMessageIds(talk.Id));
        }

        public List<Guid> GetTalkMessageIds(Guid id)
        {
            return Proxy.GetTalkMessageIds(id);
        }
    }
}
