﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model.IRepository
{
    public interface IAuthorSavedJobRepository : IBaseRepository<AuthorSavedJob>
    {
        List<Guid> GetAuthorSavedJobIds(Guid id);
    }
}
