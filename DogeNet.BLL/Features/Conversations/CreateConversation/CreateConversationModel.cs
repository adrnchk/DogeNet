// <copyright file="CreateConversationModel.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.CreateConversation
{
    using System;

    public class CreateConversationModel
    {
        public string Title { get; set; }

        public int CreatorId { get; set; }

        public int SecondUserId { get; set; }

        public string AvatarImg { get; set; }
    }
}
