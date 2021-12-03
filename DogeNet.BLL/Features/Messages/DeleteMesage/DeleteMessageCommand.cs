// <copyright file="DeleteMessageCommand.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Messages.DeleteMesage
{
    using MediatR;

    public record DeleteMessageCommand(int messageId) : IRequest;
}
