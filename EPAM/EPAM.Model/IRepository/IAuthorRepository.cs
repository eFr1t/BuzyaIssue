using EPAM.Model;
using EPAM.DBAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.IRepository
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Author Login(String login, String password);
        List<Guid> GetFilterAuthorIdsDirectly(AuthorFilter authorFilter);
    }
}
