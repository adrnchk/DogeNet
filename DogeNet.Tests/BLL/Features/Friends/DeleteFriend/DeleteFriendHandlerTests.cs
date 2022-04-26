// <copyright file="DeleteFriendValidatorTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Friends.DeleteFriend
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using DogeNet.BLL.Features.Friends.DeleteFriend;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class DeleteFriendHandlerTests
    {
        private readonly DBContext context;
        private readonly DeleteFriendHandler handler;

        public DeleteFriendHandlerTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
            optionsBuilder.UseInMemoryDatabase("DeleteFriendHandlerTests");

            this.context = new DBContext(optionsBuilder.Options);

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

            var friends = new Friend()
            {
                UserId = 1,
                FriendId = 2,
            };

            this.context.Friends.Add(friends);
            this.context.SaveChanges();

            this.handler = new DeleteFriendHandler(this.context);
        }

        [Fact]
        public async void HandleNormalFriend()
        {
            var model = new DeleteFriendModel()
            {
                UserId = 1,
                FriendId = 2,
            };

            var command = new DeleteFriendCommand(model);

            await this.handler.Handle(command, CancellationToken.None);

            Assert.Equal(0, this.context.Friends.Where(item =>
            item.UserId.Equals(model.UserId) &&
            item.FriendId.Equals(model.FriendId)).Count());
        }

        [Fact]
        public async void HandleNullModel()
        {
            DeleteFriendModel model = null;
            var command = new DeleteFriendCommand(model);

            Func<Task> res = () => this.handler.Handle(command, CancellationToken.None);

            await Assert.ThrowsAsync<InvalidOperationException>(res);
        }

        [Fact]
        public async void HandleErrorCommandNull()
        {
            DeleteFriendCommand command = null;

            Func<Task> res = () => this.handler.Handle(command, CancellationToken.None);

            await Assert.ThrowsAsync<InvalidOperationException>(res);
        }
    }
}
