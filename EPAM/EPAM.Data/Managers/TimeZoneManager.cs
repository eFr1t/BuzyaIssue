using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data.Managers
{
    public class TimeZoneManager
    {      
        static private TimeZoneManager _instance;
        static public TimeZoneManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TimeZoneManager();
                return _instance;
            }
        }

        public List<String> TimeZones;

        private TimeZoneManager() 
        {
            TimeZones = new List<String>();
        }
    }
}
