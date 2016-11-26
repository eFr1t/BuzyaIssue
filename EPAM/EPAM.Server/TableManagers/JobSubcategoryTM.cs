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
    public class JobSubcategoryTM : BaseTM<JobSubcategory>, IJobSubcategoryRepository
    {
        public JobSubcategoryTM() :
            base(JobSubcategoryRepository.Instance) { }

        public List<Guid> GetCategorySubcategoryIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And JobCategoryId = '{1}'", _defaultSelectCommand, id));
        }
    }
}
