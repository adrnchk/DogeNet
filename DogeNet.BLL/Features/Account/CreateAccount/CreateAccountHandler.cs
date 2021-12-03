// <copyright file="CreateAccountHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.CreateAccount
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.BLL.Services.Interfaces;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand>
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

        public async Task<Unit> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<IdentityUser>(request.model);

            var result = await this.userManager.CreateIdentityUser(user, request.model.Password);

            var appUser = this.mapper.Map<User>(request.model);
            appUser.IdentityId = user.Id;
            appUser.CreatedAt = System.DateTime.Now;

            this.context.AppUsers.Add(appUser);
            this.context.SaveChanges();

            return Unit.Value;
        }
    }
}
