// <copyright file="GetBlackListHandlerTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Friends.GetBlackList
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.BLL.Features.Friends.AddFriend;
    using DogeNet.BLL.Features.Friends.GetBlackList;
    using DogeNet.BLL.Features.Friends.GetFriends;
    using DogeNet.BLL.Features.Group.CreateGroup;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class GetBlackListHandlerTests
    {
        private readonly DBContext context;
        private readonly GetBlackListHandler handler;
        private readonly IMapper mapper;

        public GetBlackListHandlerTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
            optionsBuilder.UseInMemoryDatabase("GetBlackListHandlerTests");

            this.context = new DBContext(optionsBuilder.Options);

            var config = new MapperConfiguration(cfg => cfg.AddProfile<GetBlackListModelProfiles>());
            this.mapper = config.CreateMapper();

            this.handler = new GetBlackListHandler(this.context, this.mapper);
        }

        [Fact]
        public async void HandleNormal()
        {
            var command = new GetBlackListQuery(1);

            Assert.Empty(await this.handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async void HandleErrorCommandNull()
        {
            GetBlackListQuery command = null;

            Func<Task> res = () => this.handler.Handle(command, CancellationToken.None);

            await Assert.ThrowsAsync<InvalidOperationException>(res);
        }
    }
}
