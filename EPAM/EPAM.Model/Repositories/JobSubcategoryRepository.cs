using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    public class JobSubcategoryRepository : BaseRepository<JobSubcategory, IJobSubcategoryRepository>, IJobSubcategoryRepository
    {
        static private JobSubcategoryRepository _instance;
        static public JobSubcategoryRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new JobSubcategoryRepository();
                return _instance;
            }
        }

        private JobSubcategoryRepository() : base() { }

        public List<JobSubcategory> GetCategorySubcategories(JobCategory jobCategory)
        {
            if (jobCategory == null)
                return new List<JobSubcategory>();
            return GetListFromIds(GetCategorySubcategoryIds(jobCategory.Id));
        }

        public List<Guid> GetCategorySubcategoryIds(Guid id)
        {
            return Proxy.GetCategorySubcategoryIds(id);
        }
    }
}
