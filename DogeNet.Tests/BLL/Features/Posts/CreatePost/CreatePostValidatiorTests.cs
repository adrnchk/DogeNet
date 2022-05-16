// <copyright file="CreatePostValidatiorTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Posts.CreatePost
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DogeNet.BLL.Features.Posts;
    using DogeNet.BLL.Features.Posts.CreatePost;
    using DogeNet.DAL;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class CreatePostValidatiorTests
    {
        private readonly DBContext context;
        private readonly CreatePostValidator validator;

        public CreatePostValidatiorTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();

            optionsBuilder.UseInMemoryDatabase("CreatePostValidatiorTests");

            this.context = new DBContext(optionsBuilder.Options);

            this.validator = new CreatePostValidator(this.context);
        }

        [Fact]
        public void ValidationNormal()
        {
            var model = new CreatePostModel()
            {
                Title = "Post1",
                Text = "Post1",
                IsCommentAvailable = true,
                CreatorId = 1,
            };
            var validationResults = this.validator.Validate(model);

            Assert.True(validationResults.IsValid);
        }

        [Fact]
        public void ValidationToLongText()
        {
            var model = new CreatePostModel()
            {
                Title = "Post2",
                Text = new string('-', PostConstants.MaxLengthForText + 1),
                IsCommentAvailable = true,
                CreatorId = 1,
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationToLongTitle()
        {
            var model = new CreatePostModel()
            {
                Title = new string('-', PostConstants.MaxLengthForTitle + 1),
                Text = "Post3",
                IsCommentAvailable = true,
                CreatorId = 1,
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        public void ValidationEmptyStrings()
        {
            var model = new CreatePostModel()
            {
                Title = string.Empty,
                Text = string.Empty,
                IsCommentAvailable = true,
                CreatorId = 1,
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationNullCreatorId()
        {
            var model = new CreatePostModel()
            {
                Title = "Post4",
                Text = "Post4",
                IsCommentAvailable = true,
                CreatorId = null,
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }
    }
}
