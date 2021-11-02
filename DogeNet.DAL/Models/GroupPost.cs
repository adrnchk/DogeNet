// <copyright file="GroupPost.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Models
{
    public partial class GroupPost
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }

        public int PostId { get; set; }

        public virtual Group Owner { get; set; }

        public virtual Post Post { get; set; }
    }
}
