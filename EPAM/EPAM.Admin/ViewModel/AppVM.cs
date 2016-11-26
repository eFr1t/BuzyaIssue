using EPAM.IClient_Server;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Admin.ViewModel
{
    public class AppVM
    {
        static private AppVM _instance;
        static public AppVM Instace
        {
            get
            {
                if (_instance == null)
                    _instance = new AppVM();
                return _instance;
            }
        }

        private AppVM()
        {
            InitProxyServers();
        }

        private void InitProxyServers()
        {
            ProxyServer ps = new ProxyServer();
            JobCategoryRepository.Instance.Proxy = ps;
            JobSubcategoryRepository.Instance.Proxy = ps;
            QuestionRepository.Instance.Proxy = ps;
            SkillRepository.Instance.Proxy = ps;
            TimeZoneRepository.Instance.Proxy = ps;
        }
    }
}
