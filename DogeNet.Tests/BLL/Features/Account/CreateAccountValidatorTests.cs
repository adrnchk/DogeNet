// <copyright file="CreateAccountValidatorTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Account
{
    using DogeNet.BLL.Features.Account;
    using DogeNet.BLL.Features.Account.CreateAccount;
    using Xunit;

    public class CreateAccountValidatorTests
    {
        [Fact]
        public void ValidationNormal()
        {
            CreateAccountModel model = new CreateAccountModel()
            {
                UserName = "UserNameTest",
                Password = "UserPassword123#",
                RepeatPassword = "UserPassword123#",
                FirstName = "UserFirstName",
                LastName = "UserLastName",
                Email = "test@Email.com",
            };
            CreateAccountValidator validator = new CreateAccountValidator();

            var validationResults = validator.Validate(model);

            Assert.True(validationResults.IsValid);
        }

        [Fact]
        public void ValidationWrongEmailFormat()
        {
            CreateAccountModel model = new CreateAccountModel()
            {
                UserName = "UserNameTest",
                Password = "UserPassword123#",
                RepeatPassword = "UserPassword123#",
                FirstName = "UserFirstName",
                LastName = "UserLastName",
                Email = "testEm#ail.com",
            };
            CreateAccountValidator validator = new CreateAccountValidator();

            var validationResults = validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationPasswordsNotMatch()
        {
            CreateAccountModel model = new CreateAccountModel()
            {
                UserName = "UserNameTest",
                Password = "UserPassword123#",
                RepeatPassword = "UserPassword12efffewf3#",
                FirstName = "UserFirstName",
                LastName = "UserLastName",
                Email = "test@Email.com",
            };
            CreateAccountValidator validator = new CreateAccountValidator();

            var validationResults = validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationPasswordTooShort()
        {
            CreateAccountModel model = new CreateAccountModel()
            {
                UserName = "UserNameTest",
                Password = new string('-', AccountConstants.MinLengthForPassword - 1),
                RepeatPassword = new string('-', AccountConstants.MinLengthForPassword - 1),
                FirstName = "UserFirstName",
                LastName = "UserLastName",
                Email = "test@Email.com",
            };
            CreateAccountValidator validator = new CreateAccountValidator();

            var validationResults = validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationTooLongStrings()
        {
            CreateAccountModel model = new CreateAccountModel()
            {
                UserName = new string('-', AccountConstants.MaxLengthForUserName + 1),
                Password = new string('-', AccountConstants.MaxLengthForPassword + 1),
                RepeatPassword = new string('-', AccountConstants.MaxLengthForPassword + 1),
                FirstName = new string('-', AccountConstants.MaxLengthForFirstName + 1),
                LastName = new string('-', AccountConstants.MaxLengthForLastName + 1),
                Email = "test@email.com",
            };
            CreateAccountValidator validator = new CreateAccountValidator();

            var validationResults = validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationEmptyStrings()
        {
            CreateAccountModel model = new CreateAccountModel()
            {
                UserName = string.Empty,
                Password = string.Empty,
                RepeatPassword = string.Empty,
                FirstName = string.Empty,
                LastName = string.Empty,
                Email = string.Empty,
            };
            CreateAccountValidator validator = new CreateAccountValidator();

            var validationResults = validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationNullStrings()
        {
            CreateAccountModel model = new CreateAccountModel()
            {
                UserName = null,
                Password = null,
                RepeatPassword = null,
                FirstName = null,
                LastName = null,
                Email = null,
            };
            CreateAccountValidator validator = new CreateAccountValidator();

            var validationResults = validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }
    }
}
