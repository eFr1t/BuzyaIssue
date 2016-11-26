using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.DBAttribute
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class DBTableAttribute : Attribute
    {
        public String Name { get; private set; }

        public DBTableAttribute(String name)
        {
            Name = name;
        }
    }
}
