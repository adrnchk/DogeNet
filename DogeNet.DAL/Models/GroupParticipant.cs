// <copyright file="GroupParticipant.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Models
{
    using System;

    public partial class GroupParticipant
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public int UserId { get; set; }

        public DateTime? AddedAt { get; set; }

        public string Status { get; set; }

        public virtual Group Group { get; set; }

        public virtual User User { get; set; }
    }
}
