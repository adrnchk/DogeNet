// <copyright file="CreateAccountModelProfiles.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.CreateAccount
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.DAL.Models;
    using Microsoft.AspNetCore.Identity;

    public class CreateAccountModelProfiles : Profile
    {
        public CreateAccountModelProfiles()
        {
            this.CreateMap<CreateAccountModel, User>();
            this.CreateMap<CreateAccountModel, IdentityUser>();
        }
    }
}
