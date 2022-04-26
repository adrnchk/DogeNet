// <copyright file="GetFriendsHandlerTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Friends.GetFriends
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.BLL.Features.Friends.AddFriend;
    using DogeNet.BLL.Features.Friends.GetFriends;
    using DogeNet.BLL.Features.Group.CreateGroup;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class GetFriendsHandlerTests
    {
        private readonly DBContext context;
        private readonly GetFriendsHandler handler;
        private readonly IMapper mapper;

        public GetFriendsHandlerTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
            optionsBuilder.UseInMemoryDatabase("GetFriendsHandlerTests");

            this.context = new DBContext(optionsBuilder.Options);

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AddFriendModelProfiles>());
            this.mapper = config.CreateMapper();

            this.handler = new GetFriendsHandler(this.context, this.mapper);
        }

        [Fact]
        public async void HandleNormalFriend()
        {
            var command = new GetFriendsQuery(1);

            Assert.Empty(await this.handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async void HandleErrorCommandNull()
        {
            GetFriendsQuery command = null;

            Func<Task> res = () => this.handler.Handle(command, CancellationToken.None);

            await Assert.ThrowsAsync<InvalidOperationException>(res);
        }
    }
}
