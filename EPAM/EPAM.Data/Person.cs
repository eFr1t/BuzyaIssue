using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data
{
    [DataContract]
    public abstract class Person
    {        
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String SName { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String TimeZone { get; set; }

        [DataMember]
        private String _login;
        [DataMember]
        private String _password;

        public Person(Guid id, String login, String password) 
        {
            Id = id; 
            _login = login;
            _password = password;
        }

        public Person(String login, String password) : this(Guid.NewGuid(), login, password) { }

        public Person(Guid id) { Id = id; }

        public bool IsIt(String login, String password)
        {
            return _login == login && _password == password;
        }
    }
}
