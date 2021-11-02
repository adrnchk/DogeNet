// <copyright file="Group.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Group
    {
        public Group()
        {
            this.GroupParticipants = new HashSet<GroupParticipant>();
            this.GroupPosts = new HashSet<GroupPost>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public int? CreatorId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string AvatarImg { get; set; }

        public string CoverImg { get; set; }

        public int? StatusId { get; set; }

        public virtual User Creator { get; set; }

        public virtual Status Status { get; set; }

        public virtual ICollection<GroupParticipant> GroupParticipants { get; set; }

        public virtual ICollection<GroupPost> GroupPosts { get; set; }
    }
}
