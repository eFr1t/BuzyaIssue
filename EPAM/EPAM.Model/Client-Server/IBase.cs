using EPAM.Model.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace EPAM.Model.Client_Server
{
    public interface IBase<T>
    {
        T GetItemById(Guid id);
        void SetItem(T item);
        void RemoveItem(Guid id);
        void UpdateItem(T item);
        List<T> GetAllItems();
        void SetAllItems(List<T> items);
    }
}
