// <copyright file="CreateAccountHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.CreateAccount
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.BLL.Services.Interfaces;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, int>
    {
        private readonly DBContext context;

        private readonly IUserManagerService userManager;

        private readonly IMapper mapper;

        public CreateAccountHandler(DBContext context, IUserManagerService userManager, IMapper mapper)
        {
            this.context = context;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<IdentityUser>(request.model);

            var result = await this.userManager.CreateIdentityUser(user, request.model.Password);

            var appUser = this.mapper.Map<User>(request.model);

            this.context.AppUsers.Add(appUser);
            this.context.SaveChanges();

            return 0;
        }
    }
}
