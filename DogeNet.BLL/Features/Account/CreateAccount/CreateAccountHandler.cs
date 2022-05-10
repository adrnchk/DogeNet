// <copyright file="CreateAccountHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.CreateAccount
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand>
    {
        private readonly DBContext context;

        private readonly IMapper mapper;

        public CreateAccountHandler(DBContext context,  IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var appUser = this.mapper.Map<User>(request.model);

            this.context.AppUsers.Add(appUser);
            await this.context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
