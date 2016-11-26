using EPAM.Data.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data
{
    public class Talk
    {
        public Guid Id { get; private set; }

        private Guid _clientId;
        public Client Client
        {
            get { return ClientManager.Instance.Clients[_clientId]; }
            set { _clientId = value.Id; }
        }

        private Guid _authorId;
        public Author Author
        {
            get { return AuthorManager.Instance.Authors[_authorId]; }
            set { _authorId = value.Id; }
        }

        private Guid _jobId;
        public Job Job
        {
            get { return JobManager.Instance.Jobs[_jobId]; }
            set { _jobId = value.Id; }
        }

        public Talk(Client client, Author author, Job job)
        {
            Id = Guid.NewGuid();

            Client = client; Author = author; Job = Job;
        }

        
    }
}
