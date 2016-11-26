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
    [DBTable("ClientSavedAuthor")]
    [DataContract]
    public class ClientSavedAuthor : Base
    {
        [DataMember]
        private Guid _clientId;
        [DBColumn("ClientId")]
        public Guid ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }
        public Client Client
        {
            set { _clientId = value.Id; }
            get { return ClientRepository.Instance.GetItemById(_clientId); }
        }

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
            set { _authorId = value.Id; }
            get { return AuthorRepository.Instance.GetItemById(_authorId); }
        }

        public ClientSavedAuthor() : base() { }

        public ClientSavedAuthor(Guid id) : base(id) { }
    }
}
