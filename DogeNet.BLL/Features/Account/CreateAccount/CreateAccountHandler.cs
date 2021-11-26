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
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, int>
    {
        // Buisness logic goes here...
        private readonly DBContext context;

        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public CreateAccountHandler(DBContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            // DI db context
            this.context = context;

            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        // This method recieve a request that have a model in it and return PK of new User if it's OK
        public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            // Mapping model -> IdentityUser
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateAccountModel, IdentityUser>());
            var mapper = new Mapper(config);
            IdentityUser user = mapper.Map<IdentityUser>(request.model);

            // Creating new IdentityUser
            var result = await this.userManager.CreateAsync(user, request.model.Password);

            if (result.Succeeded)
            {
                await this.signInManager.SignInAsync(user, false);
            }
            else
            {
                return -1;
            }

            // Mapping model -> AppUser
            config = new MapperConfiguration(cfg => cfg.CreateMap<CreateAccountModel, User>());
            mapper = new Mapper(config);
            User appUser = mapper.Map<User>(request.model);

            this.context.AppUsers.Add(appUser);
            this.context.SaveChanges();

            return 0;
        }

        // Buisness logic ends here...
    }
}
