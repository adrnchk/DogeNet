// <copyright file="GetMessageModelProfile.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Messages.GetMessages
{
    using AutoMapper;
    using DogeNet.DAL.Models;

    public class GetMessageModelProfile : Profile
    {
        public GetMessageModelProfile()
        {
            this.CreateMap<Message, MessagesDetailsModel>();
        }
    }
}
