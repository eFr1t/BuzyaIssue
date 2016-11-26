using EPAM.Model;
using EPAM.Model.Managers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.MSSQL
{
    public class Database
    {
        static private Database _instance;
        static public Database Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Database();
                return _instance;
            }
        }

        private String connetionString = "Data Source=VELYKYI;Initial Catalog=EPAM;Integrated Security=True";
        private SqlConnection cnn;

        private Database()
        {
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                Load();
                cnn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public void Insert(Person p, String login, String pass)
        {
            if (p.IsIt(login, pass))
            {
                ConnectionState state = cnn.State;
                //if (cnn.State == ConnectionState.Closed)
                //    cnn.Open();
                String query = String.Format("INSERT INTO Person VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                    p.Id, p.Name, p.SName, p.Email, p.TimeZone, login, pass);
                if (p.GetType() == typeof(Client))
                {
                    Client c = p as Client;
                    query += String.Format("INSERT INTO Client VALUES('{0}', '{1}', '{2}', '{3}')",
                        c.Id, c.IsCompany, c.CompanyName, c.Overview);
                }
                else
                {
                    Author a = p as Author;
                    query += String.Format("INSERT INTO Author VALUES('{0}', '{1}', '{2}', '{3}')",
                        a.Id, a.Title, a.PhotoPath, a.Overview);
                }
                new SqlCommand(query, cnn).ExecuteNonQuery();
            }
            else
                throw new ArgumentException("Another login and password");
        }

        public void Save()
        {
            //ConnectionState state = cnn.State;
            //if (cnn.State == ConnectionState.Closed)
            //    cnn.Open();
            //String query = "";
            //foreach (JobCategory jc in JobCategoryManager.Instance.JobCategorys.Values)
            //    query += String.Format("INSERT INTO JobCategory VALUES('{0}', '{1}', '{2}')", jc.Id, jc.Name, jc.Description);
            //foreach (JobSubcategory jsc in JobSubcategoryManager.Instance.JobSubcategorys.Values)
            //    query += String.Format("INSERT INTO JobSubcategory VALUES('{0}', '{1}', '{2}', '{3}')", jsc.Id, jsc.JobCategory.Id, jsc.Name, jsc.Description);
            //SqlDataAdapter adapter = new SqlDataAdapter();
            //adapter.InsertCommand = new SqlCommand(query, cnn);
            //adapter.InsertCommand.ExecuteNonQuery();
        }

        public void Load()
        {
            //Persons
            //PersonManager.Instance.Persons = new Dictionary<Guid, Person>();
            //Clients
            ClientManager.Instance.Clients = new Dictionary<Guid, Client>();
            ConnectionState state = cnn.State;
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            String query = "Select * From Person p INNER JOIN Client c on p.Id = c.PersonId";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
            adapter.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                Guid id = (Guid)row["Id"];
                Client c = new Client(id, (String)row["Login"], (String)row["Password"]);
                c.Name = (String)row["Name"];
                c.SName = (String)row["SName"];
                c.Email = (String)row["Email"];
                c.TimeZone = (String)row["TimeZone"];
                c.IsCompany = (bool)row["IsCompany"];
                c.CompanyName = (String)row["CompanyName"];
                c.Overview = (String)row["Overview"];
                ClientManager.Instance.Clients.Add(id, c);
                //PersonManager.Instance.Persons.Add(id, c);
            }
            //Authors
            AuthorManager.Instance.Authors = new Dictionary<Guid, Author>();
            state = cnn.State;
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            query = "Select * From Person p INNER JOIN Author a on p.Id = a.PersonId";
            dt = new DataTable();
            adapter = new SqlDataAdapter(query, cnn);
            adapter.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                Guid id = (Guid)row["Id"];
                Author a = new Author(id, (String)row["Login"], (String)row["Password"]);
                a.Name = (String)row["Name"];
                a.SName = (String)row["SName"];
                a.Email = (String)row["Email"];
                a.TimeZone = (String)row["TimeZone"];
                a.Title = (String)row["Title"];
                a.PhotoPath = (String)row["PhotoPath"];
                a.Overview = (String)row["Overview"];
                AuthorManager.Instance.Authors.Add(id, a);
                //PersonManager.Instance.Persons.Add(id, a);
            }

            //JobCategories
            JobCategoryManager.Instance.JobCategorys = new Dictionary<Guid, JobCategory>();

            state = cnn.State;
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            query = "Select * From JobCategory";
            dt = new DataTable();
            adapter = new SqlDataAdapter(query, cnn);
            adapter.Fill(dt);
            foreach(DataRow row in dt.Rows)
            {
                JobCategoryManager.Instance.JobCategorys.Add((Guid)row["Id"], 
                    JobCategory.getByValue((Guid)row["Id"], (String)row["Name"], (String)row["Description"]));
            }

            //JobSubcategories
            JobSubcategoryManager.Instance.JobSubcategorys = new Dictionary<Guid, JobSubcategory>();
            query = "Select * From JobSubcategory";
            dt = new DataTable();
            adapter = new SqlDataAdapter(query, cnn);
            adapter.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                JobSubcategoryManager.Instance.JobSubcategorys.Add((Guid)row["Id"], JobSubcategory.getByValue(
                    (Guid)row["Id"], (Guid)row["JobCategoryId"], (String)row["Name"], 
                    (String)row["Description"]));
            }

            //TimeZones
            TimeZoneManager.Instance.TimeZones = new List<String>();
            query = "Select * From TimeZone";
            dt = new DataTable();
            adapter = new SqlDataAdapter(query, cnn);
            adapter.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                TimeZoneManager.Instance.TimeZones.Add((String)row["Title"]);
            }
        }
    }
}
