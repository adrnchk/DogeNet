// <copyright file="GetConversationByIdQuery.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.GetConversationById
{
    using DogeNet.BLL.Features.Conversations.CreateConversation;
    using MediatR;

    public record GetConversationByIdQuery(int conversationId) : IRequest<ConversationDetailsModel>;
}
