// <copyright file="GetAccountByIdentityQuery.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.GetAccountByIdentity
{
    using DogeNet.BLL.Features.Account.GetAccount;
    using MediatR;

    public record GetAccountByIdentityQuery(string id) : IRequest<AccountDetailsModel>;
}
