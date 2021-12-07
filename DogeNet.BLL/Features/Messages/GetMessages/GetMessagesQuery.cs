// <copyright file="GetMessagesQuery.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Messages.GetMessage
{
    using System.Collections.Generic;
    using DogeNet.BLL.Features.Messages.GetMessages;
    using MediatR;

    public record GetMessagesQuery(int conversationId) : IRequest<List<MessagesDetailsModel>>;
}
