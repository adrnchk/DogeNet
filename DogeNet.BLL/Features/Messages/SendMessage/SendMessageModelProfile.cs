// <copyright file="SendMessageModelProfile.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Messages.SendMessage
{
    using System;
    using AutoMapper;
    using DogeNet.DAL.Models;

    public class SendMessageModelProfile : Profile
    {
        public SendMessageModelProfile()
        {
            this.CreateMap<SendMessageModel, Message>()
                .ForMember(src => src.CreatedAt, opt => opt.MapFrom(c => DateTime.Now));
        }
    }
}
