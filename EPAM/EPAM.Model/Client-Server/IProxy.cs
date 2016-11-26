using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace EPAM.Model.Client_Server
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IProxy : IApplication, IAuthor, IAuthorSkill, IClient,
        IContract, IJob, IJobCategory, IJobFilter, IJobSkill, IJobSubcategory,
        IMessage, IPerson, IQuestion, ISkill, IStage, ITalk
    {
        [OperationContract]
        Object GetItemById(Guid id, Type t);
        [OperationContract]
        void SetItem(Object item);
        [OperationContract]
        void RemoveItem(Guid id, Type t);
        [OperationContract]
        void UpdateItem(Object item);
        [OperationContract]
        List<Object> GetAllItems(Type t);
    }
}
