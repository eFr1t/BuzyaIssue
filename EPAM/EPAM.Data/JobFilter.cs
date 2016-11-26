using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data
{
    [DataContract]
    public class JobFilter
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public String Category { get; set; }
        [DataMember]
        public String Subcategory { get; set; }
        [DataMember]
        public int BudgetMin { get; set; }
        [DataMember]
        public int BudgetMax { get; set; }
        [DataMember]
        public String TimeToDeadlineFromNow { get; set; }
        [DataMember]
        public String SearchString { get; set; }

        public JobFilter() { Id = Guid.NewGuid(); }
    }
}
