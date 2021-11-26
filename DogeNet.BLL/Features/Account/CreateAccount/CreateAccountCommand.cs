// <copyright file="CreateAccountCommand.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.CreateAccount
{
    using MediatR;

    public record CreateAccountCommand(CreateAccountModel model) : IRequest<int>;
}
