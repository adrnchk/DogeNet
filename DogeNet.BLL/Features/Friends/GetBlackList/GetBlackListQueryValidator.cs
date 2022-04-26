// <copyright file="GetBlackListQueryValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.GetBlackList
{
    using DogeNet.BLL.Extentions;
    using DogeNet.BLL.Features.Account;
    using DogeNet.DAL;
    using FluentValidation;

    public class GetBlackListQueryValidator : AbstractValidator<GetBlackListQuery>
    {
        public GetBlackListQueryValidator(DBContext db)
        {
            this.RuleFor(entity => entity.userId).NotEmpty().NotNull()
                .Must(source => AccountChecks.UserIdValid(db, source)).NotFound();
        }
    }
}
