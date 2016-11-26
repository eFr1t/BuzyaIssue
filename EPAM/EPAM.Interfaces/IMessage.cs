using EPAM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Interfaces
{
    public interface IMessage
    {
        bool CreateMessage(Message message, Person sender, Person reciver);
        bool DeleteMessage(Message message);
    }
}
