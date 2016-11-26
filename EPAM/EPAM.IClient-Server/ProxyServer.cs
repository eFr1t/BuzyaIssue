using EPAM.Model;
using EPAM.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.IClient_Server
{
    public class ProxyServer : ClientBase<IServerService>, IAnswerRepository, IApplicationRepository, IAuthorRepository, 
        IAuthorSavedJobRepository, IAuthorSkillRepository, IClientRepository, IClientSavedAuthorRepository, IJobRepository, 
        IJobCategoryRepository, IJobFilterRepository, IJobSkillRepository, IJobSubcategoryRepository, IMessageRepository, 
        IQuestionRepository, ISkillRepository, IStageRepository, ITalkRepository, ITimeZoneRepository
    {
        #region IAnswerRepository
        Answer IBaseRepository<Answer>.GetItemById(Guid id)
        {
            return Channel.GetAnswerById(id);
        }

        bool IBaseRepository<Answer>.SetItem(Answer item)
        {
            return Channel.SetAnswer(item);
        }

        bool IBaseRepository<Answer>.RemoveItem(Guid id)
        {
            return Channel.RemoveAnswer(id);
        }

        bool IBaseRepository<Answer>.UpdateItem(Answer item)
        {
            return Channel.UpdateAnswer(item);
        }

        List<Answer> IBaseRepository<Answer>.GetAllItems()
        {
            return Channel.GetAllAnswers();
        }

        List<Guid> IAnswerRepository.GetApplicationAnswerIds(Guid id)
        {
            return Channel.GetApplicationAnswerIds(id);
        }
        #endregion

        #region IApplicationRepository
        Application IBaseRepository<Application>.GetItemById(Guid id)
        {
            return Channel.GetApplicationById(id);
        }

        bool IBaseRepository<Application>.SetItem(Application item)
        {
            return Channel.SetApplication(item);
        }

        bool IBaseRepository<Application>.RemoveItem(Guid id)
        {
            return Channel.RemoveApplication(id);
        }

        bool IBaseRepository<Application>.UpdateItem(Application item)
        {
            return Channel.UpdateApplication(item);
        }

        List<Application> IBaseRepository<Application>.GetAllItems()
        {
            return Channel.GetAllApplications();
        }

        List<Guid> IApplicationRepository.GetJobApplicationIds(Guid id)
        {
            return Channel.GetJobApplicationIds(id);
        }

        List<Guid> IApplicationRepository.GetAuthorOngoingApplicationIds(Guid id)
        {
            return Channel.GetAuthorOngoingApplicationIds(id);
        }

        List<Guid> IApplicationRepository.GetAuthorPastApplicationIds(Guid id)
        {
            return Channel.GetAuthorPastApplicationIds(id);
        }
        #endregion

        #region IAuthorRepository
        Author IBaseRepository<Author>.GetItemById(Guid id)
        {
            return Channel.GetAuthorById(id);
        }

        bool IBaseRepository<Author>.SetItem(Author item)
        {
            return Channel.SetAuthor(item);
        }

        bool IBaseRepository<Author>.RemoveItem(Guid id)
        {
            return Channel.RemoveAuthor(id);
        }

        bool IBaseRepository<Author>.UpdateItem(Author item)
        {
            return Channel.UpdateAuthor(item);
        }

        List<Author> IBaseRepository<Author>.GetAllItems()
        {
            return Channel.GetAllAuthors();
        }

        Author IAuthorRepository.Login(string login, string password)
        {
            return Channel.AuthorLogin(login, password);
        }

        List<Guid> IAuthorRepository.GetFilterAuthorIdsDirectly(AuthorFilter authorFilter)
        {
            return Channel.GetFilterAuthorIdsDirectly(authorFilter);
        }
        #endregion

        #region IAuthorSavedJobRepository
        AuthorSavedJob IBaseRepository<AuthorSavedJob>.GetItemById(Guid id)
        {
            return Channel.GetAuthorSavedJobById(id);
        }

        bool IBaseRepository<AuthorSavedJob>.SetItem(AuthorSavedJob item)
        {
            return Channel.SetAuthorSavedJob(item);
        }

        bool IBaseRepository<AuthorSavedJob>.RemoveItem(Guid id)
        {
            return Channel.RemoveAuthorSavedJob(id);
        }

        bool IBaseRepository<AuthorSavedJob>.UpdateItem(AuthorSavedJob item)
        {
            return Channel.UpdateAuthorSavedJob(item);
        }

        List<AuthorSavedJob> IBaseRepository<AuthorSavedJob>.GetAllItems()
        {
            return Channel.GetAllAuthorSavedJobs();
        }

        List<Guid> IAuthorSavedJobRepository.GetAuthorSavedJobIds(Guid id)
        {
            return Channel.GetAuthorSavedJobIds(id);
        }
        #endregion

        #region IAuthorSkillRepository
        AuthorSkill IBaseRepository<AuthorSkill>.GetItemById(Guid id)
        {
            return Channel.GetAuthorSkillById(id);
        }

        bool IBaseRepository<AuthorSkill>.SetItem(AuthorSkill item)
        {
            return Channel.SetAuthorSkill(item);
        }

        bool IBaseRepository<AuthorSkill>.RemoveItem(Guid id)
        {
            return Channel.RemoveAuthorSkill(id);
        }

        bool IBaseRepository<AuthorSkill>.UpdateItem(AuthorSkill item)
        {
            return Channel.UpdateAuthorSkill(item);
        }

        List<AuthorSkill> IBaseRepository<AuthorSkill>.GetAllItems()
        {
            return Channel.GetAllAuthorSkills();
        }

        List<Guid> IAuthorSkillRepository.GetAuthorSkillIds(Guid id)
        {
            return Channel.GetAuthorSkillIds(id);
        }
        #endregion

        #region IClientRepository
        Client IBaseRepository<Client>.GetItemById(Guid id)
        {
            return Channel.GetClientById(id);
        }

        bool IBaseRepository<Client>.SetItem(Client item)
        {
            return Channel.SetClient(item);
        }

        bool IBaseRepository<Client>.RemoveItem(Guid id)
        {
            return Channel.RemoveClient(id);
        }

        bool IBaseRepository<Client>.UpdateItem(Client item)
        {
            return Channel.UpdateClient(item);
        }

        List<Client> IBaseRepository<Client>.GetAllItems()
        {
            return Channel.GetAllClients();
        }

        Client IClientRepository.Login(string login, string password)
        {
            return Channel.ClientLogin(login, password);
        }
        #endregion

        #region IClientSavedAuthorRepository
        ClientSavedAuthor IBaseRepository<ClientSavedAuthor>.GetItemById(Guid id)
        {
            return Channel.GetClientSavedAuthorById(id);
        }

        bool IBaseRepository<ClientSavedAuthor>.SetItem(ClientSavedAuthor item)
        {
            return Channel.SetClientSavedAuthor(item);
        }

        bool IBaseRepository<ClientSavedAuthor>.RemoveItem(Guid id)
        {
            return Channel.RemoveClientSavedAuthor(id);
        }

        bool IBaseRepository<ClientSavedAuthor>.UpdateItem(ClientSavedAuthor item)
        {
            return Channel.UpdateClientSavedAuthor(item);
        }

        List<ClientSavedAuthor> IBaseRepository<ClientSavedAuthor>.GetAllItems()
        {
            return Channel.GetAllClientSavedAuthors();
        }

        List<Guid> IClientSavedAuthorRepository.GetClientSavedAuthorIds(Guid id)
        {
            return Channel.GetClientSavedAuthorIds(id);
        }
        #endregion

        #region IJobCategoryIRepository
        JobCategory IBaseRepository<JobCategory>.GetItemById(Guid id)
        {
            return Channel.GetJobCategoryById(id);
        }

        bool IBaseRepository<JobCategory>.SetItem(JobCategory item)
        {
            return Channel.SetJobCategory(item);
        }

        bool IBaseRepository<JobCategory>.RemoveItem(Guid id)
        {
            return Channel.RemoveJobCategory(id);
        }

        bool IBaseRepository<JobCategory>.UpdateItem(JobCategory item)
        {
            return Channel.UpdateJobCategory(item);
        }

        List<JobCategory> IBaseRepository<JobCategory>.GetAllItems()
        {
            return Channel.GetAllJobCategories();
        }
        #endregion

        #region IJobFilterIRepository
        JobFilter IBaseRepository<JobFilter>.GetItemById(Guid id)
        {
            return Channel.GetJobFilterById(id);
        }

        bool IBaseRepository<JobFilter>.SetItem(JobFilter item)
        {
            return Channel.SetJobFilter(item);
        }

        bool IBaseRepository<JobFilter>.RemoveItem(Guid id)
        {
            return Channel.RemoveJobFilter(id);
        }

        bool IBaseRepository<JobFilter>.UpdateItem(JobFilter item)
        {
            return Channel.UpdateJobFilter(item);
        }

        List<JobFilter> IBaseRepository<JobFilter>.GetAllItems()
        {
            return Channel.GetAllJobFilters();
        }

        List<Guid> IJobFilterRepository.GetAuthorSavedJobFilterIds(Guid id)
        {
            return Channel.GetAuthorSavedJobFilterIds(id);
        }
        #endregion

        #region IJobRepository
        Job IBaseRepository<Job>.GetItemById(Guid id)
        {
            return Channel.GetJobById(id);
        }

        bool IBaseRepository<Job>.SetItem(Job item)
        {
            return Channel.SetJob(item);
        }

        bool IBaseRepository<Job>.RemoveItem(Guid id)
        {
            return Channel.RemoveJob(id);
        }

        bool IBaseRepository<Job>.UpdateItem(Job item)
        {
            return Channel.UpdateJob(item);
        }

        List<Job> IBaseRepository<Job>.GetAllItems()
        {
            return Channel.GetAllJobs();
        }

        List<Guid> IJobRepository.GetFilterJobIds(Guid id)
        {
            return Channel.GetFilterJobIds(id);
        }

        List<Guid> IJobRepository.GetFilterJobIdsDirectly(JobFilter jobFilter)
        {
            return Channel.GetFilterJobIdsDirectly(jobFilter);
        }

        List<Guid> IJobRepository.GetAuthorOngoingJobIds(Guid id)
        {
            return Channel.GetAuthorOngoingJobIds(id);
        }

        List<Guid> IJobRepository.GetAuthorPastJobIds(Guid id)
        {
            return Channel.GetAuthorPastJobIds(id);
        }

        List<Guid> IJobRepository.GetClientOngoingJobIds(Guid id)
        {
            return Channel.GetClientOngoingJobIds(id);
        }

        List<Guid> IJobRepository.GetClientPastJobIds(Guid id)
        {
            return Channel.GetClientPastJobIds(id);
        }
        #endregion

        #region IJobSkillRepository
        JobSkill IBaseRepository<JobSkill>.GetItemById(Guid id)
        {
            return Channel.GetJobSkillById(id);
        }

        bool IBaseRepository<JobSkill>.SetItem(JobSkill item)
        {
            return Channel.SetJobSkill(item);
        }

        bool IBaseRepository<JobSkill>.RemoveItem(Guid id)
        {
            return Channel.RemoveJobSkill(id);
        }

        bool IBaseRepository<JobSkill>.UpdateItem(JobSkill item)
        {
            return Channel.UpdateJobSkill(item);
        }

        List<JobSkill> IBaseRepository<JobSkill>.GetAllItems()
        {
            return Channel.GetAllJobSkills();
        }

        List<Guid> IJobSkillRepository.GetJobSkillIds(Guid id)
        {
            return Channel.GetJobSkillIds(id);
        }
        #endregion

        #region IJobSubcategoryRepository
        JobSubcategory IBaseRepository<JobSubcategory>.GetItemById(Guid id)
        {
            return Channel.GetJobSubcategoryById(id);
        }

        bool IBaseRepository<JobSubcategory>.SetItem(JobSubcategory item)
        {
            return Channel.SetJobSubcategory(item);
        }

        bool IBaseRepository<JobSubcategory>.RemoveItem(Guid id)
        {
            return Channel.RemoveJobSubcategory(id);
        }

        bool IBaseRepository<JobSubcategory>.UpdateItem(JobSubcategory item)
        {
            return Channel.UpdateJobSubcategory(item);
        }

        List<JobSubcategory> IBaseRepository<JobSubcategory>.GetAllItems()
        {
            return Channel.GetAllJobSubcategories();
        }

        List<Guid> IJobSubcategoryRepository.GetCategorySubcategoryIds(Guid id)
        {
            return Channel.GetCategorySubcategoryIds(id);
        }
        #endregion

        #region IMessageRepository
        Message IBaseRepository<Message>.GetItemById(Guid id)
        {
            return Channel.GetMessageById(id);
        }

        bool IBaseRepository<Message>.SetItem(Message item)
        {
            return Channel.SetMessage(item);
        }

        bool IBaseRepository<Message>.RemoveItem(Guid id)
        {
            return Channel.RemoveMessage(id);
        }

        bool IBaseRepository<Message>.UpdateItem(Message item)
        {
            return Channel.UpdateMessage(item);
        }

        List<Message> IBaseRepository<Message>.GetAllItems()
        {
            return Channel.GetAllMessages();
        }

        List<Guid> IMessageRepository.GetTalkMessageIds(Guid id)
        {
            return Channel.GetTalkMessageIds(id);
        }
        #endregion

        #region IQuestionRepository
        Question IBaseRepository<Question>.GetItemById(Guid id)
        {
            return Channel.GetQuestionById(id);
        }

        bool IBaseRepository<Question>.SetItem(Question item)
        {
            return Channel.SetQuestion(item);
        }

        bool IBaseRepository<Question>.RemoveItem(Guid id)
        {
            return Channel.RemoveQuestion(id);
        }

        bool IBaseRepository<Question>.UpdateItem(Question item)
        {
            return Channel.UpdateQuestion(item);
        }

        List<Question> IBaseRepository<Question>.GetAllItems()
        {
            return Channel.GetAllQuestions();
        }

        List<Guid> IQuestionRepository.GetAllDefaultQuestionIds()
        {
            return Channel.GetAllDefaultQuestionIds();
        }

        List<Guid> IQuestionRepository.GetJobQuestionIds(Guid id)
        {
            return Channel.GetJobQuestionIds(id);
        }
        #endregion

        #region ISkillRepository
        Skill IBaseRepository<Skill>.GetItemById(Guid id)
        {
            return Channel.GetSkillById(id);
        }

        bool IBaseRepository<Skill>.SetItem(Skill item)
        {
            return Channel.SetSkill(item);
        }

        bool IBaseRepository<Skill>.RemoveItem(Guid id)
        {
            return Channel.RemoveSkill(id);
        }

        bool IBaseRepository<Skill>.UpdateItem(Skill item)
        {
            return Channel.UpdateSkill(item);
        }

        List<Skill> IBaseRepository<Skill>.GetAllItems()
        {
            return Channel.GetAllSkills();
        }
        #endregion

        #region IStageRepository
        Stage IBaseRepository<Stage>.GetItemById(Guid id)
        {
            return Channel.GetStageById(id);
        }

        bool IBaseRepository<Stage>.SetItem(Stage item)
        {
            return Channel.SetStage(item);
        }

        bool IBaseRepository<Stage>.RemoveItem(Guid id)
        {
            return Channel.RemoveStage(id);
        }

        bool IBaseRepository<Stage>.UpdateItem(Stage item)
        {
            return Channel.UpdateStage(item);
        }

        List<Stage> IBaseRepository<Stage>.GetAllItems()
        {
            return Channel.GetAllStages();
        }

        List<Guid> IStageRepository.GetJobStageIds(Guid id)
        {
            return Channel.GetJobStageIds(id);
        }
        #endregion

        #region ITalkRepository
        Talk IBaseRepository<Talk>.GetItemById(Guid id)
        {
            return Channel.GetTalkById(id);
        }

        bool IBaseRepository<Talk>.SetItem(Talk item)
        {
            return Channel.SetTalk(item);
        }

        bool IBaseRepository<Talk>.RemoveItem(Guid id)
        {
            return Channel.RemoveTalk(id);
        }

        bool IBaseRepository<Talk>.UpdateItem(Talk item)
        {
            return Channel.UpdateTalk(item);
        }

        List<Talk> IBaseRepository<Talk>.GetAllItems()
        {
            return Channel.GetAllTalks();
        }

        List<Guid> ITalkRepository.GetPersonTalkIds(Guid id)
        {
            return Channel.GetPersonTalkIds(id);
        }
        #endregion

        #region ITimeZoneRepository
        Model.TimeZone IBaseRepository<Model.TimeZone>.GetItemById(Guid id)
        {
            return Channel.GetTimeZoneById(id);
        }

        bool IBaseRepository<Model.TimeZone>.SetItem(Model.TimeZone item)
        {
            return Channel.SetTimeZone(item);
        }

        bool IBaseRepository<Model.TimeZone>.RemoveItem(Guid id)
        {
            return Channel.RemoveTimeZone(id);
        }

        bool IBaseRepository<Model.TimeZone>.UpdateItem(Model.TimeZone item)
        {
            return Channel.UpdateTimeZone(item);
        }

        List<Model.TimeZone> IBaseRepository<Model.TimeZone>.GetAllItems()
        {
            return Channel.GetAllTimeZones();
        }
        #endregion
    }
}
