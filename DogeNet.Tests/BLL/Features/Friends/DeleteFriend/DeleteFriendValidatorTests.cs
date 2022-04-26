// <copyright file="DeleteFriendValidatorTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Friends.DeleteFriend
{
    using DogeNet.BLL.Features.Friends.AddFriend;
    using DogeNet.BLL.Features.Friends.DeleteFriend;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using Xunit;

    public class DeleteFriendValidatorTests
    {
        private readonly DBContext context;
        private readonly DeleteFriendModelValidator validator;

        public DeleteFriendValidatorTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();

            optionsBuilder.UseInMemoryDatabase("DeleteFriendModelValidatorTests");

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

            this.validator = new DeleteFriendModelValidator(this.context);
        }

        [Fact]
        public void ValidationNormal()
        {
            var model = new DeleteFriendModel()
            {
                FriendId = 1,
                UserId = 2,
            };
            var validationResults = this.validator.Validate(model);

            Assert.True(validationResults.IsValid);
        }

        [Fact]
        public void ValidationSameUser()
        {
            var model = new DeleteFriendModel()
            {
                FriendId = 1,
                UserId = 1,
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationNull()
        {
            DeleteFriendModel model = null;
            Action validationResults = () => this.validator.Validate(model);

            Assert.Throws<ArgumentNullException>(validationResults);
        }

        [Fact]
        public void ValidationNullProperty()
        {
            var model = new DeleteFriendModel()
            {
                FriendId = 0,
                UserId = 0,
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }
    }
}
