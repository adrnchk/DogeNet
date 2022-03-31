// <copyright file="CreatePostValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Posts.CreatePost
{
    using DogeNet.DAL;
    using FluentValidation;

    public class CreatePostValidator : AbstractValidator<CreatePostModel>
    {
        public CreatePostValidator(DBContext db)
        {
            this.RuleFor(enitity => enitity.Title).NotEmpty().NotNull().MinimumLength(PostConstants.MinLengthForTitle)
                .MaximumLength(PostConstants.MaxLengthForTitle);
            this.RuleFor(enitity => enitity.Text).NotNull().MaximumLength(PostConstants.MaxLengthForText);
            this.RuleFor(enitity => enitity.CreatorId).NotNull();
        }
    }
}
