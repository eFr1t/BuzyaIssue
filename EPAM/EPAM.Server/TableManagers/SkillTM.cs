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
    public class SkillTM : BaseTM<Skill>, ISkillRepository
    {
        public SkillTM() :
            base(SkillRepository.Instance) { }
    }
}
