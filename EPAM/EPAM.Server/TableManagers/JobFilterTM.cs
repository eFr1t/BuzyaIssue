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
    public class JobFilterTM : BaseTM<JobFilter>, IJobFilterRepository
    {
        public JobFilterTM() :
            base(JobFilterRepository.Instance) { }

        public List<Guid> GetAuthorSavedJobFilterIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And AuthorId = '{1}'", _defaultSelectCommand, id));
        }
    }
}
