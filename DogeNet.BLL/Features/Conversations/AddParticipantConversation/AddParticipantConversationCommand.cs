// <copyright file="AddParticipantConversationCommand.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.AddParticipantConversation
{
    using MediatR;

    public record AddParticipantConversationCommand(AddParticipantConversationModel model) : IRequest;
}
