using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    public class JobCategoryRepository : BaseRepository<JobCategory,  IJobCategoryRepository>, IJobCategoryRepository
    { 
        static private JobCategoryRepository _instance;
        static public JobCategoryRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new JobCategoryRepository();
                return _instance;
            }
        }

        private JobCategoryRepository() : base() { }
    }
}
