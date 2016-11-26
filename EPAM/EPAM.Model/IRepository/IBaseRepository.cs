using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.IRepository
{
    public interface IBaseRepository<T>
    {
        T GetItemById(Guid id);
        bool SetItem(T item);
        bool RemoveItem(Guid id);
        bool UpdateItem(T item);
        List<T> GetAllItems();
    }
}
