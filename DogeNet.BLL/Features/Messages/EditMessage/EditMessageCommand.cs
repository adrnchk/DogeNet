// <copyright file="EditMessageCommand.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Messages.EditMessage
{
    using DogeNet.BLL.Features.Messages.GetMessages;
    using MediatR;

    public record EditMessageCommand(EditMessageModel model) : IRequest<MessagesDetailsModel>;
}
