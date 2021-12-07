// <copyright file="CreateConversationHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.CreateConversation
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.BLL.Services.Interfaces;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class CreateConversationHandler : IRequestHandler<CreateConversationCommand, ConversationDetailsModel>
    {
        private readonly DBContext context;

        private readonly IMapper mapper;

        public CreateConversationHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ConversationDetailsModel> Handle(CreateConversationCommand request, CancellationToken cancellationToken)
        {
            var conversation = this.mapper.Map<Conversation>(request.model);

            this.context.Conversations.Add(conversation);

            var sender = new ConversationParticipant()
            {
                UserId = request.model.CreatorId,
                AddedAt = System.DateTime.Now,
            };

            var reciever = new ConversationParticipant()
            {
                UserId = request.model.SecondUserId,
                AddedAt = System.DateTime.Now,
            };

            conversation.ConversationParticipants.Add(sender);
            conversation.ConversationParticipants.Add(reciever);

            await this.context.SaveChangesAsync();
            return this.mapper.Map<ConversationDetailsModel>(conversation);
        }
    }
}
