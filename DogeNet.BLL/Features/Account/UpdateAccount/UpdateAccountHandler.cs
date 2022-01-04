// <copyright file="UpdateAccountHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.UpdateAccount
{
    using DogeNet.BLL.Features.Account.GetAccount;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, AccountDetailsModel>
    {
        public Task<AccountDetailsModel> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
