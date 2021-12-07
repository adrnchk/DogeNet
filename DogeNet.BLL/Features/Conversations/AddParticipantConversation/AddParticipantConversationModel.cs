// <copyright file="AddParticipantConversationModel.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.AddParticipantConversation
{
    using System;

    public class AddParticipantConversationModel
    {
        public string Title { get; set; }

        public int ConversationId { get; set; }

        public int UserId { get; set; }

        public DateTime AddedAt { get; set; }
    }
}
