using EPAM.DBAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model
{
    [DBTable("TimeZone")]
    public class TimeZone : Base
    {
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
        [DBColumn("UTCHourValue")]
        public double UTCHourValue { get; set; }

        public TimeZone() : base() { InitProperties(); }

        public TimeZone(Guid id) : base(id) { InitProperties(); }

        private void InitProperties()
        {
            Title = "UTC+00:00 Empty";
            UTCHourValue = 0;
        }
    }
}
