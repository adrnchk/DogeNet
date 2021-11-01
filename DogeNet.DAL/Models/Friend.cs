// <copyright file="Friend.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Models
{
    using System;

    public partial class Friend
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FriendId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual User FriendNavigation { get; set; }

        public virtual User User { get; set; }
    }
}
