// <copyright file="CreateGroupHandlerTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Groups.CreateGroup
{
    using System;
    using System.Linq;
    using System.Threading;
    using AutoMapper;
    using DogeNet.BLL.Features.Group.CreateGroup;
    using DogeNet.DAL;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CreateGroupHandlerTests
    {
        private readonly DBContext context;
        private readonly CreateGroupHandler handler;
        private readonly IMapper mapper;

        public CreateGroupHandlerTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
            optionsBuilder.UseInMemoryDatabase("CreateGroupHandlerTests");

            this.context = new DBContext(optionsBuilder.Options);

            var config = new MapperConfiguration(cfg => cfg.AddProfile<CreateGroupModelProfiles>());
            this.mapper = config.CreateMapper();

            this.handler = new CreateGroupHandler(this.context, this.mapper);
        }

        [Fact]
        public async void HandleNormalGroup()
        {
            var model = new CreateGroupModel()
            {
                Title = "Group1",
                Name = "Group1",
                StatusId = 1,
                AvatarImg = "group1",
                CoverImg = "group1",
                CreatorId = 1,

            };

            var command = new CreateGroupCommand(model);

            await this.handler.Handle(command, CancellationToken.None);

            Assert.Equal(1, this.context.Groups.Where(item => item.Title.Equals(model.Title)).Count());
        }

        [Fact]
        public async void HandleNullGroup()
        {
            try
            {
                CreateGroupModel model = null;
                var command = new CreateGroupCommand(model);

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
                CreateGroupCommand command = null;

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
