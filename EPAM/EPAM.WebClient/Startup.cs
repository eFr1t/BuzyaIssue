using EPAM.IClient_Server;
using EPAM.Model.Repositories;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EPAM.WebClient.Startup))]
namespace EPAM.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            InitProxyServers();
        }

        private void InitProxyServers()
        {
            ProxyServer ps = new ProxyServer();
            AnswerRepository.Instance.Proxy = ps;
            ApplicationRepository.Instance.Proxy = ps;
            AuthorSavedJobRepository.Instance.Proxy = ps;
            AuthorRepository.Instance.Proxy = ps;
            AuthorSkillRepository.Instance.Proxy = ps;
            ClientSavedAuthorRepository.Instance.Proxy = ps;
            ClientRepository.Instance.Proxy = ps;
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
    }
}
