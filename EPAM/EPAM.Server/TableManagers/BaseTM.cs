using EPAM.DBAttribute;
using EPAM.Model;
using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Server.TableManagers
{
    public abstract class BaseTM<T> : IBaseRepository<T> where T : Base, new()
    {
        protected String _connetionString = "Data Source=VELYKYI;Initial Catalog=EPAM;Integrated Security=True";
        protected SqlConnection _connection;
        protected SqlDataAdapter _adapter;

        protected readonly Dictionary<PropertyInfo, String> _mapper;

        protected String _defaultSelectCommand;

        protected IBaseRepository<T> _repository;

        private Object _lock;

        protected BaseTM(IBaseRepository<T> repository)
        {
            DBTableAttribute attr = typeof(T).GetCustomAttribute(typeof(DBTableAttribute), true) as DBTableAttribute;
            if (attr != null)
            {
                _defaultSelectCommand = String.Format("Select * From {0} Where IsDeleted = 0", attr.Name);

                InitializeAdapter();

                _adapter.DeleteCommand = new SqlCommand(String.Format("Update {0} Set IsDeleted = 1 Where Id = @Id", attr.Name));
                _adapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.UniqueIdentifier, 50, "Id");
            }

            _mapper = new Dictionary<PropertyInfo, String>();
            InitializeMapper();

            _repository = repository;

            _lock = new Object();
        }

        private void InitializeMapper()
        {
            var list = from p in typeof(T).GetProperties()
                       let attr = p.GetCustomAttributes(typeof(DBColumnAttribute), true)
                       where attr.Length == 1
                       select new { Property = p, Attribute = attr.First() as DBColumnAttribute };
            foreach (var item in list)
                _mapper.Add(item.Property, item.Attribute.Name);
        }

        protected BaseTM(String query, IBaseRepository<T> repository)
            : this(repository)
        {
            _defaultSelectCommand = query;

            InitializeAdapter();
        }

        private void InitializeAdapter()
        {
            _connection = new SqlConnection(_connetionString);
            _adapter = new SqlDataAdapter(_defaultSelectCommand, _connection);
            new SqlCommandBuilder(_adapter);
        }

        protected T GetItemFromDataRow(DataRow dr)
        {
            T item = new T();
            foreach (var key in _mapper.Keys)
                if (DBNull.Value.Equals(dr[_mapper[key]]))
                    if (dr[_mapper[key]].GetType() == typeof(Guid))
                        key.SetValue(item, new Guid(), null);
                    else if (dr[_mapper[key]].GetType() == typeof(Guid))
                        key.SetValue(item, DateTime.MinValue, null);
                    else
                        key.SetValue(item, null, null);
                else
                    key.SetValue(item, dr[_mapper[key]], null);
            return item;
        }

        protected void FillDataRowFromItem(T item, DataRow dr)
        {
            foreach (var key in _mapper.Keys)
                dr[_mapper[key]] = (key.GetValue(item) == null ||
                    key.GetValue(item).GetType() == typeof(DateTime) && key.GetValue(item).Equals(DateTime.MinValue) ||
                    key.GetValue(item).GetType() == typeof(Guid) && key.GetValue(item).Equals(new Guid()))
                    ? DBNull.Value : key.GetValue(item);
            dr["IsDeleted"] = false;
        }

        protected void FillDataTableWithItemById(DataTable dt, Guid id)
        {
            lock (_lock)
            {
                _adapter.SelectCommand = new SqlCommand(String.Format("{0} And Id = '{1}'", _defaultSelectCommand, id), _connection);
                _adapter.Fill(dt);
            }
        }

        public T GetItemById(Guid id)
        {
            DataTable dt = new DataTable();
            FillDataTableWithItemById(dt, id);
            if (dt.Rows.Count == 0)
                return null;
            return GetItemFromDataRow(dt.Rows[0]);
        }

        public bool SetItem(T item)
        {
            DataTable dt = new DataTable();
            lock (_lock)
            {
                _adapter.FillSchema(dt, SchemaType.Source);
            }
            DataRow dr = dt.NewRow();
            FillDataRowFromItem(item, dr);
            dt.Rows.Add(dr);
            lock (_lock)
            {
                _adapter.Update(dt);
            }
            return true;
        }

        public bool RemoveItem(Guid id)
        {
            DataTable dt = new DataTable();
            FillDataTableWithItemById(dt, id);

            if (dt.Rows.Count == 0)
                return false;

            dt.Rows[0].Delete();
            lock (_lock)
            {
                _adapter.Update(dt);
            }
            return true;
        }

        public bool UpdateItem(T item)
        {
            DataTable dt = new DataTable();
            FillDataTableWithItemById(dt, item.Id);

            if (dt.Rows.Count == 0)
                return false;

            FillDataRowFromItem(item, dt.Rows[0]);
            lock (_lock)
            {
                _adapter.Update(dt);
            }
            return true;
        }

        public List<T> GetAllItems()
        {
            DataTable dt = new DataTable();
            lock (_lock)
            {
                _adapter.SelectCommand = new SqlCommand(_defaultSelectCommand, _connection);
                _adapter.Fill(dt);
            }
            List<T> res = new List<T>();
            foreach (DataRow row in dt.Rows)
                res.Add(GetItemFromDataRow(row));
            return res;
        }

        public void SetAllItems(List<T> items)
        {
            foreach (T item in items)
                SetItem(item);
        }

        protected List<Guid> GetCustomList(String query)
        {
            DataTable dt = new DataTable();

            lock (_lock)
            {
                _adapter.SelectCommand = new SqlCommand(query, _connection);
                _adapter.Fill(dt);
            }

            List<Guid> list = new List<Guid>();
            foreach (DataRow row in dt.Rows)
                list.Add((Guid)row["Id"]);

            return list;
        }
    }
}
