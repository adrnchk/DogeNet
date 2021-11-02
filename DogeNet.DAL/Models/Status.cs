// <copyright file="Status.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Models
{
    using System.Collections.Generic;

    public partial class Status
    {
        public Status()
        {
            this.Conversations = new HashSet<Conversation>();
            this.Groups = new HashSet<Group>();
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string StatusName { get; set; }

        public virtual ICollection<Conversation> Conversations { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
