// <copyright file="AddFriendValidatorTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Friends.AddFriend
{
    using DogeNet.BLL.Features.Friends.AddFriend;
    using DogeNet.DAL;
    using Microsoft.EntityFrameworkCore;
    using System;
    using Xunit;

    public class AddFriendValidatorTests
    {
        private readonly DBContext context;
        private readonly AddFriendModelValidator validator;

        public AddFriendValidatorTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();

            optionsBuilder.UseInMemoryDatabase("AddFriendModelValidatorTests");

            this.context = new DBContext(optionsBuilder.Options);

            this.validator = new AddFriendModelValidator(this.context);
        }

        [Fact]
        public void ValidationNormal()
        {
            var model = new AddFriendModel()
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
            var model = new AddFriendModel()
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
            AddFriendModel model = null;
            try
            {
                var validationResults = this.validator.Validate(model);
            }
            catch (ArgumentNullException exp)
            {
                Assert.True(true);
            }
            catch (Exception exp)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void ValidationNullProperty()
        {
            var model = new AddFriendModel()
            {
                FriendId = 0,
                UserId = 0,
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }
    }
}
