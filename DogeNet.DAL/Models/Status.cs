using System;
using System.Collections.Generic;


namespace DogeNet.DAL.Models
{
    public partial class Status
    {
        public Status()
        {
            Conversations = new HashSet<Conversation>();
            Groups = new HashSet<Group>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Conversation> Conversations { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
