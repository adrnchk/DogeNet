// <copyright file="GetAccountByIdentityHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.GetAccountByIdentity
{
    using AutoMapper;
    using DogeNet.BLL.Features.Account.GetAccount;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAccountByIdentityHandler : IRequestHandler<GetAccountByIdentityQuery, AccountDetailsModel>
    {
        private readonly DBContext context;
        private readonly IMapper mapper;

        public GetAccountByIdentityHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<AccountDetailsModel> Handle(GetAccountByIdentityQuery request, CancellationToken cancellationToken)
        {
            var user = this.context.AppUsers.Where(user => user.IdentityId.Equals(request.id)).FirstOrDefault();

            return Task.FromResult(this.mapper.Map<User, AccountDetailsModel>(user));
        }
    }
}
