// <copyright file="CreateAccountValidatorTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Account
{
    using DogeNet.BLL.Features.Account;
    using DogeNet.BLL.Features.Account.CreateAccount;
    using DogeNet.DAL;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class CreateAccountValidatorTests
    {
        private readonly DBContext context;
        private readonly CreateAccountValidator validator;

        public CreateAccountValidatorTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();

            optionsBuilder.UseInMemoryDatabase("TEST_CREATE_ACCOUNT");

            this.context = new DBContext(optionsBuilder.Options);

            this.validator = new CreateAccountValidator(this.context);
        }

        [Fact]
        public void ValidationNormal()
        {
            var model = new CreateAccountModel()
            {
                UserName = "UserNameTestNormal",
                Password = "UserPassword123#",
                RepeatPassword = "UserPassword123#",
                FirstName = "UserFirstName",
                LastName = "UserLastName",
                Email = "test@Email.com",
            };

            var validationResults = this.validator.Validate(model);

            Assert.True(validationResults.IsValid);
        }

        [Fact]
        public void ValidationWrongEmailFormat()
        {
            var model = new CreateAccountModel()
            {
                UserName = "UserNameTestEmail",
                Password = "UserPassword123#",
                RepeatPassword = "UserPassword123#",
                FirstName = "UserFirstName",
                LastName = "UserLastName",
                Email = "testEm#ail.com",
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationNotUniqueUserName()
        {
            var model = new CreateAccountModel()
            {
                UserName = "UserNameNotUnique",
                Password = "UserPassword123#",
                RepeatPassword = "UserPassword123#",
                FirstName = "UserFirstName",
                LastName = "UserLastName",
                Email = "testEm@ail.com",
            };

            var user = new IdentityUser()
            {
                UserName = model.UserName,
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationPasswordsNotMatch()
        {
            var model = new CreateAccountModel()
            {
                UserName = "UserNamePasswords",
                Password = "UserPassword123#",
                RepeatPassword = "UserPassword12efffewf3#",
                FirstName = "UserFirstName",
                LastName = "UserLastName",
                Email = "test@Email.com",
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationPasswordTooShort()
        {
            var model = new CreateAccountModel()
            {
                UserName = "UserNameTestTooShort",
                Password = new string('-', AccountConstants.MinLengthForPassword - 1),
                RepeatPassword = new string('-', AccountConstants.MinLengthForPassword - 1),
                FirstName = "UserFirstName",
                LastName = "UserLastName",
                Email = "test@Email.com",
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationTooLongStrings()
        {
            var model = new CreateAccountModel()
            {
                UserName = new string('-', AccountConstants.MaxLengthForUserName + 1),
                Password = new string('-', AccountConstants.MaxLengthForPassword + 1),
                RepeatPassword = new string('-', AccountConstants.MaxLengthForPassword + 1),
                FirstName = new string('-', AccountConstants.MaxLengthForFirstName + 1),
                LastName = new string('-', AccountConstants.MaxLengthForLastName + 1),
                Email = "test@email.com",
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationEmptyStrings()
        {
            var model = new CreateAccountModel()
            {
                UserName = string.Empty,
                Password = string.Empty,
                RepeatPassword = string.Empty,
                FirstName = string.Empty,
                LastName = string.Empty,
                Email = string.Empty,
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationNullStrings()
        {
            var model = new CreateAccountModel()
            {
                UserName = null,
                Password = null,
                RepeatPassword = null,
                FirstName = null,
                LastName = null,
                Email = null,
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }
    }
}
