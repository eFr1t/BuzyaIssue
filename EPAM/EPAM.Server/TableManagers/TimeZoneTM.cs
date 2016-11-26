using EPAM.Model;
using EPAM.Model.IRepository;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Server.TableManagers
{
    public class TimeZoneTM : BaseTM<Model.TimeZone>, ITimeZoneRepository
    {
        public TimeZoneTM() :
            base(TimeZoneRepository.Instance) { }
    }
}
