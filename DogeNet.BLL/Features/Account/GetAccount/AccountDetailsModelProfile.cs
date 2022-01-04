// <copyright file="AccountDetailsModelProfile.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.GetAccount
{
    using AutoMapper;
    using DogeNet.DAL.Models;

    public class AccountDetailsModelProfile : Profile
    {
        public AccountDetailsModelProfile()
        {
            this.CreateMap<User, AccountDetailsModel>();
        }
    }
}
