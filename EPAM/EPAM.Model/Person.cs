using EPAM.DBAttribute;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model
{
    [DataContract]
    [KnownType(typeof(Client))]
    [KnownType(typeof(Author))]
    public abstract class Person : Base
    {
        [DataMember]
        private Guid _timeZoneId;
        [DBColumn("TimeZoneId")]
        public Guid TimeZoneId
        {
            get { return _timeZoneId; }
            set { _timeZoneId = value; }
        }
        public TimeZone TimeZone
        {
            get { return TimeZoneRepository.Instance.GetItemById(_timeZoneId); }
            set { _timeZoneId = value.Id; }
        }

        [DataMember]
        [DBColumn("Name")]
        public String Name { get; set; }
        [DataMember]
        [DBColumn("SName")]
        public String SName { get; set; }
        [DataMember]
        [DBColumn("Email")]
        public String Email { get; set; }
        [DataMember]
        [DBColumn("Login")]
        public String Login { get; set; }
        [DataMember]
        [DBColumn("Password")]
        public String Password { get; set; }

        public Person() : base() { }

        public Person(Guid id) : base(id) { }
    }
}
