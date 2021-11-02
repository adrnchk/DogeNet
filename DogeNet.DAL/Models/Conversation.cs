// <copyright file="Conversation.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Conversation
    {
        public Conversation()
        {
            this.ConversationParticipants = new HashSet<ConversationParticipant>();
            this.Messages = new HashSet<Message>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int CreatorId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string AvatarImg { get; set; }

        public int? StatusId { get; set; }

        public virtual User Creator { get; set; }

        public virtual Status Status { get; set; }

        public virtual ICollection<ConversationParticipant> ConversationParticipants { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
