// <copyright file="GetMessagesModelProfile.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Messages.GetMessages
{
    using AutoMapper;
    using DogeNet.DAL.Models;

    public class GetMessagesModelProfile : Profile
    {
        public GetMessagesModelProfile()
        {
            this.CreateMap<Message, MessagesDetailsModel>();
        }
    }
}
