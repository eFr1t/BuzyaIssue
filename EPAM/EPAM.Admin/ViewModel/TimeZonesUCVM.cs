using EPAM.Model;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Admin.ViewModel
{
    public class TimeZonesUCVM : BaseVM
    {
        private ObservableCollection<Model.TimeZone> _timeZones;
        public ObservableCollection<Model.TimeZone> TimeZones
        {
            get { return _timeZones; }
            set 
            { 
                _timeZones = value;
                OnPropertyChanged("TimeZones");
            }
        }

        private Model.TimeZone _selectedTimeZone;
        public Model.TimeZone SelectedTimeZone
        {
            get { return _selectedTimeZone; }
            set 
            {
                _selectedTimeZone = value;
                OnPropertyChanged("SelectedTimeZone");
            }
        }

        private String _resultTitle;
        public String ResultTitle
        {
            get { return _resultTitle; }
            set
            {
                _resultTitle = value;
                OnPropertyChanged("ResultTitle");
            }
        }

        private String _title;
        public String Title
        {
            get { return _title; }
            set
            {
                _title = value;
                SetResultTitle();
                OnPropertyChanged("Title");
            }
        }

        private List<String> _hours;
        public List<String> Hours
        {
            get { return _hours; }
            set
            {
                _hours = value;
                OnPropertyChanged("Hours");
            }
        }

        private int _selectedHourIndex;
        public int SelectedHourIndex
        {
            get { return _selectedHourIndex; }
            set
            {
                _selectedHourIndex = value;
                SetResultTitle();
                OnPropertyChanged("SelectedHourIndex");
            }
        }

        private List<String> _minutes;
        public List<String> Minutes
        {
            get { return _minutes; }
            set
            {
                _minutes = value;
                OnPropertyChanged("Minutes");
            }
        }

        private int _selectedMinutesIndex;
        public int SelectedMinutesIndex
        {
            get { return _selectedMinutesIndex; }
            set
            {
                _selectedMinutesIndex = value;
                SetResultTitle();
                OnPropertyChanged("SelectedMinutesIndex");
            }
        }

        public TimeZonesUCVM()
        {
            Minutes = new List<String>();
            for (int i = 0; i < 60; i += 15)
                Minutes.Add(i.ToString().PadLeft(2, '0'));

            Hours = new List<String>();
            for (int i = -11; i < 13; i++)
                Hours.Add((Math.Sign(i) < 0 ? "-" : "+") + Math.Abs(i).ToString().PadLeft(2, '0'));

            SetResultTitle();

            TimeZones = new ObservableCollection<Model.TimeZone>(TimeZoneRepository.Instance.GetAllItems().OrderBy(i => i.UTCHourValue));
        }

        private void SetResultTitle()
        {
            ResultTitle = "UTC" + Hours.ElementAt(SelectedHourIndex) + ":" + Minutes.ElementAt(SelectedMinutesIndex) + " " + Title;
        }

        public void TimeZonesSelectionChanged()
        {
            if (SelectedTimeZone == null)
                return;

            int hour = (int)Math.Truncate(SelectedTimeZone.UTCHourValue);
            SelectedHourIndex = hour + 11;
            SelectedMinutesIndex = (int)Math.Truncate(Math.Abs((SelectedTimeZone.UTCHourValue - hour) * 4));

            Title = SelectedTimeZone.Title == null ? "" : SelectedTimeZone.Title.Substring(SelectedTimeZone.Title.IndexOf(" ") + 1);
        }

        public void Add()
        {
            Model.TimeZone item = new Model.TimeZone();
            TimeZoneRepository.Instance.SetItem(item);

            TimeZones.Add(item);
            SelectedTimeZone = item;
        }

        public void Save()
        {
            if (SelectedTimeZone == null)
                return;

            SelectedTimeZone.Title = ResultTitle;
            int hour = SelectedHourIndex - 11;
            int sign = Math.Sign(hour);
            SelectedTimeZone.UTCHourValue = sign * (Math.Abs(hour) + SelectedMinutesIndex / 4.0);

            TimeZoneRepository.Instance.UpdateItem(SelectedTimeZone);
        }

        public void Delete()
        {
            if (SelectedTimeZone == null)
                return;

            TimeZoneRepository.Instance.RemoveItem(SelectedTimeZone);
            TimeZones.Remove(SelectedTimeZone);

            Title = "";
            SelectedHourIndex = 11;
            SelectedMinutesIndex = 0;
        }
    }
}
