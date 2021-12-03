// <copyright file="AddParticipantConversationModelProfile.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.AddParticipantConversation
{
    using AutoMapper;
    using DogeNet.DAL.Models;

    public class AddParticipantConversationModelProfile : Profile
    {
        public AddParticipantConversationModelProfile()
        {
            this.CreateMap<AddParticipantConversationModel, ConversationParticipant>();
        }
    }
}
