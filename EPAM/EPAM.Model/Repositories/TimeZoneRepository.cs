using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    public class TimeZoneRepository : BaseRepository<TimeZone, ITimeZoneRepository>, ITimeZoneRepository
    {      
        static private TimeZoneRepository _instance;
        static public TimeZoneRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TimeZoneRepository();
                return _instance;
            }
        }

        private TimeZoneRepository() : base() { }
    }
}
