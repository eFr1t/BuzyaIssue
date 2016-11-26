using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.Client_Server
{
    [ServiceContract]
    public interface IQuestion
    {
        [OperationContract]
        List<Question> GetApplicationQuestions(Application application);
        [OperationContract]
        List<Question> GetJobQuestions(Job job);
    }
}
