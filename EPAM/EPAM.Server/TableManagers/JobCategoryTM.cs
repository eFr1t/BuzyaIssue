using EPAM.Model;
using EPAM.Model.IRepository;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Server.TableManagers
{
    public class JobCategoryTM : BaseTM<JobCategory>, IJobCategoryRepository
    {
        public JobCategoryTM()
            : base(JobCategoryRepository.Instance) { }
    }
}
