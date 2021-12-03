// <copyright file="GetMessageQuery.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Messages.GetMessage
{
    using System.Collections.Generic;
    using DogeNet.DAL.Models;
    using MediatR;

    public record GetMessageQuery(int conversationId) : IRequest<List<Message>>;
}
