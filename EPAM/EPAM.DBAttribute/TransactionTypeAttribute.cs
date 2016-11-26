using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.DBAttribute
{
    [AttributeUsage(AttributeTargets.Method, Inherited=true, AllowMultiple=false)]
    public class TransactionTypeAttribute : Attribute
    {
        public TransactionTypes TransactionType { get; private set; }
        public int CacheSize { get; private set; }

        public TransactionTypeAttribute(TransactionTypes transactionType, int cacheSize)
        {
            TransactionType = transactionType;
            CacheSize = cacheSize;
        }

        public TransactionTypeAttribute(TransactionTypes transactionType) : this(transactionType, 0) { }
    }
}
