// <copyright file="AddParticipantConversationModelProfile.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.AddParticipantConversation
{
    using System;
    using AutoMapper;
    using DogeNet.DAL.Models;

    public class AddParticipantConversationModelProfile : Profile
    {
        public AddParticipantConversationModelProfile()
        {
            this.CreateMap<AddParticipantConversationModel, ConversationParticipant>()
                .ForMember(src => src.AddedAt, opt => opt.MapFrom(c => DateTime.Now));
        }
    }
}
