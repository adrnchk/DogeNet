// <copyright file="CreateAccountHandlerTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using AutoMapper;
    using DogeNet.BLL.Features.Account.CreateAccount;
    using DogeNet.DAL;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class CreateAccountHandlerTests
    {
        private readonly DBContext context;
        private readonly CreateAccountHandler handler;
        private readonly IMapper mapper;
        private readonly List<IdentityUser> users;

        public CreateAccountHandlerTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
            optionsBuilder.UseInMemoryDatabase("TEST_ONLY");

            this.context = new DBContext(optionsBuilder.Options);

            this.users = new List<IdentityUser>();

            var store = new Mock<IUserStore<IdentityUser>>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<CreateAccountModelProfiles>());
            this.mapper = config.CreateMapper();

            this.handler = new CreateAccountHandler(this.context, this.mapper);
        }

        [Fact]
        public async void HandleNormalAppUser()
        {
            var model = new CreateAccountModel()
            {
                UserName = "HandleAppUser",
                Password = "UserPassword123#",
                RepeatPassword = "UserPassword123#",
                FirstName = "UserFirstName",
                LastName = "UserLastName",
            };

            var command = new CreateAccountCommand(model);

            await this.handler.Handle(command, CancellationToken.None);

            Assert.Equal(1, this.context.AppUsers.Where(user => user.UserName.Equals(model.UserName)).Count());
        }

        [Fact]
        public async void HandleNormalIdentityUser()
        {
            var model = new CreateAccountModel()
            {
                UserName = "HandleIdentityUser",
                Password = "UserPassword123#",
                RepeatPassword = "UserPassword123#",
                FirstName = "UserFirstName",
                LastName = "UserLastName",
            };

            var command = new CreateAccountCommand(model);

            await this.handler.Handle(command, CancellationToken.None);

            Assert.Single(this.users.Where(user => user.UserName.Equals(model.UserName)));
        }

        [Fact]
        public async void HandleErrorModelNull()
        {
            try
            {
                CreateAccountModel model = null;
                var command = new CreateAccountCommand(model);

                await this.handler.Handle(command, CancellationToken.None);
            }
            catch (NullReferenceException e)
            {
                Assert.True(true);
            }
            catch (Exception e)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async void HandleErrorCommandNull()
        {
            try
            {
                CreateAccountCommand command = null;

                await this.handler.Handle(command, CancellationToken.None);
            }
            catch (NullReferenceException e)
            {
                Assert.True(true);
            }
            catch (Exception e)
            {
                Assert.True(false);
            }
        }
    }
}
