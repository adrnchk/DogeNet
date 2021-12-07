// <copyright file="CreateConversationCommand.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.CreateConversation
{
    using DogeNet.DAL.Models;
    using MediatR;

    public record CreateConversationCommand(CreateConversationModel model) : IRequest<ConversationDetailsModel>;
}
