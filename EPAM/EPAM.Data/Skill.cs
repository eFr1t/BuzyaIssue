using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data
{
    [DataContract]
    public class Skill
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public String Title { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public String Link { get; set; }

        public Skill() { Id = Guid.NewGuid(); }

    }
}
