using EPAM.DBAttribute;
using EPAM.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Model
{
    [DBTable("AuthorSkill")]
    [DataContract]
    public class AuthorSkill : Base
    {
        [DataMember]
        private Guid _authorId;
        [DBColumn("AuthorId")]
        public Guid AuthorId
        {
            get { return _authorId; }
            set { _authorId = value; }
        }
        public Author Author
        {
            get { return AuthorRepository.Instance.GetItemById(_authorId); }
            set { _authorId = value.Id; }
        }

        [DataMember]
        private Guid _skillId;
        [DBColumn("SkillId")]
        public Guid SkillId
        {
            get { return _skillId; }
            set { _skillId = value; }
        }
        public Skill Skill
        {
            get { return SkillRepository.Instance.GetItemById(_skillId); }
            set { _skillId = value.Id; }
        }

        public AuthorSkill() : base() { }

        public AuthorSkill(Guid id) : base(id) { }
    }
}
