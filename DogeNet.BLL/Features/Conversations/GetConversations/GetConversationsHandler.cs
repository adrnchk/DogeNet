// <copyright file="GetConversationsHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.GetConversations
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

    public class GetConversationsHandler : IRequestHandler<GetConversationsQuery, List<ConversationDetailsModel>>
    {
        private readonly DBContext context;
        private readonly IMapper mapper;

        public GetConversationsHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<ConversationDetailsModel>> Handle(GetConversationsQuery request, CancellationToken cancellationToken)
        {
            var convIdList = this.context.ConversationParticipants.Where(cp => cp.UserId == request.userId).Select(o => o.ConversationId).ToList();
            var conversations = this.context.Conversations.Where(c => convIdList.Contains(c.Id)).ToList();

            return this.mapper.Map<List<Conversation>, List<ConversationDetailsModel>>(conversations);
        }
    }
}
