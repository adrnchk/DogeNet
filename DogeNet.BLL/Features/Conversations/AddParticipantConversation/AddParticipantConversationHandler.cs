﻿// <copyright file="AddParticipantConversationHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.AddParticipantConversation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;

    public class AddParticipantConversationHandler : IRequestHandler<AddParticipantConversationCommand>
    {
        private readonly DBContext context;

        private readonly IMapper mapper;

        public AddParticipantConversationHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<Unit> Handle(AddParticipantConversationCommand request, CancellationToken cancellationToken)
        {
            var participantConversation = this.mapper.Map<ConversationParticipant>(request.model);

            participantConversation.AddedAt = DateTime.Now;

            this.context.ConversationParticipants.Add(participantConversation);
            this.context.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}
