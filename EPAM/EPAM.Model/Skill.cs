using EPAM.DBAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model
{
    [DBTable("Skill")]
    [DataContract]
    public class Skill : Base
    {
        [DataMember]
        private String _title;
        [DBColumn("Title")]
        public String Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        [DataMember]
        [DBColumn("Description")]
        public String Description { get; set; }
        [DataMember]
        [DBColumn("Link")]
        public String Link { get; set; }

        public Skill() : base() { InitProperties(); }

        public Skill(Guid id) : base(id) { InitProperties(); }

        private void InitProperties()
        {
            Title = "Empty";
        }
    }
}
