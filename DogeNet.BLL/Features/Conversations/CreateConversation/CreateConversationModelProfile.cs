// <copyright file="CreateConversationModelProfile.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.CreateConversation
{
    using AutoMapper;
    using DogeNet.DAL.Models;

    public class CreateConversationModelProfile : Profile
    {
        public CreateConversationModelProfile()
        {
            this.CreateMap<CreateConversationModel, Conversation>();
        }
    }
}
