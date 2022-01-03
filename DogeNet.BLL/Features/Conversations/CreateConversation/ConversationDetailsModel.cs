// <copyright file="ConversationDetailsModel.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.CreateConversation
{
    using System;

    public class ConversationDetailsModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int CreatorId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string AvatarImg { get; set; }
    }
}
