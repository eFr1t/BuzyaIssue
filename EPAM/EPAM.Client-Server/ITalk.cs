using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Client_Server
{
    public interface ITalk
    {
        bool CreateTalk(Talk talk);
        List<Message> GetTalkMessages(Talk talk);
    }
}
