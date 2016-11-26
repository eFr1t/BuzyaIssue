using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EPAM.Model;

namespace EPAM.IClient_Server
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IServerService
    {
        #region IAnswerRepository
        [OperationContract]
        Answer GetAnswerById(Guid id);
        [OperationContract]
        bool SetAnswer(Answer item);
        [OperationContract]
        bool RemoveAnswer(Guid id);
        [OperationContract]
        bool UpdateAnswer(Answer item);
        [OperationContract]
        List<Answer> GetAllAnswers();
        [OperationContract]
        List<Guid> GetApplicationAnswerIds(Guid id);
        #endregion

        #region IApplicationRepository
        [OperationContract]
        Application GetApplicationById(Guid id);
        [OperationContract]
        bool SetApplication(Application item);
        [OperationContract]
        bool RemoveApplication(Guid id);
        [OperationContract]
        bool UpdateApplication(Application item);
        [OperationContract]
        List<Application> GetAllApplications();
        [OperationContract]
        List<Guid> GetJobApplicationIds(Guid id);
        [OperationContract]
        List<Guid> GetAuthorOngoingApplicationIds(Guid id);
        [OperationContract]
        List<Guid> GetAuthorPastApplicationIds(Guid id);
        #endregion

        #region IAuthorRepository
        [OperationContract]
        Author GetAuthorById(Guid id);
        [OperationContract]
        bool SetAuthor(Author item);
        [OperationContract]
        bool RemoveAuthor(Guid id);
        [OperationContract]
        bool UpdateAuthor(Author item);
        [OperationContract]
        List<Author> GetAllAuthors();
        [OperationContract]
        Author AuthorLogin(string login, string password);
        [OperationContract]
        List<Guid> GetFilterAuthorIdsDirectly(AuthorFilter authorFilter);
        #endregion

        #region IAuthorSavedJobRepository
        [OperationContract]
        AuthorSavedJob GetAuthorSavedJobById(Guid id);
        [OperationContract]
        bool SetAuthorSavedJob(AuthorSavedJob item);
        [OperationContract]
        bool RemoveAuthorSavedJob(Guid id);
        [OperationContract]
        bool UpdateAuthorSavedJob(AuthorSavedJob item);
        [OperationContract]
        List<AuthorSavedJob> GetAllAuthorSavedJobs();
        [OperationContract]
        List<Guid> GetAuthorSavedJobIds(Guid id);
        #endregion

        #region IAuthorSkillRepository
        [OperationContract]
        AuthorSkill GetAuthorSkillById(Guid id);
        [OperationContract]
        bool SetAuthorSkill(AuthorSkill item);
        [OperationContract]
        bool RemoveAuthorSkill(Guid id);
        [OperationContract]
        bool UpdateAuthorSkill(AuthorSkill item);
        [OperationContract]
        List<AuthorSkill> GetAllAuthorSkills();
        [OperationContract]
        List<Guid> GetAuthorSkillIds(Guid id);
        #endregion

        #region IClientRepository
        [OperationContract]
        Client GetClientById(Guid id);
        [OperationContract]
        bool SetClient(Client item);
        [OperationContract]
        bool RemoveClient(Guid id);
        [OperationContract]
        bool UpdateClient(Client item);
        [OperationContract]
        List<Client> GetAllClients();
        [OperationContract]
        Client ClientLogin(string login, string password);
        #endregion

        #region IClientSavedAuthorRepository
        [OperationContract]
        ClientSavedAuthor GetClientSavedAuthorById(Guid id);
        [OperationContract]
        bool SetClientSavedAuthor(ClientSavedAuthor item);
        [OperationContract]
        bool RemoveClientSavedAuthor(Guid id);
        [OperationContract]
        bool UpdateClientSavedAuthor(ClientSavedAuthor item);
        [OperationContract]
        List<ClientSavedAuthor> GetAllClientSavedAuthors();
        [OperationContract]
        List<Guid> GetClientSavedAuthorIds(Guid id);
        #endregion

        #region IJobCategoryIRepository
        [OperationContract]
        JobCategory GetJobCategoryById(Guid id);
        [OperationContract]
        bool SetJobCategory(JobCategory item);
        [OperationContract]
        bool RemoveJobCategory(Guid id);
        [OperationContract]
        bool UpdateJobCategory(JobCategory item);
        [OperationContract]
        List<JobCategory> GetAllJobCategories();
        #endregion

        #region IJobFilterRepository
        [OperationContract]
        JobFilter GetJobFilterById(Guid id);
        [OperationContract]
        bool SetJobFilter(JobFilter item);
        [OperationContract]
        bool RemoveJobFilter(Guid id);
        [OperationContract]
        bool UpdateJobFilter(JobFilter item);
        [OperationContract]
        List<JobFilter> GetAllJobFilters();
        [OperationContract]
        List<Guid> GetAuthorSavedJobFilterIds(Guid id);
        #endregion

        #region IJobRepository
        [OperationContract]
        Job GetJobById(Guid id);
        [OperationContract]
        bool SetJob(Job item);
        [OperationContract]
        bool RemoveJob(Guid id);
        [OperationContract]
        bool UpdateJob(Job item);
        [OperationContract]
        List<Job> GetAllJobs();
        [OperationContract]
        List<Guid> GetFilterJobIds(Guid id);
        [OperationContract]
        List<Guid> GetFilterJobIdsDirectly(JobFilter jobFilter);
        [OperationContract]
        List<Guid> GetAuthorOngoingJobIds(Guid id);
        [OperationContract]
        List<Guid> GetAuthorPastJobIds(Guid id);
        [OperationContract]
        List<Guid> GetClientOngoingJobIds(Guid id);
        [OperationContract]
        List<Guid> GetClientPastJobIds(Guid id);
        #endregion

        #region IJobSkillRepository
        [OperationContract]
        JobSkill GetJobSkillById(Guid id);
        [OperationContract]
        bool SetJobSkill(JobSkill item);
        [OperationContract]
        bool RemoveJobSkill(Guid id);
        [OperationContract]
        bool UpdateJobSkill(JobSkill item);
        [OperationContract]
        List<JobSkill> GetAllJobSkills();
        [OperationContract]
        List<Guid> GetJobSkillIds(Guid id);
        #endregion

        #region IJobSubcategoryRepository
        [OperationContract]
        JobSubcategory GetJobSubcategoryById(Guid id);
        [OperationContract]
        bool SetJobSubcategory(JobSubcategory item);
        [OperationContract]
        bool RemoveJobSubcategory(Guid id);
        [OperationContract]
        bool UpdateJobSubcategory(JobSubcategory item);
        [OperationContract]
        List<JobSubcategory> GetAllJobSubcategories();
        [OperationContract]
        List<Guid> GetCategorySubcategoryIds(Guid id);
        #endregion

        #region IMessageRepository
        [OperationContract]
        Message GetMessageById(Guid id);
        [OperationContract]
        bool SetMessage(Message item);
        [OperationContract]
        bool RemoveMessage(Guid id);
        [OperationContract]
        bool UpdateMessage(Message item);
        [OperationContract]
        List<Message> GetAllMessages();
        [OperationContract]
        List<Guid> GetTalkMessageIds(Guid id);
        #endregion

        #region IQuestionRepository
        [OperationContract]
        Question GetQuestionById(Guid id);
        [OperationContract]
        bool SetQuestion(Question item);
        [OperationContract]
        bool RemoveQuestion(Guid id);
        [OperationContract]
        bool UpdateQuestion(Question item);
        [OperationContract]
        List<Question> GetAllQuestions();
        [OperationContract]
        List<Guid> GetJobQuestionIds(Guid id);
        [OperationContract]
        List<Guid> GetAllDefaultQuestionIds();
        #endregion

        #region ISkillRepository
        [OperationContract]
        Skill GetSkillById(Guid id);
        [OperationContract]
        bool SetSkill(Skill item);
        [OperationContract]
        bool RemoveSkill(Guid id);
        [OperationContract]
        bool UpdateSkill(Skill item);
        [OperationContract]
        List<Skill> GetAllSkills();
        #endregion

        #region IStageRepository
        [OperationContract]
        Stage GetStageById(Guid id);
        [OperationContract]
        bool SetStage(Stage item);
        [OperationContract]
        bool RemoveStage(Guid id);
        [OperationContract]
        bool UpdateStage(Stage item);
        [OperationContract]
        List<Stage> GetAllStages();
        [OperationContract]
        List<Guid> GetJobStageIds(Guid id);
        #endregion

        #region ITalkRepository
        [OperationContract]
        Talk GetTalkById(Guid id);
        [OperationContract]
        bool SetTalk(Talk item);
        [OperationContract]
        bool RemoveTalk(Guid id);
        [OperationContract]
        bool UpdateTalk(Talk item);
        [OperationContract]
        List<Talk> GetAllTalks();
        [OperationContract]
        List<Guid> GetPersonTalkIds(Guid id);
        #endregion

        #region ITimeZoneRepository
        [OperationContract]
        Model.TimeZone GetTimeZoneById(Guid id);
        [OperationContract]
        bool SetTimeZone(Model.TimeZone item);
        [OperationContract]
        bool RemoveTimeZone(Guid id);
        [OperationContract]
        bool UpdateTimeZone(Model.TimeZone item);
        [OperationContract]
        List<Model.TimeZone> GetAllTimeZones();
        #endregion
    }
}
