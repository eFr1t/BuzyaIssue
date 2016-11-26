using EPAM.Model;
using EPAM.Model.Repositories;
using EPAM.Server.ServerServices;
using EPAM.Server.TableManagers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Server
{
    public class StartServer
    {
        public static void Main(string[] args)
        {
            InitializeRepositories();

            //ServiceHost serverHost = new ServiceHost(typeof(ServerService), new Uri("http://77.47.209.188:54585/server"));
            //serverHost.Open();
            ServiceHost registerHost = new ServiceHost(typeof(RegisterService), new Uri("http://77.47.209.188:54585/server"));
            registerHost.Open();
            Console.WriteLine("Press ENTER to stop services...");
            Console.ReadLine();
            //serverHost.Abort();
            //serverHost.Close();
            registerHost.Abort();
            registerHost.Close(); 
        }

        private static void InitializeRepositories()
        {
            ClientRepository.Instance.RegisterProxy = new ClientTM();
            AuthorRepository.Instance.RegisterProxy = new AuthorTM();

            AnswerRepository.Instance.Proxy = new AnswerTM();
            ApplicationRepository.Instance.Proxy = new ApplicationTM();
            AuthorSavedJobRepository.Instance.Proxy = new AuthorSavedJobTM();
            AuthorRepository.Instance.Proxy = new AuthorTM();
            AuthorSkillRepository.Instance.Proxy = new AuthorSkillTM();
            ClientSavedAuthorRepository.Instance.Proxy = new ClientSavedAuthorTM();
            ClientRepository.Instance.Proxy = new ClientTM();
            JobCategoryRepository.Instance.Proxy = new JobCategoryTM();
            JobFilterRepository.Instance.Proxy = new JobFilterTM();
            JobSkillRepository.Instance.Proxy = new JobSkillTM();
            JobSubcategoryRepository.Instance.Proxy = new JobSubcategoryTM();
            JobRepository.Instance.Proxy = new JobTM();
            MessageRepository.Instance.Proxy = new MessageTM();
            QuestionRepository.Instance.Proxy = new QuestionTM();
            SkillRepository.Instance.Proxy = new SkillTM();
            StageRepository.Instance.Proxy = new StageTM();
            TalkRepository.Instance.Proxy = new TalkTM();
            TimeZoneRepository.Instance.Proxy = new TimeZoneTM();
        }
    }
}
