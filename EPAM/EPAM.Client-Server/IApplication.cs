using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Client_Server
{
    public interface IApplication
    {
        bool CreateApplciation(Application application);
        bool DeleteApplciation(Application application);
        List<Question> GetApplicationQuestions(Application application);
    }
}
