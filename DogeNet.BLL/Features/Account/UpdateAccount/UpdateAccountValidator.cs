// <copyright file="UpdateAccountValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.UpdateAccount
{
    using DogeNet.DAL;
    using FluentValidation;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UpdateAccountValidator : AbstractValidator<UpdateAccountDetailsModel>
    {
        public UpdateAccountValidator(DBContext db)
        {
            this.RuleFor(enitity => enitity.FirstName).NotNull().NotEmpty().MaximumLength(AccountConstants.MaxLengthForFirstName);
            this.RuleFor(enitity => enitity.UserName).NotNull().NotEmpty().MaximumLength(AccountConstants.MaxLengthForUserName)
                .Must(name => AccountChecks.UniqueName(db, name)).WithMessage("Not unique UserName");
            this.RuleFor(enitity => enitity.LastName).MaximumLength(AccountConstants.MaxLengthForLastName);
        }
    }
}
