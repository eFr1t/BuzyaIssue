using EPAM.Model;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EPAM.WebClient.Controllers
{
    public class ClientController : Controller
    {
        #region CreateJob
        public ActionResult CreateJob()
        {
            if (Session["PersonId"] == null)
                return Redirect(ControllersLibrary.LogInPage);

            ViewBag.JobCategories = JobCategoryRepository.Instance.GetAllItems().OrderBy(i => i.Name);
            ViewBag.Questions = QuestionRepository.Instance.GetAllDefaultQuestions().OrderBy(i => i.Text);
            ViewBag.Skills = SkillRepository.Instance.GetAllItems().OrderBy(i => i.Title);
            return View();
        }

        [HttpPost]
        public PartialViewResult GetJobSubcategories(Guid JobCategoryId)
        {
            if (Session["PersonId"] == null)
                return null;

            List<JobSubcategory> jobSubcategories = JobSubcategoryRepository.Instance.GetCategorySubcategories(JobCategoryRepository.Instance.GetItemById(JobCategoryId));
            ViewBag.JobSubcategories = jobSubcategories.OrderBy(i => i.Name);
            ViewBag.HasItems = jobSubcategories.Count > 0;
            return PartialView("_JobSubcategory");
        }

        [HttpPost]
        public String GetQuestionTemplate()
        {
            if (Session["PersonId"] == null)
                return "";

            ViewBag.Questions = QuestionRepository.Instance.GetAllDefaultQuestions().OrderBy(i => i.Text);
            ViewBag.Num = 0;
            string t = ControllersLibrary.RenderPartialToString("~/Views/Client/_CreateQuestion.cshtml", this.ControllerContext, ViewData, TempData);
            return t;
        }

        [HttpPost]
        public String CreateJob(Job job, List<Question> questions, List<Guid> skillIds)
        {
            if (Session["PersonId"] == null || questions.Count > 5)
                return "";

            job.ClientId = (Guid)Session["PersonId"];
            job.PostedDate = DateTime.Now;
            if (JobRepository.Instance.SetItem(job))
            {
                foreach(var item in questions)
                {
                    item.Job = job;
                    QuestionRepository.Instance.SetItem(item);
                }
                foreach(var id in skillIds)
                {
                    JobSkill js = new JobSkill();
                    js.Job = job;
                    js.SkillId = id;
                    JobSkillRepository.Instance.SetItem(js);
                }
                return "/Client/PostedJobs";
            }
            return "";
        }
        #endregion

        #region PostedJobs
        public ActionResult PostedJobs()
        {
            if (Session["PersonId"] == null)
                return Redirect(ControllersLibrary.LogInPage);

            Client client = ClientRepository.Instance.GetItemById((Guid)Session["PersonId"]);
            ViewBag.Jobs = JobRepository.Instance.GetClientOngoingJobs(client).Where(i => i.Author == null).OrderByDescending(i => i.PostedDate);
            ViewBag.HasJobs = Enumerable.Count(ViewBag.Jobs) > 0;

            return View();
        }
        #endregion

        #region ApplicationOverview
        public ActionResult ApplicationOverview(Guid applicationId)
        {
            if (Session["PersonId"] == null)
                return Redirect(ControllersLibrary.LogInPage);

            return View(ApplicationRepository.Instance.GetItemById(applicationId));
        }

        public bool ApproveApplication(Guid applicationId)
        {
            Application application = ApplicationRepository.Instance.GetItemById(applicationId);
            application.IsApproved = true;
            ApplicationRepository.Instance.UpdateItem(application);

            Job job = application.Job;
            job.AuthorId = application.AuthorId;
            JobRepository.Instance.UpdateItem(job);

            foreach (var item in application.Job.Applications)
            {
                item.IsClosed = true;
                ApplicationRepository.Instance.UpdateItem(item);
            }

            return true;
        }

        public bool DeclineApplication(Guid applicationId)
        {
            Application application = ApplicationRepository.Instance.GetItemById(applicationId);
            application.IsClosed = true;
            ApplicationRepository.Instance.UpdateItem(application);

            return true;
        }
        #endregion

        #region JobOverview
        public ActionResult JobOverview(Guid jobId)
        {
            if (Session["PersonId"] == null)
                return Redirect(ControllersLibrary.LogInPage);

            return View(JobRepository.Instance.GetItemById(jobId));
        }
        #endregion

        #region MyJobs
        public ActionResult MyJobs()
        {
            if (Session["PersonId"] == null)
                return Redirect(ControllersLibrary.LogInPage);

            Client client = ClientRepository.Instance.GetItemById((Guid)Session["PersonId"]);
            ViewBag.OngoingJobs = JobRepository.Instance.GetClientOngoingJobs(client).Where(i => i.Author != null).OrderByDescending(i => i.PostedDate);
            ViewBag.HasOngoingJobs = Enumerable.Count(ViewBag.OngoingJobs) > 0;

            ViewBag.PastJobs = JobRepository.Instance.GetClientPastJobs(client);
            ViewBag.HasPastJobs = Enumerable.Count(ViewBag.PastJobs) > 0;

            return View();
        }
        #endregion

        #region AuthorOverview
        public ActionResult AuthorOverview(Guid authorId)
        {
            if (Session["PersonId"] == null)
                return Redirect(ControllersLibrary.LogInPage);

            return View(AuthorRepository.Instance.GetItemById(authorId));
        }
        #endregion

        #region FindAuthors
        public void InitAuthorsPartial(List<Guid> authorIds, int page)
        {
            if (authorIds.Count == 0)
                ViewBag.HasAuthors = false;
            else
            {
                ViewBag.HasAuthors = true;

                ViewBag.Pages = new List<int>();
                for (int i = 0; i < (int)Math.Ceiling(authorIds.Count / 10.0); i++)
                {
                    ViewBag.Pages.Add(i + 1);
                }
                ViewBag.CurrentPage = page;
                ViewBag.Authors = new List<Author>();
                for (int i = (page - 1) * 10; i < page * 10 && i < authorIds.Count; i++)
                {
                    ViewBag.Authors.Add(AuthorRepository.Instance.GetItemById(authorIds[i]));
                }
            }
        }

        public ActionResult FindAuthors()
        {
            if (Session["PersonId"] == null)
                return Redirect(ControllersLibrary.LogInPage);

            ViewBag.Skills = SkillRepository.Instance.GetAllItems().OrderBy(i => i.Title);
            AuthorFilter af = new AuthorFilter();
            List<Guid> authorIds = AuthorRepository.Instance.GetFilterAuthorIdsDirectly(af);
            InitAuthorsPartial(authorIds, 1);

            return View(af);
        }

        [HttpPost]
        public PartialViewResult GetAuthorsByFilter(AuthorFilter authorFilter, int page = 1)
        {
            if (Session["PersonId"] == null)
                return null;

            List<Guid> authorIds = AuthorRepository.Instance.GetFilterAuthorIdsDirectly(authorFilter);
            InitAuthorsPartial(authorIds, page);

            return PartialView("_Authors", authorFilter);
        }

        [HttpPost]
        public void SaveAuthor(Guid authorId)
        {
            ClientSavedAuthor csa = new ClientSavedAuthor();
            csa.ClientId = (Guid)Session["PersonId"];
            csa.AuthorId = authorId;
            ClientSavedAuthorRepository.Instance.SetItem(csa);
        }

        [HttpPost]
        public void UnSaveAuthor(Guid authorId)
        {
            Client client = ClientRepository.Instance.GetItemById((Guid)Session["PersonId"]);
            List<ClientSavedAuthor> list = ClientSavedAuthorRepository.Instance.GetClientSavedAuthors(client);
            foreach (var item in list)
                if (item.AuthorId.Equals(authorId))
                    ClientSavedAuthorRepository.Instance.RemoveItem(item);
        }
        #endregion

        #region SavedAuthors
        public ActionResult SavedAuthors()
        {
            if (Session["PersonId"] == null)
                return Redirect(ControllersLibrary.LogInPage);

            Client client = ClientRepository.Instance.GetItemById((Guid)Session["PersonId"]);
            ViewBag.Authors = AuthorRepository.Instance.GetClientSavedAuthors(client);
            ViewBag.HasAuthors = Enumerable.Count(ViewBag.Authors) > 0;

            return View();
        }
        #endregion

        #region MyAuthors
        public ActionResult MyAuthors()
        {
            if (Session["PersonId"] == null)
                return Redirect(ControllersLibrary.LogInPage);

            Client client = ClientRepository.Instance.GetItemById((Guid)Session["PersonId"]);

            ViewBag.OngoingAuthors = JobRepository.Instance.GetClientOngoingJobs(client).Where(i => i.Author != null).Select(i => i.Author).Distinct();
            ViewBag.HasOngoingAuthors = Enumerable.Count(ViewBag.OngoingAuthors) > 0;

            ViewBag.PastAuthors = JobRepository.Instance.GetClientPastJobs(client).Select(i => i.Author).Distinct();
            ViewBag.HasPastAuthors = Enumerable.Count(ViewBag.PastAuthors) > 0;

            return View();
        }
        #endregion

        #region Talks
        public ActionResult Talks()
        {
            if (Session["PersonId"] == null)
                return Redirect(ControllersLibrary.LogInPage);

            return View();
        }
        #endregion

        #region Profile
        public ActionResult Profile(Guid? id = null)
        {
            if (Session["PersonId"] == null)
                return Redirect(ControllersLibrary.LogInPage);

            Guid personId = (Guid)Session["PersonId"];

            if (id == null)
                return null;

            ViewBag.TimeZones = TimeZoneRepository.Instance.GetAllItems().OrderBy(i => i.Title);
            ViewBag.IsOwner = id.Equals(personId);
            Client client = ClientRepository.Instance.GetItemById((Guid)id);

            return View(client);
        }

        [HttpPost]
        public PartialViewResult SaveClient(Client client)
        {
            if (Session["PersonId"] == null)
                return null;

            Client newClient = ClientRepository.Instance.GetItemById((Guid)Session["PersonId"]);
            newClient.Name = client.Name;
            newClient.SName = client.SName;
            newClient.IsCompany = client.IsCompany;
            newClient.CompanyName = client.CompanyName;
            newClient.TimeZoneId = client.TimeZoneId;
            newClient.Overview = client.Overview;
            ClientRepository.Instance.UpdateItem(newClient);
            Session["PersonName"] = newClient.Name + " " + newClient.SName;

            ViewBag.TimeZones = TimeZoneRepository.Instance.GetAllItems().OrderBy(i => i.Title);
            ViewBag.IsOwner = true;

            return PartialView("_ProfilePartial", newClient);
        }
        #endregion
    }
}