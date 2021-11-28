// <copyright file="CreateAccountMappingProfileTest.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.BLL.Features.Account.CreateAccount;
    using DogeNet.DAL.Models;
    using Microsoft.AspNetCore.Identity;
    using Xunit;

    public class CreateAccountMappingProfileTest
    {
        [Fact]
        public void ToIdentityUserMap()
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

            var user = new IdentityUser();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<CreateAccountModelProfiles>());
            var mapper = config.CreateMapper();

            user = mapper.Map<CreateAccountModel, IdentityUser>(model);

            Assert.True(user.UserName == model.UserName && user.Email == model.Email);
        }

        [Fact]
        public void ToAppUserMap()
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

            var user = new User();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<CreateAccountModelProfiles>());
            var mapper = config.CreateMapper();

            user = mapper.Map<CreateAccountModel, User>(model);

            Assert.True(user.UserName == model.UserName && user.FirstName == model.FirstName && user.LastName == model.LastName);
        }
    }
}
