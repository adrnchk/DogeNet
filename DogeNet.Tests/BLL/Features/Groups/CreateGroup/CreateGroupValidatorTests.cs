// <copyright file="CreateGroupValidatorTests.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Tests.BLL.Features.Groups.CreateGroup
{
    using DogeNet.BLL.Features.Group;
    using DogeNet.BLL.Features.Group.CreateGroup;
    using Xunit;

    public class CreateGroupValidatorTests
    {
        private readonly CreateGroupValidator validator;

        public CreateGroupValidatorTests()
        {
            this.validator = new CreateGroupValidator();
        }

        [Fact]
        public void ValidationNormal()
        {
            var model = new CreateGroupModel()
            {
                Title = "Group1",
                Name = "Group1",
                StatusId = 1,
                AvatarImg = "https://www.hollywoodreporter.com/wp-content/uploads/2019/03/avatar-publicity_still-h_2019.jpg",
                CoverImg = string.Empty,
                CreatorId = 1,
            };
            var validationResults = this.validator.Validate(model);

            Assert.True(validationResults.IsValid);
        }

        [Fact]
        public void ValidationToLongName()
        {
            var model = new CreateGroupModel()
            {
                Title = "Group2",
                Name = new string('-', GroupConstants.MaxLengthForName + 1),
                StatusId = 1,
                AvatarImg = "group2",
                CoverImg = "group2",
                CreatorId = 1,
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        [Fact]
        public void ValidationToLongTitle()
        {
            var model = new CreateGroupModel()
            {
                Title = new string('-', GroupConstants.MaxLengthForTitle + 1),
                Name = "Group3",
                StatusId = 1,
                AvatarImg = "group3",
                CoverImg = "group3",
                CreatorId = 1,
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }

        public void ValidationEmptyStrings()
        {
            var model = new CreateGroupModel()
            {
                Title = string.Empty,
                Name = string.Empty,
                StatusId = 1,
                AvatarImg = string.Empty,
                CoverImg = string.Empty,
                CreatorId = 1,
            };

            var validationResults = this.validator.Validate(model);

            Assert.False(validationResults.IsValid);
        }
    }
}
