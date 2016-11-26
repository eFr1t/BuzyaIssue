﻿using EPAM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Interfaces
{
    public interface IClient
    {
        Client GetClientById(Guid id);
        bool EditClientInfo(Client client);
    }
}
