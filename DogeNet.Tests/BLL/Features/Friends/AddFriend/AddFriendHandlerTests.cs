// <copyright file="AddFriendHandlerTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Friends.AddFriend
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.BLL.Features.Friends.AddFriend;
    using DogeNet.BLL.Features.Group.CreateGroup;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class AddFriendHandlerTests
    {
        private readonly DBContext context;
        private readonly AddFriendHandler handler;
        private readonly IMapper mapper;

        public AddFriendHandlerTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
            optionsBuilder.UseInMemoryDatabase("AddFriendHandlerTests");

            this.context = new DBContext(optionsBuilder.Options);

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AddFriendModelProfiles>());
            this.mapper = config.CreateMapper();

            var sender = new User()
            {
                UserName = "user1",
            };

            var reciever = new User()
            {
                UserName = "user2",
            };
            this.context.AppUsers.Add(sender);
            this.context.AppUsers.Add(reciever);

            this.handler = new AddFriendHandler(this.context, this.mapper);
        }

        [Fact]
        public async void HandleNormalFriend()
        {
            var model = new AddFriendModel()
            {
                UserId = 1,
                FriendId = 2,
            };

            var command = new AddFriendCommand(model);

            await this.handler.Handle(command, CancellationToken.None);

            Assert.Equal(1, this.context.FriendRequests.Where(item =>
            item.UserId.Equals(model.UserId) &&
            item.FriendId.Equals(model.FriendId)).Count());
        }

        [Fact]
        public async void HandleNullModel()
        {
            AddFriendModel model = null;
            var command = new AddFriendCommand(model);

            Func<Task> res = () => this.handler.Handle(command, CancellationToken.None);

            await Assert.ThrowsAsync<InvalidOperationException>(res);
        }

        [Fact]
        public async void HandleErrorCommandNull()
        {
            AddFriendCommand command = null;

            Func<Task> res = () => this.handler.Handle(command, CancellationToken.None);

            await Assert.ThrowsAsync<InvalidOperationException>(res);
        }
    }
}
