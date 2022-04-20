// <copyright file="GetFriendsQueryValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.GetFriends
{
    using DogeNet.BLL.Extentions;
    using DogeNet.BLL.Features.Account;
    using DogeNet.DAL;
    using FluentValidation;

    public class GetFriendsQueryValidator : AbstractValidator<GetFriendsQuery>
    {
        public GetFriendsQueryValidator(DBContext db)
        {
            this.RuleFor(entity => entity).NotEmpty().NotNull()
                .Must(source => AccountChecks.UserIdValid(db, source.userId)).NotFound();
        }
    }
}
