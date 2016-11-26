using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.IRegister
{
    public interface IRegisterClient
    {
        bool Register(Client client);
    }
}
