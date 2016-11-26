using EPAM.Model;
using EPAM.Model.IRegister;
using EPAM.Model.IRepository;
using EPAM.Model.Repositories;
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
    public class ClientTM : BaseTM<Client>, IClientRepository, IRegisterClient
    {
        public ClientTM()
            : base("Select * From Person p INNER JOIN Client c on p.Id = c.PersonId Where IsDeleted = 0", ClientRepository.Instance)
        {
            _adapter.InsertCommand = new SqlCommand("INSERT INTO Person (Id, Name, SName, Email, TimeZoneId, Login, Password, IsDeleted) " +
                "VALUES (@Id, @Name, @SName, @Email, @TimeZoneId, @Login, @Password, 0) " +
                "INSERT INTO Client (PersonId, IsCompany, CompanyName, Overview) " +
                "VALUES (@Id, @IsCompany, @CompanyName, @Overview)", _connection);
            SetCommandParameters(_adapter.InsertCommand);

            _adapter.UpdateCommand = new SqlCommand("UPDATE Person SET Name = @Name, SName = @SName, Email = @Email, " +
                "TimeZoneId = @TimeZoneId, Login = @Login, Password = @Password WHERE Id = @Id " +
                "UPDATE Client SET IsCompany = @IsCompany, CompanyName = @CompanyName, Overview = @Overview WHERE PersonId = @Id",
                _connection);
            SetCommandParameters(_adapter.UpdateCommand);

            _adapter.DeleteCommand = new SqlCommand("UPDATE Person SET IsDeleted = 1 WHERE Id = @Id", _connection);
            SetCommandIdParameter(_adapter.DeleteCommand);
        }

        public Client Login(String login, String password)
        {
            List<Guid> list = GetCustomList(String.Format("{0} AND Login='{1}' AND Password='{2}'", _defaultSelectCommand, login, password));
            if (list.Any())
                return ClientRepository.Instance.GetItemById(list.First());
            else
                return null;
        }

        public bool Register(Client client)
        {
            SetItem(client);
            return true;
        }

        private void SetCommandParameters(SqlCommand command)
        {
            SetCommandIdParameter(command);
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            command.Parameters.Add("@SName", SqlDbType.NVarChar, 50, "SName");
            command.Parameters.Add("@Email", SqlDbType.NVarChar, 50, "Email");
            command.Parameters.Add("@TimeZoneId", SqlDbType.UniqueIdentifier, 50, "TimeZoneId");
            command.Parameters.Add("@Login", SqlDbType.NVarChar, 50, "Login");
            command.Parameters.Add("@Password", SqlDbType.NVarChar, 50, "Password");
            command.Parameters.Add("@IsCompany", SqlDbType.Bit, 50, "IsCompany");
            command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 50, "CompanyName");
            command.Parameters.Add("@Overview", SqlDbType.NVarChar, 50, "Overview");
        }

        private void SetCommandIdParameter(SqlCommand command)
        {
            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier, 16, "Id");
        }
    }
}
