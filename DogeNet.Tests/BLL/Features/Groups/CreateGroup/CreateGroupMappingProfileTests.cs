// <copyright file="CreateGroupMappingProfileTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Groups.CreateGroup
{
    using System;
    using AutoMapper;
    using DogeNet.BLL.Features.Group.CreateGroup;
    using DogeNet.BLL.Features.Posts.CreatePost;
    using DogeNet.DAL.Models;
    using Microsoft.AspNetCore.Identity;
    using Xunit;

    public class CreateGroupMappingProfileTests
    {
        private readonly IMapper mapper;

        public CreateGroupMappingProfileTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CreateGroupModelProfiles>());
            this.mapper = config.CreateMapper();
        }

        [Fact]
        public void ToGroup()
        {
            var model = new CreateGroupModel()
            {
                Title = "Group1",
                Name = "Group1",
                StatusId = 1,
                AvatarImg = "group1",
                CoverImg = "group1",
                CreatorId = 1,
            };

            var item = this.mapper.Map<CreateGroupModel, Group>(model);

            Assert.True(item.Title == model.Title && item.Name == model.Name && item.CreatorId == model.CreatorId);
        }

        [Fact]
        public void ToPostInvalid()
        {
            try
            {
                var model = new CreateGroupModel()
                {
                    Title = "Group1",
                    Name = "Group1",
                    StatusId = 1,
                    AvatarImg = "group1",
                    CoverImg = "group1",
                    CreatorId = 1,
                };

                var item = this.mapper.Map<CreateGroupModel, Post>(model);
            }
            catch (AutoMapperMappingException e)
            {
                Assert.True(true);
            }
            catch (Exception e)
            {
                Assert.False(true);
            }
        }
    }
}
