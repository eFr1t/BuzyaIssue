using EPAM.IClient_Server;
using EPAM.Model;
using EPAM.Model.Repositories;
using EPAM.WPF_Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EPAM.ViewModel
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

        public Person Person { get; private set; }

        private AppVM() 
        {
            InitProxyServers();
        }

        private void InitProxyServers()
        {
            ProxyServer ps = new ProxyServer();
            ApplicationRepository.Instance.Proxy = ps;
            AuthorRepository.Instance.Proxy = ps;
            AuthorSkillRepository.Instance.Proxy = ps;
            ClientRepository.Instance.Proxy = ps;
            ContractRepository.Instance.Proxy = ps;
            JobCategoryRepository.Instance.Proxy = ps;
            JobFilterRepository.Instance.Proxy = ps;
            JobRepository.Instance.Proxy = ps;
            JobSkillRepository.Instance.Proxy = ps;
            JobSubcategoryRepository.Instance.Proxy = ps;
            MessageRepository.Instance.Proxy = ps;
            QuestionRepository.Instance.Proxy = ps;
            SkillRepository.Instance.Proxy = ps;
            StageRepository.Instance.Proxy = ps;
            TalkRepository.Instance.Proxy = ps;
            TimeZoneRepository.Instance.Proxy = ps;

            ProxyRegister pr = new ProxyRegister();
            AuthorRepository.Instance.RegisterProxy = pr;
            ClientRepository.Instance.RegisterProxy = pr;
        }

        public void Login(String login, String password)
        {
            Person = PersonRepository.Instance.Login(login, password);
        }
    }
}
