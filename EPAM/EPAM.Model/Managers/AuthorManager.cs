using EPAM.Model;
using EPAM.Model.Client_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Managers
{
    public class AuthorManager : BaseManager<Author>, IAuthor
    {
        static private AuthorManager _instance;
        static public AuthorManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AuthorManager();
                return _instance;
            }
        }

        private AuthorManager() : base() { }
    }
}
