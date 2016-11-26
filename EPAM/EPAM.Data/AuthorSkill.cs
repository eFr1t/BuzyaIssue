using EPAM.Data.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Data
{
    [DataContract]
    public class AuthorSkill
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        private Guid _authorId;
        public Author Author
        {
            get { return AuthorManager.Instance.Authors[_authorId]; }
            set { _authorId = value.Id; }
        }

        [DataMember]
        private Guid _skillId;
        public Skill Skill
        {
            get { return SkillManager.Instance.Skills[_skillId]; }
            set { _skillId = value.Id; }
        }

        public AuthorSkill() { Id = Guid.NewGuid(); }
    }
}
