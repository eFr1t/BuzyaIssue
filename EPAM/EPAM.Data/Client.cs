using EPAM.Data.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EPAM.Data
{
    [DataContract]
    public class Client : Person
    {
        [DataMember]
        public bool IsCompany { get; set; }
        [DataMember]
        public String CompanyName { get; set; }
        [DataMember]
        public String Overview { get; set; }

        public List<Job> Jobs
        {
            get
            {
                List<Job> res = new List<Job>();
                foreach (var job in JobManager.Instance.Jobs)
                    if (job.Value.Client == this)
                        res.Add(job.Value);
                return res;
            }
        }

        public Client(String login, String password)
            : base(login, password)
        {
            IsCompany = false;
            CompanyName = "";
            Overview = "";
        }

        public Client(Guid id, String login, String password) : base(id, login, password) { }
        
        public Client(Guid id) : base(id) { }
    }
}
