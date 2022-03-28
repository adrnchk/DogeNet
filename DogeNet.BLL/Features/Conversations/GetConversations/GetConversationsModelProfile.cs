// <copyright file="GetConversationsModelProfile.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Conversations.GetConversations
{
    using AutoMapper;
    using DogeNet.BLL.Features.Conversations.CreateConversation;
    using DogeNet.DAL.Models;

    public class GetConversationsModelProfile : Profile
    {
        public GetConversationsModelProfile()
        {
            this.CreateMap<Conversation, ConversationDetailsModel>();
        }
    }
}
