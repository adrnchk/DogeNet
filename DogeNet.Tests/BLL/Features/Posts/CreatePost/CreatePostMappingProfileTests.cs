// <copyright file="CreatePostMappingProfileTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Posts.CreatePost
{
    using AutoMapper;
    using DogeNet.BLL.Features.Posts.CreatePost;
    using DogeNet.DAL.Models;
    using Microsoft.AspNetCore.Identity;
    using Xunit;

    public class CreatePostMappingProfileTests
    {
        private readonly IMapper mapper;

        public CreatePostMappingProfileTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CreatePostModelProfiles>());
            this.mapper = config.CreateMapper();
        }


        [Fact]
        public void ToPost()
        {
            var model = new CreatePostModel()
            {
                Title = "Post1",
                Text = "Post1",
                IsCommentAvailable = true,
                CreatorId = 1,
            };

            var post = this.mapper.Map<CreatePostModel, Post>(model);

            Assert.True(post.Title == model.Title && post.Text == model.Text && post.CreatorId == model.CreatorId);
        }
    }
}
