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
    using AutoMapper;
    using DogeNet.BLL.Features.Messages.GetMessages;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetMessagesHandler : IRequestHandler<GetMessagesQuery, List<MessagesDetailsModel>>
    {
        private readonly DBContext context;
        private readonly IMapper mapper;

        public GetMessagesHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<MessagesDetailsModel>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            var messages = await this.context.Messages.Where(message => message.ConversationId == request.conversationId).OrderBy(message => message.CreatedAt).ToListAsync();

            return this.mapper.Map<List<Message>, List<MessagesDetailsModel>>(messages);
        }
    }
}
