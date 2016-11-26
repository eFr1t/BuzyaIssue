using EPAM.Model;
using EPAM.Model.IRepository;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Server.TableManagers
{
    public class MessageTM : BaseTM<Message>, IMessageRepository
    {
        public MessageTM() :
            base(MessageRepository.Instance) { }

        public List<Guid> GetTalkMessageIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And TalkId = '{1}'", _defaultSelectCommand, id));
        }
    }
}
