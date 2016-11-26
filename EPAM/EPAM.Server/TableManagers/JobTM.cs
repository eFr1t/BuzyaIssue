using EPAM.Model;
using EPAM.Model.IRepository;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Server.TableManagers
{
    public class JobTM : BaseTM<Job>, IJobRepository
    {
        public JobTM() :
            base(JobRepository.Instance) { }

        public List<Guid> GetClientJobIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And ClientId = '{1}'", _defaultSelectCommand, id));
        }

        public List<Guid> GetFilterJobIds(Guid id)
        {
            return GetFilterJobIdsDirectly(JobFilterRepository.Instance.GetItemById(id));
        }

        public List<Guid> GetFilterJobIdsDirectly(JobFilter jobFilter)
        {
            string query = _defaultSelectCommand;
            if (jobFilter.JobCategory != null)
                query += String.Format(" And JobCategoryId = '{0}'", jobFilter.JobCategoryId);
            if (jobFilter.JobSubcategory != null)
                query += String.Format(" And JobSubcategoryId = '{0}'", jobFilter.JobSubcategoryId);
            if (jobFilter.DeadlineAfter != DateTime.MinValue)
                query += String.Format(" And Deadline >= '{0}'", jobFilter.DeadlineAfter.ToString("yyyy-MM-dd HH:mm:ss"));

            query += String.Format(" And Budget >= {0} And Budget <= {1}", jobFilter.BudgetMin, jobFilter.BudgetMax);
            query += " And AuthorId IS NULL";
            query += String.Format(" And (Title Like '%{0}%' Or ShortDescription Like '%{0}%' Or Description Like '%{0}%')", jobFilter.SearchString);
            query += " Order by PostedDate desc";

            return GetCustomList(query);
        }

        public List<Guid> GetAuthorOngoingJobIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And AuthorId = '{1}' And IsClosed = 0", _defaultSelectCommand, id));
        }

        public List<Guid> GetAuthorPastJobIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And AuthorId = '{1}' And IsClosed = 1", _defaultSelectCommand, id));
        }

        public List<Guid> GetClientOngoingJobIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And ClientId = '{1}' And IsClosed = 0", _defaultSelectCommand, id));
        }

        public List<Guid> GetClientPastJobIds(Guid id)
        {
            return GetCustomList(String.Format("{0} And ClientId = '{1}' And IsClosed = 1", _defaultSelectCommand, id));
        }
    }
}
