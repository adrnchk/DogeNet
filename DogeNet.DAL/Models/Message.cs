// <copyright file="Message.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Models
{
    using System;

    public partial class Message
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ConversationId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Text { get; set; }

        public virtual Conversation Conversation { get; set; }

        public virtual User User { get; set; }
    }
}
