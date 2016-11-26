using EPAM.Model;
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
    public class StageTM : BaseTM<Stage>, IStageRepository
    {
        public StageTM() :
            base(StageRepository.Instance) { }

        public List<Guid> GetJobStageIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And JobId = '{1}'", _defaultSelectCommand, id));
        }
    }
}
