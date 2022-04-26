// <copyright file="AddFriendMappingTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Friends.AddFriend
{
    using System;
    using AutoMapper;
    using DogeNet.BLL.Features.Friends.AddFriend;
    using DogeNet.DAL.Models;
    using Microsoft.AspNetCore.Identity;
    using Xunit;

    public class AddFriendMappingTests
    {
        private readonly IMapper mapper;

        public AddFriendMappingTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AddFriendModelProfiles>());
            this.mapper = config.CreateMapper();
        }

        [Fact]
        public void ToFriend()
        {
            var model = new AddFriendModel()
            {
                UserId = 1,
                FriendId = 2,
            };

            var item = this.mapper.Map<AddFriendModel, Friend>(model);

            Assert.True(item.UserId == model.UserId && item.FriendId == model.FriendId);
        }

        [Fact]
        public void ToFriendRequest()
        {
            var model = new AddFriendModel()
            {
                UserId = 1,
                FriendId = 2,
            };

            var item = this.mapper.Map<AddFriendModel, FriendRequest>(model);

            Assert.True(item.UserId == model.UserId && item.FriendId == model.FriendId);
        }


        [Fact]
        public void ToPostInvalid()
        {
            var model = new AddFriendModel()
            {
                UserId = 1,
                FriendId = 2,
            };

            Action res = () => this.mapper.Map<AddFriendModel, Post>(model);
            Assert.Throws<AutoMapperMappingException>(res);
        }
    }
}
