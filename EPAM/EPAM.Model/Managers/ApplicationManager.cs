using EPAM.Model.Client_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Managers
{
    public class ApplicationManager : BaseManager<Application>, IApplication
    {
        static private ApplicationManager _instance;
        static public ApplicationManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ApplicationManager();
                return _instance;
            }
        }

        private ApplicationManager() : base() { }

        public List<Application> GetJobApplications(Job job)
        {
            throw new NotImplementedException();
        }

        public List<Application> GetAuthorApplications(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
