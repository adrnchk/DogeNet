// <copyright file="UpdateAccountCommand.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.UpdateAccount
{
    using DogeNet.BLL.Features.Account.GetAccount;
    using MediatR;

    public record UpdateAccountCommand(UpdateAccountDetailsModel model) : IRequest<AccountDetailsModel>;
}
