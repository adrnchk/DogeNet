// <copyright file="CreatePostHandlerTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Posts.CreatePost
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using AutoMapper;
    using DogeNet.BLL.Features.Posts.CreatePost;
    using DogeNet.BLL.Services.Implementations;
    using DogeNet.DAL;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class CreatePostHandlerTests
    {
        private readonly DBContext context;
        private readonly CreatePostHandler handler;
        private readonly IMapper mapper;

        public CreatePostHandlerTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
            optionsBuilder.UseInMemoryDatabase("CreatePostHandlerTests");

            this.context = new DBContext(optionsBuilder.Options);

            var config = new MapperConfiguration(cfg => cfg.AddProfile<CreatePostModelProfiles>());
            this.mapper = config.CreateMapper();

            this.handler = new CreatePostHandler(this.context, this.mapper);
        }

        [Fact]
        public async void HandleNormalPost()
        {
            var model = new CreatePostModel()
            {
              Title = "Post1",
              Text = "Post1",
              IsCommentAvailable = true,
              CreatorId = 1,
            };

            var command = new CreatePostCommand(model);

            await this.handler.Handle(command, CancellationToken.None);

            Assert.Equal(1, this.context.Posts.Where(post => post.Title.Equals(model.Title)).Count());
        }

        [Fact]
        public async void HandleNullPost()
        {
            try
            {
                CreatePostModel model = null;
                var command = new CreatePostCommand(model);

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
                CreatePostCommand command = null;

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
