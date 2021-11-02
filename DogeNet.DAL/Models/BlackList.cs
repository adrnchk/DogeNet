// <copyright file="BlackList.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Models
{
    using System;

    public partial class BlackList
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FriendId { get; set; }

        public DateTime? AddedAt { get; set; }

        public virtual User Friend { get; set; }

        public virtual User User { get; set; }
    }
}
