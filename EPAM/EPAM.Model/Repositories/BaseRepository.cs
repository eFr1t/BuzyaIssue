using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    public class BaseRepository<T, U> : IBaseRepository<T>
        where T : Base 
        where U : IBaseRepository<T>
    {
        public U Proxy { get; set; }

        private Dictionary<Guid, T> _items;

        protected BaseRepository()
        {
            _items = new Dictionary<Guid, T>();
        }

        public T GetItemById(Guid id)
        {
            if (id.Equals(Guid.Empty))
                return null;

            if (_items.ContainsKey(id))
                return _items[id];

            if (Proxy != null)
                return Proxy.GetItemById(id);

            return null;
        }

        public bool SetItem(T item)
        {
            if (item == null || _items.ContainsKey(item.Id) || !Proxy.SetItem(item))
                return false;

            _items.Add(item.Id, item);
            return true;
        }

        public bool RemoveItem(Guid id)
        {
            if (id.Equals(Guid.Empty) || !Proxy.RemoveItem(id))
                return false;

            if(_items.ContainsKey(id))
                _items.Remove(id);

            return true;
        }

        public bool RemoveItem(T item)
        {
            if (item == null)
                return false;

            return RemoveItem(item.Id);
        }

        public bool UpdateItem(T item)
        {
            if (item == null || !Proxy.UpdateItem(item))
                return false;

            if(_items.ContainsKey(item.Id))
                _items.Remove(item.Id);

            _items.Add(item.Id, item);
            return true;
        }

        public List<T> GetAllItems()
        {
            List<T> buf = Proxy.GetAllItems();

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

        protected List<T> GetListFromIds(List<Guid> guids)
        {
            List<T> list = new List<T>();

            if(guids != null)
            {
                foreach (Guid id in guids)
                {
                    T item = GetItemById(id);
                    if(item != null)
                        list.Add(item);
                }
            }

            return list;
        }
    }
}
