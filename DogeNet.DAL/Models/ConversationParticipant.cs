// <copyright file="ConversationParticipant.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Models
{
    using System;

    public partial class ConversationParticipant
    {
        public int Id { get; set; }

        public int ConversationId { get; set; }

        public int UserId { get; set; }

        public DateTime? AddedAt { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public virtual Conversation Conversation { get; set; }

        public virtual User User { get; set; }
    }
}
