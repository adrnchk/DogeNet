// <copyright file="GetAccountQuery.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.GetAccount
{
    using MediatR;

    public record GetAccountQuery(int userId) : IRequest<AccountDetailsModel>;
}
