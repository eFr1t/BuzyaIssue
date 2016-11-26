using EPAM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Interfaces
{
    public interface ISkill
    {
        bool CreateSkill(Skill skill);
        bool DeleteSkill(Skill skill);
    }
}
