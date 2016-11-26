using EPAM.Model;
using EPAM.Model.IRepository;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Server.TableManagers
{
    public class AuthorSavedJobTM : BaseTM<AuthorSavedJob>, IAuthorSavedJobRepository
    {
        public AuthorSavedJobTM() :
            base(AuthorSavedJobRepository.Instance) { }

        public List<Guid> GetAuthorSavedJobIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And AuthorId = '{1}'", _defaultSelectCommand, id));
        }
    }
}
