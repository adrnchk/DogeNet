// <copyright file="CreateAccountValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.CreateAccount
{
    using FluentValidation;

    public class CreateAccountValidator : AbstractValidator<CreateAccountModel>
    {
        private const int MaxLengthForPassword = 100;
        private const int MinLengthForPassword = 6;
        private const int MaxLengthForUserName = 50;
        private const int MaxLengthForFirstName = 50;
        private const int MaxLengthForLastName = 50;

        public CreateAccountValidator()
        {
            this.RuleFor(account => account.Password).NotEmpty().NotNull().MinimumLength(MinLengthForPassword).MaximumLength(MaxLengthForPassword);
            this.RuleFor(account => account.Email).NotNull().NotEmpty().EmailAddress();
            this.RuleFor(account => account.FirstName).NotNull().NotEmpty().MaximumLength(MaxLengthForFirstName);
            this.RuleFor(account => account.RepeatPassword).NotNull().NotEmpty().Equal(account => account.Password);
            this.RuleFor(account => account.UserName).NotNull().NotEmpty().MaximumLength(MaxLengthForUserName);
            this.RuleFor(account => account.LastName).MaximumLength(MaxLengthForLastName);
        }
    }
}
