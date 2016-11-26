using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Repositories
{
    public class StageRepository : BaseRepository<Stage, IStageRepository>, IStageRepository
    {   
        static private StageRepository _instance;
        static public StageRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StageRepository();
                return _instance;
            }
        }

        private StageRepository() : base() { }

        public List<Stage> GetJobStages(Job job)
        {
            return GetListFromIds(GetJobStageIds(job.Id));
        }

        public List<Guid> GetJobStageIds(Guid id)
        {
            return Proxy.GetJobStageIds(id);
        }
    }
}
