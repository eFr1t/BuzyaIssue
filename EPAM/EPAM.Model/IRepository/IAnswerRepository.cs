using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.IRepository
{
    public interface IAnswerRepository : IBaseRepository<Answer>
    {
        List<Guid> GetApplicationAnswerIds(Guid id);
    }
}
