// <copyright file="CreateAccountValidatorTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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
                Password = "123",
                RepeatPassword = "123",
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
                UserName = "UserNam434124442142412421442421455555555555555555555555555555555555544555555555555555555521412421421424124164354435533545eTest",
                Password = "UserPassword12ef5555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555ffewf3#",
                RepeatPassword = "UserPassword12ef5555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555ffewf3#",
                FirstName = "UserNam434124442142412421442421455555555555555555555555555555555555544555555555555555555521412421421424124164354435533545eTest",
                LastName = "UserNam434124442142412421442421455555555555555555555555555555555555544555555555555555555521412421421424124164354435533545eTest",
                Email = "UserNam434124442142412421442421455555555555555555555555555555555555544555555555555555555521412421421424124164354435533545eTest@Email.com",
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
