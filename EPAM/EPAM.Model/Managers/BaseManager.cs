using EPAM.Model.Client_Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Managers
{
    public class BaseManager<T> : IBase<T>
        where T : Base 
    {
        public IProxy Proxy { private get; set; }

        private Dictionary<Guid, T> _items;

        protected BaseManager()
        {
            _items = new Dictionary<Guid, T>();
        }

        public T GetItemById(Guid id)
        {
            if (_items.ContainsKey(id))
                return _items[id];

            if (Proxy != null)
                return (T)Proxy.GetItemById(id, typeof(T));

            return null;
        }

        public void SetItem(T item)
        {
            if (_items.ContainsKey(item.Id))
                return;

            _items.Add(item.Id, item);

            Proxy.SetItem(item);
        }

        public void RemoveItem(Guid id)
        {
            if (!_items.ContainsKey(id))
                return;

            _items.Remove(id);

            Proxy.RemoveItem(id, typeof(T));
        }

        public void UpdateItem(T item)
        {
            if (!_items.ContainsKey(item.Id))
                return;

            _items.Remove(item.Id);
            _items.Add(item.Id, item);

            Proxy.UpdateItem(item);
        }

        public List<T> GetAllItems()
        {
            List<T> buf = Proxy.GetAllItems(typeof(T)).Cast<T>().ToList();

            if (buf == null)
                return new List<T>();

            _items.Clear();
            foreach (var item in buf)
                _items.Add(item.Id, item);

            return new List<T>(buf);
        }

        public void SetAllItems(List<T> items)
        {
            if (items == null)
                return;

            foreach (var item in items)
                SetItem(item);
        }

        public List<T> GetCurrentItems()
        {
            return new List<T>(_items.Values);
        }
    }
}
