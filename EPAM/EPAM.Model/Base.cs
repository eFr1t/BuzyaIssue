using EPAM.DBAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model
{
    [DataContract]
    public class Base :  INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }

        [DataMember]
        [DBColumn("Id")]
        public Guid Id { get; protected set; }

        public Base(Guid id) { Id = id; }

        public Base() : this(Guid.NewGuid()) { }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Base))
                return false;

            return Id == (obj as Base).Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
