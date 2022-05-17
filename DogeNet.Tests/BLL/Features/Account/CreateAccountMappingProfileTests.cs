// <copyright file="CreateAccountMappingProfileTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Account
{
    using AutoMapper;
    using DogeNet.BLL.Features.Account.CreateAccount;
    using DogeNet.DAL.Models;
    using Microsoft.AspNetCore.Identity;
    using Xunit;

    public class CreateAccountMappingProfileTests
    {
        private readonly IMapper mapper;

        public CreateAccountMappingProfileTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CreateAccountModelProfiles>());
            this.mapper = config.CreateMapper();
        }

        [Fact]
        public void ToAppUserMap()
        {
            var model = new CreateAccountModel()
            {
                UserName = "UserNameTest",
                Password = "UserPassword123#",
                RepeatPassword = "UserPassword123#",
                FirstName = "UserFirstName",
                LastName = "UserLastName",
            };

            var user = new User();

            user = this.mapper.Map<CreateAccountModel, User>(model);

            Assert.True(user.UserName == model.UserName && user.FirstName == model.FirstName && user.LastName == model.LastName);
        }
    }
}
