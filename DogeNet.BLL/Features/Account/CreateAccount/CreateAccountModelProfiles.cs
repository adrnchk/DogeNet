// <copyright file="CreateAccountModelProfiles.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.CreateAccount
{
    using System;
    using AutoMapper;
    using DogeNet.DAL.Models;
    using Microsoft.AspNetCore.Identity;

    public class CreateAccountModelProfiles : Profile
    {
        public CreateAccountModelProfiles()
        {
            this.CreateMap<CreateAccountModel, User>()
                .ForMember(src => src.CreatedAt, opt => opt.MapFrom(c => DateTime.Now));
            this.CreateMap<CreateAccountModel, IdentityUser>();
        }
    }
}
