using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.DBAttribute
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class DBColumnAttribute : Attribute
    {
        public String Name { get; private set; }

        public DBColumnAttribute(String name)
        {
            Name = name;
        }
    }
}
