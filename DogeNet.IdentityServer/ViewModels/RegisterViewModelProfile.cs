// <copyright file="RegisterViewModelProfile.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.IdentityServer.ViewModels
{
    using AutoMapper;
    using DogeNet.BLL.Features.Account.CreateAccount;

    public class RegisterViewModelProfile : Profile
    {
        public RegisterViewModelProfile()
        {
            this.CreateMap<RegisterViewModel, CreateAccountModel>();
        }
    }
}
