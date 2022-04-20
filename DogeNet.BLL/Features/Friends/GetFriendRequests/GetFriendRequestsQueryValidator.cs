// <copyright file="GetFriendRequestsQueryValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.GetFriendRequests
{
    using DogeNet.BLL.Extentions;
    using DogeNet.BLL.Features.Account;
    using DogeNet.DAL;
    using FluentValidation;

    public class GetFriendRequestsQueryValidator : AbstractValidator<GetFriendRequestsQuery>
    {
        public GetFriendRequestsQueryValidator(DBContext db)
        {
            this.RuleFor(entity => entity.userId).NotEmpty().NotNull()
                .Must(source => AccountChecks.UserIdValid(db, source)).NotFound();
        }
    }
}
