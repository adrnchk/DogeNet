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

    public class GetMessagesHandler : IRequestHandler<GetMessagesQuery, List<Message>>
    {
        private readonly DBContext context;

        public GetMessagesHandler(DBContext context)
        {
            this.context = context;
        }

        public async Task<List<Message>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(this.context.Messages.Where(message => message.ConversationId == request.conversationId).OrderBy(message => message.CreatedAt).ToList());
        }
    }
}
