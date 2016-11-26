using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Client_Server
{
    public interface IMessage
    {
        bool CreateMessage(Message message, Person sender, Person reciver);
        bool DeleteMessage(Message message);
    }
}
