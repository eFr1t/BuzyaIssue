using EPAM.IClient_Server;
using EPAM.Model;
using EPAM.Server.TableManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EPAM.Model.Repositories;

namespace EPAM.Server.ServerServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ServerService : IServerService
    {
        #region IAnswerRepository
        public Answer GetAnswerById(Guid id)
        {
            return AnswerRepository.Instance.GetItemById(id);
        }

        public bool SetAnswer(Answer item)
        {
            return AnswerRepository.Instance.SetItem(item);
        }

        public bool RemoveAnswer(Guid id)
        {
            return AnswerRepository.Instance.RemoveItem(id);
        }

        public bool UpdateAnswer(Answer item)
        {
            throw new NotSupportedException();
        }

        public List<Answer> GetAllAnswers()
        {
            throw new NotSupportedException();
        }

        public List<Guid> GetApplicationAnswerIds(Guid id)
        {
            return AnswerRepository.Instance.GetApplicationAnswerIds(id);
        }
        #endregion

        #region IApplicationRepository
        public Application GetApplicationById(Guid id)
        {
            return ApplicationRepository.Instance.GetItemById(id);
        }

        public bool SetApplication(Application item)
        {
            return ApplicationRepository.Instance.SetItem(item);
        }

        public bool RemoveApplication(Guid id)
        {
            ////if (_personId != ApplicationRepository.Instance.GetItemById(id).AuthorId)
            ////    return false;
            return ApplicationRepository.Instance.RemoveItem(id);
        }

        public bool UpdateApplication(Application item)
        {
            return ApplicationRepository.Instance.UpdateItem(item);
        }

        public List<Application> GetAllApplications()
        {
            throw new NotSupportedException();
        }

        public List<Guid> GetJobApplicationIds(Guid id)
        {
            return ApplicationRepository.Instance.GetJobApplicationIds(id);
        }

        public List<Guid> GetAuthorOngoingApplicationIds(Guid id)
        {
            return ApplicationRepository.Instance.GetAuthorOngoingApplicationIds(id);
        }

        public List<Guid> GetAuthorPastApplicationIds(Guid id)
        {
            return ApplicationRepository.Instance.GetAuthorPastApplicationIds(id);
        }
        #endregion

        #region IAuthorRepository
        public Author GetAuthorById(Guid id)
        {
            return AuthorRepository.Instance.GetItemById(id);
        }

        public bool SetAuthor(Author item)
        {
            throw new NotSupportedException();
        }

        public bool RemoveAuthor(Guid id)
        {
            ////if (_personId != id)
            ////    return false;
            return AuthorRepository.Instance.RemoveItem(id);
        }

        public bool UpdateAuthor(Author item)
        {
            ////if (_personId != item.Id)
            ////    return false;
            return AuthorRepository.Instance.UpdateItem(item);
        }

        public List<Author> GetAllAuthors()
        {
            throw new NotSupportedException();
        }

        public Author AuthorLogin(string login, string password)
        {
            Person p = AuthorRepository.Instance.Login(login, password);
            ////if (p != null)
            ////    _personId = p.Id;
            return p as Author;
        }

        public List<Guid> GetFilterAuthorIdsDirectly(AuthorFilter authorFilter)
        {
            return AuthorRepository.Instance.GetFilterAuthorIdsDirectly(authorFilter);
        }
        #endregion

        #region IAuthorSavedJobRepository
        public AuthorSavedJob GetAuthorSavedJobById(Guid id)
        {
            return AuthorSavedJobRepository.Instance.GetItemById(id);
        }

        public bool SetAuthorSavedJob(AuthorSavedJob item)
        {
            return AuthorSavedJobRepository.Instance.SetItem(item);
        }

        public bool RemoveAuthorSavedJob(Guid id)
        {
            return AuthorSavedJobRepository.Instance.RemoveItem(id);
        }

        public bool UpdateAuthorSavedJob(AuthorSavedJob item)
        {
            return AuthorSavedJobRepository.Instance.UpdateItem(item);
        }

        public List<AuthorSavedJob> GetAllAuthorSavedJobs()
        {
            throw new NotSupportedException();
        }

        public List<Guid> GetAuthorSavedJobIds(Guid id)
        {
            return AuthorSavedJobRepository.Instance.GetAuthorSavedJobIds(id);
        }
        #endregion

        #region IAuthorSkillRepository
        public AuthorSkill GetAuthorSkillById(Guid id)
        {
            return AuthorSkillRepository.Instance.GetItemById(id);
        }

        public bool SetAuthorSkill(AuthorSkill item)
        {
            ////if (_personId != item.AuthorId)
            ////    return false;
            return AuthorSkillRepository.Instance.SetItem(item);
        }

        public bool RemoveAuthorSkill(Guid id)
        {
            ////if (_personId != AuthorSkillRepository.Instance.GetItemById(id).AuthorId)
            ////    return false;
            return AuthorSkillRepository.Instance.RemoveItem(id);
        }

        public bool UpdateAuthorSkill(AuthorSkill item)
        {
            throw new NotSupportedException();
        }

        public List<AuthorSkill> GetAllAuthorSkills()
        {
            throw new NotSupportedException();
        }

        public List<Guid> GetAuthorSkillIds(Guid id)
        {
            return AuthorSkillRepository.Instance.GetAuthorSkillIds(id);
        }
        #endregion

        #region IClientRepository
        public Client GetClientById(Guid id)
        {
            return ClientRepository.Instance.GetItemById(id);
        }

        public bool SetClient(Client item)
        {
            throw new NotSupportedException();
        }

        public bool RemoveClient(Guid id)
        {
            ////if (_personId != id)
            ////    return false;
            return ClientRepository.Instance.RemoveItem(id);
        }

        public bool UpdateClient(Client item)
        {
            ////if (_personId != item.Id)
            ////    return false;
            return ClientRepository.Instance.UpdateItem(item);
        }

        public List<Client> GetAllClients()
        {
            throw new NotSupportedException();
        }

        public Client ClientLogin(string login, string password)
        {
            Person p = ClientRepository.Instance.Login(login, password);
            ////if (p != null)
            ////    _personId = p.Id;
            return p as Client;
        }
        #endregion

        #region IClientSavedAuthorRepository
        public ClientSavedAuthor GetClientSavedAuthorById(Guid id)
        {
            return ClientSavedAuthorRepository.Instance.GetItemById(id);
        }

        public bool SetClientSavedAuthor(ClientSavedAuthor item)
        {
            return ClientSavedAuthorRepository.Instance.SetItem(item);
        }

        public bool RemoveClientSavedAuthor(Guid id)
        {
            return ClientSavedAuthorRepository.Instance.RemoveItem(id);
        }

        public bool UpdateClientSavedAuthor(ClientSavedAuthor item)
        {
            return ClientSavedAuthorRepository.Instance.UpdateItem(item);
        }

        public List<ClientSavedAuthor> GetAllClientSavedAuthors()
        {
            throw new NotSupportedException();
        }

        public List<Guid> GetClientSavedAuthorIds(Guid id)
        {
            return ClientSavedAuthorRepository.Instance.GetClientSavedAuthorIds(id);
        }
        #endregion

        #region IJobCategoryRepository
        public JobCategory GetJobCategoryById(Guid id)
        {
            return JobCategoryRepository.Instance.GetItemById(id);
        }

        public bool SetJobCategory(JobCategory item)
        {
            //admin check
            return JobCategoryRepository.Instance.SetItem(item);
        }

        public bool RemoveJobCategory(Guid id)
        {
            //admin check
            return JobCategoryRepository.Instance.RemoveItem(id);
        }

        public bool UpdateJobCategory(JobCategory item)
        {
            //admin check
            return JobCategoryRepository.Instance.UpdateItem(item);
        }

        public List<JobCategory> GetAllJobCategories()
        {
            return JobCategoryRepository.Instance.GetAllItems();
        }
        #endregion

        #region IJobFilterRepository
        public JobFilter GetJobFilterById(Guid id)
        {
            return JobFilterRepository.Instance.GetItemById(id);
        }

        public bool SetJobFilter(JobFilter item)
        {
            return JobFilterRepository.Instance.SetItem(item);
        }

        public bool RemoveJobFilter(Guid id)
        {
            return JobFilterRepository.Instance.RemoveItem(id);
        }

        public bool UpdateJobFilter(JobFilter item)
        {
            return JobFilterRepository.Instance.UpdateItem(item);
        }

        public List<JobFilter> GetAllJobFilters()
        {
            throw new NotSupportedException();
        }

        public List<Guid> GetAuthorSavedJobFilterIds(Guid id)
        {
            return JobFilterRepository.Instance.GetAuthorSavedJobFilterIds(id);
        }
        #endregion

        #region IJobRepository
        public Job GetJobById(Guid id)
        {
            return JobRepository.Instance.GetItemById(id);
        }

        public bool SetJob(Job item)
        {
            ////if (_personId != item.ClientId)
            ////    return false;
            return JobRepository.Instance.SetItem(item);
        }

        public bool RemoveJob(Guid id)
        {
            ////if (_personId != ClientRepository.Instance.GetItemById(id).Id)
            ////    return false;
            return JobRepository.Instance.RemoveItem(id);
        }

        public bool UpdateJob(Job item)
        {
            ////if (_personId != item.ClientId)
            ////    return false;
            return JobRepository.Instance.UpdateItem(item);
        }

        public List<Job> GetAllJobs()
        {
            throw new NotSupportedException();
        }

        public List<Guid> GetFilterJobIds(Guid id)
        {
            return JobRepository.Instance.GetFilterJobIds(id);
        }

        public List<Guid> GetFilterJobIdsDirectly(JobFilter jobFilter)
        {
            return JobRepository.Instance.GetFilterJobIdsDirectly(jobFilter);
        }

        public List<Guid> GetAuthorOngoingJobIds(Guid id)
        {
            return JobRepository.Instance.GetAuthorOngoingJobIds(id);
        }

        public List<Guid> GetAuthorPastJobIds(Guid id)
        {
            return JobRepository.Instance.GetAuthorPastJobIds(id);
        }

        public List<Guid> GetClientOngoingJobIds(Guid id)
        {
            return JobRepository.Instance.GetClientOngoingJobIds(id);
        }

        public List<Guid> GetClientPastJobIds(Guid id)
        {
            return JobRepository.Instance.GetClientPastJobIds(id);
        }
        #endregion

        #region IJobSkillRepository
        public JobSkill GetJobSkillById(Guid id)
        {
            return JobSkillRepository.Instance.GetItemById(id);
        }

        public bool SetJobSkill(JobSkill item)
        {
            ////if (_personId != item.JobId)
            ////    return false;
            return JobSkillRepository.Instance.SetItem(item);
        }

        public bool RemoveJobSkill(Guid id)
        {
            ////if (_personId != JobSkillRepository.Instance.GetItemById(id).JobId)
            ////    return false;
            return JobSkillRepository.Instance.RemoveItem(id);
        }

        public bool UpdateJobSkill(JobSkill item)
        {
            throw new NotSupportedException();
        }

        public List<JobSkill> GetAllJobSkills()
        {
            throw new NotSupportedException();
        }

        public List<Guid> GetJobSkillIds(Guid id)
        {
            return JobSkillRepository.Instance.GetJobSkillIds(id);
        }
        #endregion

        #region IJobSubcategoryRepository
        public JobSubcategory GetJobSubcategoryById(Guid id)
        {
            return JobSubcategoryRepository.Instance.GetItemById(id);
        }

        public bool SetJobSubcategory(JobSubcategory item)
        {
            //admin check
            return JobSubcategoryRepository.Instance.SetItem(item);
        }

        public bool RemoveJobSubcategory(Guid id)
        {
            //admin check
            return JobSubcategoryRepository.Instance.RemoveItem(id);
        }

        public bool UpdateJobSubcategory(JobSubcategory item)
        {
            //admin check
            return JobSubcategoryRepository.Instance.UpdateItem(item);
        }

        public List<JobSubcategory> GetAllJobSubcategories()
        {
            throw new NotSupportedException();
        }

        public List<Guid> GetCategorySubcategoryIds(Guid id)
        {
            return JobSubcategoryRepository.Instance.GetCategorySubcategoryIds(id);
        }
        #endregion

        #region IMessageRepository
        public Message GetMessageById(Guid id)
        {
            Message m = MessageRepository.Instance.GetItemById(id);
            ////if (_personId != m.Talk.AuthorId && _personId != m.Talk.ClientId)
            ////    return null;
            return m;
        }

        public bool SetMessage(Message item)
        {
            ////if (_personId != item.PersonId)
            ////    return false;
            return MessageRepository.Instance.SetItem(item);
        }

        public bool RemoveMessage(Guid id)
        {
            ////if (_personId != MessageRepository.Instance.GetItemById(id).PersonId)
            ////    return false;
            return MessageRepository.Instance.RemoveItem(id);
        }

        public bool UpdateMessage(Message item)
        {
            throw new NotSupportedException();
        }

        public List<Message> GetAllMessages()
        {
            throw new NotSupportedException();
        }

        public List<Guid> GetTalkMessageIds(Guid id)
        {
            Talk t = TalkRepository.Instance.GetItemById(id);
            ////if (_personId != t.AuthorId && _personId != t.ClientId)
            ////    return null;
            return MessageRepository.Instance.GetTalkMessageIds(id);
        }
        #endregion

        #region IQuestionRepository
        public Question GetQuestionById(Guid id)
        {
            return QuestionRepository.Instance.GetItemById(id);
        }

        public bool SetQuestion(Question item)
        {
            //admin check
            ////if (!item.IsDefault && _personId != item.Job.ClientId)
            ////    return false;
            return QuestionRepository.Instance.SetItem(item);
        }

        public bool RemoveQuestion(Guid id)
        {
            Question q = QuestionRepository.Instance.GetItemById(id);
            //admin check
            ////if (!q.IsDefault && _personId != q.Job.ClientId)
            ////    return false;
            return QuestionRepository.Instance.RemoveItem(id);
        }

        public bool UpdateQuestion(Question item)
        {
            ////if (!item.IsDefault && _personId != item.Job.ClientId)
            ////    return false;
            return QuestionRepository.Instance.UpdateItem(item);
        }

        public List<Question> GetAllQuestions()
        {
            throw new NotSupportedException();
        }

        public List<Guid> GetJobQuestionIds(Guid id)
        {
            return QuestionRepository.Instance.GetJobQuestionIds(id);
        }

        public List<Guid> GetAllDefaultQuestionIds()
        {
            return QuestionRepository.Instance.GetAllDefaultQuestionIds();
        }
        #endregion

        #region ISkillRepository
        public Skill GetSkillById(Guid id)
        {
            return SkillRepository.Instance.GetItemById(id);
        }

        public bool SetSkill(Skill item)
        {
            //admin check
            return SkillRepository.Instance.SetItem(item);
        }

        public bool RemoveSkill(Guid id)
        {
            //admin check
            return SkillRepository.Instance.RemoveItem(id);
        }

        public bool UpdateSkill(Skill item)
        {
            //admin check
            return SkillRepository.Instance.UpdateItem(item);
        }

        public List<Skill> GetAllSkills()
        {
            return SkillRepository.Instance.GetAllItems();
        }
        #endregion

        #region IStageRepository
        public Stage GetStageById(Guid id)
        {
            Stage s = StageRepository.Instance.GetItemById(id);
            ////if (_personId != s.Job.ClientId && _personId != s.Job.Contract.AuthorId)
            ////    return null;
            return s;
        }

        public bool SetStage(Stage item)
        {
            ////if (_personId != item.Job.ClientId)
            ////    return false;
            return StageRepository.Instance.SetItem(item);
        }

        public bool RemoveStage(Guid id)
        {
            ////if (_personId != StageRepository.Instance.GetItemById(id).Job.ClientId)
            ////    return false;
            return StageRepository.Instance.RemoveItem(id);
        }

        public bool UpdateStage(Stage item)
        {
            ////if (_personId != item.Job.ClientId)
            ////    return false;
            return StageRepository.Instance.UpdateItem(item);
        }

        public List<Stage> GetAllStages()
        {
            throw new NotSupportedException();
        }

        public List<Guid> GetJobStageIds(Guid id)
        {
            Job j = JobRepository.Instance.GetItemById(id);
            ////if (_personId != j.ClientId && _personId != j.Contract.AuthorId)
            ////    return null;
            return StageRepository.Instance.GetJobStageIds(id);
        }
        #endregion

        #region ITalkRepository
        public Talk GetTalkById(Guid id)
        {
            Talk t = TalkRepository.Instance.GetItemById(id);
            ////if (_personId != t.AuthorId && _personId != t.ClientId)
            ////    return null;
            return t;
        }

        public bool SetTalk(Talk item)
        {
            return TalkRepository.Instance.SetItem(item);
        }

        public bool RemoveTalk(Guid id)
        {
            Talk t = TalkRepository.Instance.GetItemById(id);
            ////if (_personId != t.AuthorId && _personId != t.ClientId)
            ////    return false;
            return TalkRepository.Instance.RemoveItem(id);
        }

        public bool UpdateTalk(Talk item)
        {
            throw new NotSupportedException();
        }

        public List<Talk> GetAllTalks()
        {
            throw new NotSupportedException();
        }

        public List<Guid> GetPersonTalkIds(Guid id)
        {
            ////if(_personId != id)
            ////    return null;
            return TalkRepository.Instance.GetPersonTalkIds(id);
        }
        #endregion

        #region ITimeZoneRepository
        public Model.TimeZone GetTimeZoneById(Guid id)
        {
            return TimeZoneRepository.Instance.GetItemById(id);
        }

        public bool SetTimeZone(Model.TimeZone item)
        {
            //admin check
            return TimeZoneRepository.Instance.SetItem(item);
        }

        public bool RemoveTimeZone(Guid id)
        {
            //admin check
            return TimeZoneRepository.Instance.RemoveItem(id);
        }

        public bool UpdateTimeZone(Model.TimeZone item)
        {
            //admin check
            return TimeZoneRepository.Instance.UpdateItem(item);
        }

        public List<Model.TimeZone> GetAllTimeZones()
        {
            return TimeZoneRepository.Instance.GetAllItems();
        }
        #endregion
    }
}
