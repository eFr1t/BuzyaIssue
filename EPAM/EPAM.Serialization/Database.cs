using EPAM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace EPAM.Serialization
{
    [DataContract]
    public class Database
    {
        [DataMember]
        public List<Person> Persons
        {
            set
            {
                var tmp = new Dictionary<Guid, Person>();
                foreach (var item in value)
                    tmp.Add(item.PersonId, item);
                Library.Instance.Persons = tmp;
            }
        }

        [DataMember]
        public List<Client> Clients
        {
            set
            {
                var tmp = new Dictionary<Guid, Client>();
                foreach (var item in value)
                    tmp.Add(item.PersonId, item);
                Library.Instance.Clients = tmp;
            }
        }

        [DataMember]
        public List<Author> Authors
        {
            set
            {
                var tmp = new Dictionary<Guid, Author>();
                foreach (var item in value)
                    tmp.Add(item.PersonId, item);
                Library.Instance.Authors = tmp;
            }
        }

        internal static void Save()
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(Database));
            XmlWriter xmlw = XmlWriter.Create("DB.xml");
            dcs.WriteObject(xmlw, new Database());
            xmlw.Close();
        }

        internal static void Load()
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(Database));
            XmlReader xmlr = XmlReader.Create("DB.xml");
            dcs.ReadObject(xmlr);
            xmlr.Close();
        }
    }
}
