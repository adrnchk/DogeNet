// <copyright file="GetAccountHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.GetAccount
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

    public class GetAccountHandler : IRequestHandler<GetAccountQuery, AccountDetailsModel>
    {
        private readonly DBContext context;
        private readonly IMapper mapper;

        public GetAccountHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<AccountDetailsModel> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            var user = this.context.AppUsers.Where(user => user.Id == request.userId).FirstOrDefault();

            return Task.FromResult(this.mapper.Map<User, AccountDetailsModel>(user));
        }
    }
}
