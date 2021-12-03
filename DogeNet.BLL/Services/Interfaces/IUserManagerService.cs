// <copyright file="IUserManagerService.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;

    public interface IUserManagerService
    {
        Task<IdentityResult> CreateIdentityUser(IdentityUser user, string password);

        Task<IdentityUser> FindIdentityUser(string userName);
    }
}
