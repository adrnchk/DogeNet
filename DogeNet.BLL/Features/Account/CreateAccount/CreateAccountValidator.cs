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
            this.RuleFor(enitity => enitity.Password).NotEmpty().NotNull().MinimumLength(AccountConstants.MinLengthForPassword)
                .MaximumLength(AccountConstants.MaxLengthForPassword);
            this.RuleFor(enitity => enitity.FirstName).NotNull().NotEmpty().MaximumLength(AccountConstants.MaxLengthForFirstName);
            this.RuleFor(enitity => enitity.RepeatPassword).NotNull().NotEmpty().Equal(enitity => enitity.Password);
            this.RuleFor(enitity => enitity.UserName).NotNull().NotEmpty().MaximumLength(AccountConstants.MaxLengthForUserName)
                .Must(name => AccountChecks.UniqueName(db, name)).WithMessage("Not unique UserName");
            this.RuleFor(enitity => enitity.LastName).MaximumLength(AccountConstants.MaxLengthForLastName);
        }
    }
}
