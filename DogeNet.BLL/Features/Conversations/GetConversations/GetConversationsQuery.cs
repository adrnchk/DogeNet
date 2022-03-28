// <copyright file="GetConversationsQuery.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.GetConversations
{
    using System.Collections.Generic;
    using DogeNet.BLL.Features.Conversations.CreateConversation;
    using MediatR;

    public record GetConversationsQuery(int userId) : IRequest<List<ConversationDetailsModel>>;
}
