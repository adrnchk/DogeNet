// <copyright file="GetPostQueryValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Posts.GetPost
{
    using DogeNet.DAL;
    using FluentValidation;

    public class GetPostQueryValidator : AbstractValidator<GetPostQuery>
    {
        public GetPostQueryValidator(DBContext db)
        {
            this.RuleFor(entity => entity.id).NotNull().Must(id => PostChecks.PostIdValid(db, id)).WithMessage("Post not found"); ;
        }
    }
}
