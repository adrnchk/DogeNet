// <copyright file="EditPostValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Posts.EditPost
{
    using DogeNet.DAL;
    using FluentValidation;

    public class EditPostValidator : AbstractValidator<EditPostModel>
    {
        public EditPostValidator(DBContext db)
        {
            this.RuleFor(entity => entity.Id).NotNull();
            this.RuleFor(enitity => enitity.Title).NotEmpty().NotNull().MinimumLength(PostConstants.MinLengthForTitle)
                .MaximumLength(PostConstants.MaxLengthForTitle);
            this.RuleFor(enitity => enitity.Text).NotNull().MaximumLength(PostConstants.MaxLengthForText);
        }
    }
}
