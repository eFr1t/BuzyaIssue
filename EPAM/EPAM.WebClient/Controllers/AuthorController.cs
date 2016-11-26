using EPAM.Model;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPAM.WebClient.Controllers
{
    public class AuthorController : Controller
    {
        #region FindJobs
        public void InitJobsPartial(List<Guid> jobIds, int page)
        {
            if (jobIds.Count == 0)
                ViewBag.HasJobs = false;
            else
            {
                ViewBag.HasJobs = true;

                ViewBag.Pages = new List<int>();
                for (int i = 0; i < (int)Math.Ceiling(jobIds.Count / 10.0); i++)
                {
                    ViewBag.Pages.Add(i + 1);
                }
                ViewBag.CurrentPage = page;
                ViewBag.Jobs = new List<Job>();
                for (int i = (page - 1) * 10; i < page * 10 && i < jobIds.Count; i++)
                {
                    ViewBag.Jobs.Add(JobRepository.Instance.GetItemById(jobIds[i]));
                }
            }
        }

        public ActionResult FindJobs()
        {
            if (Session["PersonId"] == null)
                return Redirect(ControllersLibrary.LogInPage);

            ViewBag.JobCategories = JobCategoryRepository.Instance.GetAllItems().OrderBy(i => i.Name);

            JobFilter jobFilter = new JobFilter();
            List<Guid> jobIds = JobRepository.Instance.GetFilterJobIdsDirectly(jobFilter);
            InitJobsPartial(jobIds, 1);

            return View(jobFilter);
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
        public void SaveFilter(JobFilter jobFilter)
        {
            if (Session["PersonId"] == null)
                return;

            jobFilter.AuthorId = (Guid)Session["PersonId"];
            JobFilterRepository.Instance.SetItem(jobFilter);
        }

        [HttpPost]
        public void RemoveFilter(Guid jobFilterId)
        {
            if (Session["PersonId"] == null)
                return;

            JobFilterRepository.Instance.RemoveItem(jobFilterId);
        }

        [HttpPost]
        public PartialViewResult GetSavedFilters()
        {
            if (Session["PersonId"] == null)
                return null;

            Author author = AuthorRepository.Instance.GetItemById((Guid)Session["PersonId"]);
            List<JobFilter> filters = JobFilterRepository.Instance.GetAuthorSavedJobFilters(author);
            if (filters.Count == 0)
                ViewBag.HasSavedFilters = false;
            else
            {
                ViewBag.HasSavedFilters = true;
                ViewBag.SavedFilters = filters;
            }
            return PartialView("_SavedFilters");
        }

        [HttpPost]
        public PartialViewResult GetJobsByFilter(JobFilter jobFilter, int page = 1)
        {
            if (Session["PersonId"] == null)
                return null;

            List<Guid> jobIds = JobRepository.Instance.GetFilterJobIdsDirectly(jobFilter);
            InitJobsPartial(jobIds, page);
            
            return PartialView("_Jobs", jobFilter);
        }

        [HttpPost]
        public PartialViewResult GetJobsByFilterId(Guid jobFilterId)
        {
            if (Session["PersonId"] == null)
                return null;

            List<Guid> jobIds = JobRepository.Instance.GetFilterJobIds(jobFilterId);
            InitJobsPartial(jobIds, 1);
            return PartialView("_Jobs", JobFilterRepository.Instance.GetItemById(jobFilterId));
        }

        [HttpPost]
        public void SaveJob(Guid jobId)
        {
            AuthorSavedJob asj = new AuthorSavedJob();
            asj.AuthorId = (Guid)Session["PersonId"];
            asj.JobId = jobId;
            AuthorSavedJobRepository.Instance.SetItem(asj);
        }

        [HttpPost]
        public void UnSaveJob(Guid jobId)
        {
            Author author = AuthorRepository.Instance.GetItemById((Guid)Session["PersonId"]);
            List<AuthorSavedJob> list = AuthorSavedJobRepository.Instance.GetAuthorSavedJobs(author);
            foreach (var item in list)
                if (item.JobId.Equals(jobId))
                    AuthorSavedJobRepository.Instance.RemoveItem(item);
        }
        #endregion

        #region SavedJobs
        public ActionResult SavedJobs()
        {
            if (Session["PersonId"] == null)
                return Redirect(ControllersLibrary.LogInPage);

            Author author = AuthorRepository.Instance.GetItemById((Guid)Session["PersonId"]);
            ViewBag.Jobs = JobRepository.Instance.GetAuthorSavedJobs(author);
            ViewBag.HasJobs = Enumerable.Count(ViewBag.Jobs) > 0;

            return View();
        }
        #endregion

        #region MyJobs
        public ActionResult MyJobs()
        {
            if (Session["PersonId"] == null)
                return Redirect(ControllersLibrary.LogInPage);

            Author author = AuthorRepository.Instance.GetItemById((Guid)Session["PersonId"]);
            ViewBag.OngoingJobs = JobRepository.Instance.GetAuthorOngoingJobs(author).OrderByDescending(i => i.PostedDate);
            ViewBag.HasOngoingJobs = Enumerable.Count(ViewBag.OngoingJobs) > 0;

            ViewBag.PastJobs = JobRepository.Instance.GetAuthorPastJobs(author);
            ViewBag.HasPastJobs = Enumerable.Count(ViewBag.PastJobs) > 0;

            return View();
        }

        public bool SubmitJob(Guid jobId)
        {
            if (Session["PersonId"] == null)
                return false;

            Job job = JobRepository.Instance.GetItemById(jobId);
            job.IsClosed = true;
            JobRepository.Instance.UpdateItem(job);

            return true;
        }
        #endregion

        #region JobOverview
        public ActionResult JobOverview(Guid? jobId = null)
        {
            if (Session["PersonId"] == null || jobId == null)
                return Redirect(ControllersLibrary.LogInPage);

            Guid authorId = (Guid)Session["PersonId"];
            Job job = JobRepository.Instance.GetItemById((Guid)jobId);
            ViewBag.AlreadyApplied = Enumerable.Count(job.Applications.Where(a => a.AuthorId == authorId)) > 0;

            return View(JobRepository.Instance.GetItemById((Guid)jobId));
        }
        #endregion

        #region JobApply
        public ActionResult JobApply(Guid? jobId = null)
        {
            if (Session["PersonId"] == null || jobId == null)
                return Redirect(ControllersLibrary.LogInPage);

            return View(JobRepository.Instance.GetItemById((Guid)jobId));
        }

        public bool SaveApply(List<Answer> answers, Guid jobId)
        {
            if (Session["PersonId"] == null)
                return false;

            Application application = new Application();
            application.AuthorId = (Guid)Session["PersonId"];
            application.JobId = jobId;
            ApplicationRepository.Instance.SetItem(application);

            foreach(var item in answers)
            {
                item.ApplicationId = application.Id;
                AnswerRepository.Instance.SetItem(item);
            }
            return true;
        }
        #endregion

        #region MyApplications
        public ActionResult MyApplications()
        {
            if (Session["PersonId"] == null)
                return Redirect(ControllersLibrary.LogInPage);

            Author author = AuthorRepository.Instance.GetItemById((Guid)Session["PersonId"]);
            ViewBag.OngoingApplications = ApplicationRepository.Instance.GetAuthorOngoingApplications(author);
            ViewBag.HasOngoingApplications = Enumerable.Count(ViewBag.OngoingApplications) > 0;

            ViewBag.PastApplications = ApplicationRepository.Instance.GetAuthorPastApplications(author);
            ViewBag.HasPastApplications = Enumerable.Count(ViewBag.PastApplications) > 0;

            return View();
        }
        #endregion

        #region ApplicationOverview
        public ActionResult ApplicationOverview(Guid? applicationId = null)
        {
            if (Session["PersonId"] == null || applicationId == null)
                return Redirect(ControllersLibrary.LogInPage);

            return View(ApplicationRepository.Instance.GetItemById((Guid)applicationId));
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
            Author author = AuthorRepository.Instance.GetItemById((Guid)id);

            return View(author);
        }

        [HttpPost]
        public PartialViewResult SaveAuthor(Author author)
        {
            if (Session["PersonId"] == null)
                return null;

            Author newAuthor = AuthorRepository.Instance.GetItemById((Guid)Session["PersonId"]);
            newAuthor.HourRate = author.HourRate;
            newAuthor.IsAvailable = author.IsAvailable;
            newAuthor.Name = author.Name;
            newAuthor.SName = author.SName;
            newAuthor.TimeZoneId = author.TimeZoneId;
            newAuthor.Title = author.Title;
            newAuthor.Overview = author.Overview;
            AuthorRepository.Instance.UpdateItem(newAuthor);
            Session["PersonName"] = newAuthor.Name + " " + newAuthor.SName;

            ViewBag.TimeZones = TimeZoneRepository.Instance.GetAllItems().OrderBy(i => i.Title);
            ViewBag.IsOwner = true;

            return PartialView("_ProfilePartial", newAuthor);
        }
        #endregion
    }
}