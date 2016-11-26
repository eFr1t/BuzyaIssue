using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.Data.Managers;

namespace EPAM.Data
{
    public class Author : Person
    {
        public String PhotoPath { get; set; }
        public String Title { get; set; }
        public String Overview { get; set; }

        public List<Application> Applications
        {
            get
            {
                List<Application> res = new List<Application>();
                foreach (var app in ApplicationManager.Instance.Applications)
                    if (app.Value.Author == this)
                        res.Add(app.Value);
                return res;
            }
        }

        public List<Skill> Skills
        {
            get
            {
                return (from authorSkills in AuthorSkillManager.Instance.AuthorSkills.Values
                        where authorSkills.Author == this
                        select authorSkills.Skill).ToList();
            }
        }


        public Author(String login, String password)
            : base(login, password) { }

        public Author(Guid id, String login, String password) : base(id, login, password) { }

        public Author(Guid id) : base(id) { }
    }
}
