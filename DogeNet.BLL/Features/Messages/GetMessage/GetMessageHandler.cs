// <copyright file="GetMessageHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Messages.GetMessage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;

    public class GetMessageHandler : IRequestHandler<GetMessageQuery, List<Message>>
    {
        private readonly DBContext context;

        public GetMessageHandler(DBContext context)
        {
            this.context = context;
        }

        public Task<List<Message>> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(this.context.Messages.Where(message => message.ConversationId == request.conversationId).OrderBy(message => message.CreatedAt).ToList());
        }
    }
}
