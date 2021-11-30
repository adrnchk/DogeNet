// <copyright file="CreateAccountValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.CreateAccount
{
    using DogeNet.DAL;
    using FluentValidation;

    public class CreateAccountValidator : AbstractValidator<CreateAccountModel>
    {
        public CreateAccountValidator(DBContext db)
        {
            this.RuleFor(account => account.Password).NotEmpty().NotNull().MinimumLength(AccountConstants.MinLengthForPassword)
                .MaximumLength(AccountConstants.MaxLengthForPassword);
            this.RuleFor(account => account.Email).NotNull().NotEmpty().EmailAddress();
            this.RuleFor(account => account.FirstName).NotNull().NotEmpty().MaximumLength(AccountConstants.MaxLengthForFirstName);
            this.RuleFor(account => account.RepeatPassword).NotNull().NotEmpty().Equal(account => account.Password);
            this.RuleFor(account => account.UserName).NotNull().NotEmpty().MaximumLength(AccountConstants.MaxLengthForUserName)
                .Must(name => AccountChecks.UniqueName(db, name)).WithMessage("Not unique UserName");
            this.RuleFor(account => account.LastName).MaximumLength(AccountConstants.MaxLengthForLastName);
        }
    }
}
