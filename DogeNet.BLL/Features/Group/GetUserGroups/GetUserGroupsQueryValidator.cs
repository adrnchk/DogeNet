// <copyright file="GetUserGroupsQueryValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.GetUserGroups
{
    using DogeNet.BLL.Extentions;
    using DogeNet.BLL.Features.Account;
    using DogeNet.DAL;
    using FluentValidation;

    public class GetUserGroupsQueryValidator : AbstractValidator<GetUserGroupsQuery>
    {
        public GetUserGroupsQueryValidator(DBContext db)
        {
            this.RuleFor(entity => entity.id).NotNull().Must(source => AccountChecks.UserIdValid(db, source)).NotFound();
        }
    }
}
