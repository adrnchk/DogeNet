// <copyright file="GetConversationByIdHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.GetConversationById
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.BLL.Features.Conversations.CreateConversation;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;

    public class GetConversationByIdHandler : IRequestHandler<GetConversationByIdQuery, ConversationDetailsModel>
    {
        private readonly DBContext context;
        private readonly IMapper mapper;

        public GetConversationByIdHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ConversationDetailsModel> Handle(GetConversationByIdQuery request, CancellationToken cancellationToken)
        {
            var conversation = await this.context.Conversations.FindAsync(request.conversationId);

            return this.mapper.Map<Conversation, ConversationDetailsModel>(conversation);
        }
    }
}
