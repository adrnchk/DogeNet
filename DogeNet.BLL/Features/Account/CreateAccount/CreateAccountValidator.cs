// <copyright file="CreateAccountValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.CreateAccount
{
    using FluentValidation;

    public class CreateAccountValidator : AbstractValidator<CreateAccountModel>
    {
        public CreateAccountValidator()
        {
            this.RuleFor(account => account.Password).NotEmpty().NotNull().MinimumLength(6).MaximumLength(100);
            this.RuleFor(account => account.Email).NotNull().NotEmpty().EmailAddress();
            this.RuleFor(account => account.FirstName).NotNull().NotEmpty().MaximumLength(50);
            this.RuleFor(account => account.RepeatPassword).NotNull().NotEmpty().Equal(account => account.Password);
            this.RuleFor(account => account.UserName).NotNull().NotEmpty().MaximumLength(50);
            this.RuleFor(account => account.LastName).MaximumLength(50);
        }
    }
}
