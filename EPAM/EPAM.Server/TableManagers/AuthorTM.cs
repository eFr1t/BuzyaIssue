using EPAM.Model;
using EPAM.Model.IRegister;
using EPAM.Model.IRepository;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Server.TableManagers
{
    public class AuthorTM : BaseTM<Author>, IAuthorRepository, IRegisterAuthor
    {
        public AuthorTM() :
            base("Select * From Person p INNER JOIN Author a on p.Id = a.PersonId Where IsDeleted = 0", AuthorRepository.Instance)
        {
            _adapter.InsertCommand = new SqlCommand("INSERT INTO Person (Id, Name, SName, Email, TimeZoneId, Login, Password, IsDeleted) " +
                "VALUES (@Id, @Name, @SName, @Email, @TimeZoneId, @Login, @Password, 0) " +
                "INSERT INTO Author (PersonId, Title, PhotoPath, HourRate, Overview, IsAvailable) " +
                "VALUES (@Id, @Title, @PhotoPath, @HourRate, @Overview, @IsAvailable)", _connection);
            SetCommandParameters(_adapter.InsertCommand);

            _adapter.UpdateCommand = new SqlCommand("UPDATE Person SET Name = @Name, SName = @SName, Email = @Email, " +
                "TimeZoneId = @TimeZoneId, Login = @Login, Password = @Password WHERE Id = @Id " +
                "UPDATE Author SET Title = @Title, PhotoPath = @PhotoPath, HourRate = @HourRate, Overview = @Overview, " + 
                "IsAvailable = @IsAvailable WHERE PersonId = @Id",
                _connection);
            SetCommandParameters(_adapter.UpdateCommand);

            _adapter.DeleteCommand = new SqlCommand("UPDATE Person SET IsDeleted = 1 WHERE Id = @Id", _connection);
            SetCommandIdParameters(_adapter.DeleteCommand);
        }

        public Author Login(String login, String password)
        {
            List<Guid> list = GetCustomList(String.Format("{0} AND Login='{1}' AND Password='{2}'", _defaultSelectCommand, login, password));
            if (list.Any())
                return AuthorRepository.Instance.GetItemById(list.First());
            else
                return null;
        }

        public bool Register(Author author)
        {
            SetItem(author);
            return true;
        }

        private void SetCommandParameters(SqlCommand command)
        {
            SetCommandIdParameters(command);
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            command.Parameters.Add("@SName", SqlDbType.NVarChar, 50, "SName");
            command.Parameters.Add("@Email", SqlDbType.NVarChar, 50, "Email");
            command.Parameters.Add("@TimeZoneId", SqlDbType.UniqueIdentifier, 50, "TimeZoneId");
            command.Parameters.Add("@Login", SqlDbType.NVarChar, 50, "Login");
            command.Parameters.Add("@Password", SqlDbType.NVarChar, 50, "Password");
            command.Parameters.Add("@Title", SqlDbType.NVarChar, 50, "Title");
            command.Parameters.Add("@HourRate", SqlDbType.Float, 50, "HourRate");
            command.Parameters.Add("@PhotoPath", SqlDbType.NVarChar, 50, "PhotoPath");
            command.Parameters.Add("@Overview", SqlDbType.NVarChar, 256, "Overview");
            command.Parameters.Add("@IsAvailable", SqlDbType.Bit, 10, "IsAvailable");
        }

        private void SetCommandIdParameters(SqlCommand command)
        {
            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier, 16, "Id");
        }

        public List<Guid> GetFilterAuthorIdsDirectly(AuthorFilter authorFilter)
        {
            string query = _defaultSelectCommand;
            query += String.Format(" And HourRate >= {0} And HourRate <= {1}", authorFilter.HourRateMin, authorFilter.HourRateMax);
            string jobCount = "(Select Count(*) From Job Where a.PersonId = Job.AuthorId)";
            query += " And " + jobCount + " >= " + authorFilter.CountOfPastJobsMin;
            query += " And " + jobCount + " <= " + authorFilter.CountOfPastJobsMax;
            query += String.Format(" And (Title Like '%{0}%' Or Overview Like '%{0}%')", authorFilter.SearchString);

            return GetCustomList(query);
        }
    }
}
