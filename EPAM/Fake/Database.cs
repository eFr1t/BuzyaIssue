using EPAM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using EPAM.Data.Managers;

namespace EPAM.Serialization
{
    [DataContract]
    public class Database
    {
        static private String filePath = "DB.xaml";

        [DataMember]
        public List<Client> Clients
        {
            get 
            {
                var tmp = new List<Client>();
                foreach (var item in ClientManager.Instance.Clients.Values)
                    if (item is Client)
                        tmp.Add(item as Client);
                return tmp; 
            }
            set
            {
                foreach (var item in value)
                {
                    PersonManager.Instance.Persons.Add(item.Id, item);
                    ClientManager.Instance.Clients.Add(item.Id, item);
                }
            }
        }

        [DataMember]
        public List<Author> Authors
        {
            get
            {
                var tmp = new List<Author>();
                foreach (var item in AuthorManager.Instance.Authors.Values)
                    if (item is Author)
                        tmp.Add(item as Author);
                return tmp;
            }
            set
            {
                foreach (var item in value)
                {
                    PersonManager.Instance.Persons.Add(item.Id, item);
                    AuthorManager.Instance.Authors.Add(item.Id, item);
                }
            }
        }

        [DataMember]
        public List<Job> Jobs
        {
            get { return JobManager.Instance.Jobs.Values.ToList(); }
            set
            {
                var tmp = new Dictionary<Guid, Job>();
                foreach (var item in value)
                    tmp.Add(item.Id, item);
                JobManager.Instance.Jobs = tmp;
            }
        }

        public static void Save()
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(Database));
            XmlWriter xmlw = XmlWriter.Create(filePath);
            dcs.WriteObject(xmlw, new Database());
            xmlw.Close();
        }

        public static void Load()
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                Save();
            }

            PersonManager.Instance.Persons.Clear();
            ClientManager.Instance.Clients.Clear();
            AuthorManager.Instance.Authors.Clear();

            DataContractSerializer dcs = new DataContractSerializer(typeof(Database));
            XmlReader xmlr = XmlReader.Create(filePath);
            dcs.ReadObject(xmlr);
            xmlr.Close();
        }
    }
}
